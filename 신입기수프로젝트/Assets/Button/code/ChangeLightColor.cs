using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color32 LightBlue = new Color32(185, 217, 212, 255);
    public Color32 Pink = new Color32(238, 190, 190, 255);
    public Color[] colors;

    int colorIndex = 0;
    bool enableColorChange = false;

    List<Light> lights = new List<Light>();

    void Start()
    {
        // LightBlue와 Pink를 colors 배열에 추가
        colors = new Color[] { Color.red, Color.blue, Color.green, LightBlue, Pink };

        // 모든 Light 컴포넌트를 찾아서 리스트에 추가
        Light[] lightComponents = FindObjectsOfType<Light>();
        foreach (Light light in lightComponents)
        {
            lights.Add(light);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enableColorChange = true; // 마우스 클릭 시 색상 변경 활성화
        }
    }

    void OnMouseDown()
    {
        if (enableColorChange)
        {
            ChangeColor();
            enableColorChange = false; // 색상 변경 후 다시 비활성화
        }
    }

    void ChangeColor()
    {
        // 다음 색상으로 변경
        colorIndex = (colorIndex + 1) % colors.Length;

        // 모든 조명의 색상을 변경
        foreach (Light light in lights)
        {
            light.color = colors[colorIndex];
        }
    }
}
