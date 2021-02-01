﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton2Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        //GUI버튼을 생성 
        if (GUI.Button(new Rect(20, 50, 100, 30), "Go1"))
        {
            LoadScenes1();
        }

        //GUI버튼을 생성 
        if (GUI.Button(new Rect(200, 50, 100, 30), "Test"))
        {
            Test1();
        }

        //GUI버튼을 생성 
        if (GUI.Button(new Rect(400, 50, 100, 30), "Go2"))
        {
            LoadScenes2();
        }

    }

    void LoadScenes1()
    {
        SceneManager.LoadScene("scSingleton2");
    }
    void LoadScenes2()
    {
        SceneManager.LoadScene("scSingleton1");
    }

    void Test1()
    {
        Debug.Log(Singleton2.Instance.num);
    }
}
