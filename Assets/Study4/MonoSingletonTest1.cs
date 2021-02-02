using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonTest1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonoSingleton1.instance.AAA();
    }

}

/*
 
    MonoSingleton1 게임오브젝트에 MonoSingleton1 컴포넌트 활성화해보자.
    역시 치명적인 오류이다.

*/
