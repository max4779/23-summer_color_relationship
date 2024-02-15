using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // ȸ�� �ӵ�

    private bool rightStick = false; // ������ ��Ʈ�ѷ� ���̽�ƽ ��� ����

    private void Update()
    {
        // ������ ��Ʈ�ѷ��� ���̽�ƽ �Է� ��������
        Vector2 rightThumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        // �÷��̾� ȸ�� ó��
        RotatePlayer(rightThumbstickInput);
    }

    void RotatePlayer(Vector2 thumbstickInput)
    {
        // ������ ��Ʈ�ѷ��� X�� �Է� ���� �̿��Ͽ� ȸ��
        float rightRotationAmount = thumbstickInput.x * rotationSpeed * Time.deltaTime;

        // ������ ��Ʈ�ѷ� ���̽�ƽ�� �����̸� ȸ�� ����
        if (Mathf.Abs(thumbstickInput.x) > 0.1f)
        {
            rightStick = true;
        }

        // ������ ��Ʈ�ѷ� ���̽�ƽ�� ���߸� ȸ�� ����
        if (Mathf.Abs(thumbstickInput.x) < 0.1f && rightStick)
        {
            rightStick = false;
            rightRotationAmount = 0;
        }

        // �÷��̾� ȸ��
        transform.Rotate(Vector3.up, rightRotationAmount);
    }
}



