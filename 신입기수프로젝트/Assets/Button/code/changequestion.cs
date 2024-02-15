using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//cubematerial.Length를 바꿔야지 바뀌는 이미지의 수를 설정 가능함. 주의**************

public class changequestion : MonoBehaviour 
{
    public Material[] cubematerial;
    
    int wallcolor_index = 0;

    public GameObject question;

    Boolean doesWallColorChanged = true;
    string materialname = "start";
    string beforeMaterialname = "";
    //Dictionary<string, string> materialoverlap = new Dictionary<string, string>();

    public string [] materialoverlap = new string[10];
    //string[] materialoverlap = new string[];
    
    // material �̸��� ���� �ߺ��� Ȯ���ϱ� ���� ����



    //for(int i=0;i<cubematerial.Length();i++){
    //    materialOverlap<cubematerial[i], OverlapCount>;
    //}




    //private int[Material.size()][] count; //�ߺ� Ȯ�ο�
    //for(int i=0; i<count.size();i++){
    //    for(int j=0;j<Material.size();j++){
    //        if(Material[j]==materialNames[i]){

    //        }
    //    }
    //}


    private int NumberOfTest = -1;

    private float time = 0.0f;
    public float waitingTime = 2.0f;

    public int score = 0;
    public Text scoreOutput;
    private int count = 0;
    public int click = 0;
    private float jumsu = 0.0f;
    private bool alreadystart = false;

    bool start = false;
    public void startQuestion()
    {
        alreadystart = true;


    }


    void Update()
    {
        if (alreadystart)
        {
            time += Time.deltaTime;

            if (time >= waitingTime)
            {
                Changeimage(wallcolor_index);
                time = 0.0f;
            }
            // 나중에 총 사진의 개수를 5 대신 대입하여 사용하면 됨.
            if (count == 10)
            {
                UpdateScoreText();
                alreadystart = false;
                count = 0;
                wallcolor_index+=1;
            }
        }

        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            pressTrigger();
        }
                

        

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            pressTrigger();
        }

        

    }



    public void pressTrigger()
    {
        bool flag = false;
        for(int i = 0 ; i < 10; i++)
        {
            if (materialoverlap[i] == materialname)
            {
                flag = true;
            }
        }
        if (click == 0)
        {
    

            
            if (flag)
             {
            
                score++;
                Debug.Log("plus score :" + score);
            
             }
             else
             {
                
                score--;
                //materialoverlap.Add(materialname, 1);
                Debug.Log("minus score :" + score);
                //Debug.Log("materialoverlap :" + materialoverlap[materialname]);
            
             }
        }


        
        click++;
    }
        //if (numberoftest == 3 && click == 0)
        //{
        //    score++;
        //    click++;

        //}
        //if (numberoftest == 1 && click == 0)
        //{
        //    score++;
        //    click++;

        //}
    }

    

    public void Changeimage(int wallcolor_index)
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            doesWallColorChanged = true;
        }

        if(count==0){
            if(wallcolor_index==0){ 
                NumberOfTest=0;
            }
            else if(wallcolor_index==1){
                NumberOfTest = 10;
             }
            else if(wallcolor_index==2){
                 NumberOfTest=20;
            }
            // else if(wallcolor_index==3){
            //     NumberOfTest=15;
            // }
            // else if(wallcolor_index==4){
            //     NumberOfTest=20;
            // }
        }



        click = 0;
        Renderer renderer = question.GetComponent<Renderer>();
        Renderer beforeRenderer = question.GetComponent<Renderer>();
        if (renderer != null && count != 10 && doesWallColorChanged)//그림 갯수
        {
            count++;
            NumberOfTest = (NumberOfTest + 1);
            renderer.material = cubematerial[NumberOfTest];
            
            if(NumberOfTest!=0){
                beforeRenderer.material = cubematerial[NumberOfTest - 1];
                materialoverlap[NumberOfTest] = beforeMaterialname;
                
            }
            materialname = renderer.material.name;
            beforeMaterialname = beforeRenderer.material.name;
            Debug.Log("Numberoftest :"+ NumberOfTest);
            Debug.Log("cubematerialname :"+beforeMaterialname);
            
                
             //materialoverlap.Add(beforeMaterialname, beforeMaterialname);
            
        }
        else
        {
            alreadystart = false;
            doesWallColorChanged= false;

        }
    }

    void UpdateScoreText()
    {

        float M_Length = 10 - 3; //은 중복되는 수   10은 한 색상당 나오는 그림의 개수
        jumsu = ((M_Length + score) / (10)) * 100;
        scoreOutput.text = "Score : " + jumsu.ToString() + "%";
        Debug.Log("Score :" +jumsu.ToString());
        Invoke("Disappear", 5f);
        
    }

    // void UpdateScoreText()
    // {
    //     float M_Length = cubematerial.Length-1 - 5; //은 중복되는 수
    //     jumsu = ((M_Length + score) / (cubematerial.Length/2)) * 100;
    //     scoreOutput.text = "Score : " + jumsu.ToString() + "%";
    //     Debug.Log("Score :" +jumsu.ToString());
    //     Invoke("Disappear", 5f);
    // }

    void Disappear()
    {
        scoreOutput.text = " ";
    }


