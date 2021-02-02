using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MSingleton1 AAA = MSingleton1.instance;
        AAA.Test2();
        //AAA.Test1();
        /*
             주의 : MSingleton1의 Start()보다 이 함수가 먼저 호출된다.
             즉, 유니티 라이프사이클 보다 먼저 호출된다.. 
             따라서 우리가 생각하는 라이프사이클은 보장 받을수 없다.
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
