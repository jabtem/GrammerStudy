using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMsingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MSingleton2.Instance.Test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
