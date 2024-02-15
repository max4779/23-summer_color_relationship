using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallColor : MonoBehaviour 
{
    public Color32 LightBlue = new Color32(185, 217, 212, 255); 
    public Color32 Pink = new Color32(238, 190, 190, 255);
    public Color[] colors;

    int colorIndex = 0;

    Renderer wallRenderer;
    Renderer wallRenderer2;
    Renderer wallRenderer3;
    Renderer wallRenderer4;
    bool EnableChange = false; 

    void Start() 
    {
        colors = new Color[] { Color.red, Color.blue, Color.green, LightBlue, Pink };

        GameObject wall1 = GameObject.Find("wall1");
        GameObject wall2 = GameObject.Find("wall2");
        GameObject wall3 = GameObject.Find("wall3");
        GameObject wall4 = GameObject.Find("wall4");

        if (wall1 != null)
        {
            wallRenderer = wall1.GetComponent<Renderer>();
            wallRenderer2 = wall2.GetComponent<Renderer>();
            wallRenderer3 = wall3.GetComponent<Renderer>();
            wallRenderer4 = wall4.GetComponent<Renderer>();
        }
    }

    void Update()
    {
        // space 기능 이전
    }

   

    // public void OnMouseDown()
    // {
    //     ChangeColor();
    // }

    public void ChangeColor()
    {
        // ���� �������� ����
        colorIndex = (colorIndex + 1) % colors.Length;
        // Change question�� score���� �ʱ�ȭ

        Invoke("ResetScore", 3f);
        // WallF�� WallL�� ������ ������Ʈ�� ���� ���� ����
        if (wallRenderer != null)
        {
            wallRenderer.material.color = colors[colorIndex];
            wallRenderer2.material.color = colors[colorIndex];
            wallRenderer3.material.color = colors[colorIndex];
            wallRenderer4.material.color = colors[colorIndex];
        }
    }
    
    void ResetScore()
    {
        GameObject.Find("questionbutton").GetComponent<changequestion>().score = 0;
    }
}