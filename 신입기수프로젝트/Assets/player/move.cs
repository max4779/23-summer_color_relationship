using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class move : MonoBehaviour
{
    public float moveSpeed = 1.0f;   // 이동 속도

    private void Update()
    {
        // 왼쪽 컨트롤러의 조이스틱 입력 가져오기
        Vector2 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // 플레이어 이동 및 회전 처리
        MovePlayer(leftStick);
    }

    void MovePlayer(Vector2 thumbstickInput)
    {
        // 플레이어 이동 방향 계산
        Vector3 moveDirection = new Vector3(thumbstickInput.x, 0, thumbstickInput.y);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0; // 수직 방향 제거
        moveDirection.Normalize();

        // 플레이어 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}