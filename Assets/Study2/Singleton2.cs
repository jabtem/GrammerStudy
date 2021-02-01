using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton2 : MonoBehaviour
{

    public GameObject assert;
    public int num = 100;
    private static Singleton2 _instance = null;

    public static Singleton2 Instance
    {
        get
        {
            // c# 일 경우....
            // _instance = new CSingleton();
            if (_instance == null)
                Debug.LogError("Singleton2 == null");

            return _instance;
        }

    }
    // Start is called before the first frame update
    void Awake()
    {
        //유니티의경우 C#방식사용시 MonoBehaviour로인해 동적생성이 안되 Awake에서 처리함
        _instance = this;
        Debug.Log(Instance);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Start()
    {
        Debug.Assert(assert);
    }
}
/*
         문제점 현재 게임오브젝트가 계속해서 쌓이고...
         Singleton2 _instance 레퍼런스는,
         벌써 메모리에 올라갔기 때문에 추가적으로 생성은 안되고,
         새롭게 생성된 객체의 인스턴스만 바꿔치기 됨.
         따라서 num 같은 새롭게 생성된 num 값이기 때문에 증가되지 않음.
         결국 값도 증가하지 않고 스텍이 계속 낭비되어서 게임이 느려지고 튕기게 됨.
         해결책은 오픈씬~
    */