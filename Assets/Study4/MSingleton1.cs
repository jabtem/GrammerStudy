using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSingleton1 : MonoSingleton2<MSingleton1>
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AAA");
        Test1();
        
    }

    // Update is called once per frame
    public void Test2()
    {
        Debug.Log(345);
    }
}
