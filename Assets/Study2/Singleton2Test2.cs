using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton2Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton2.Instance.num += 1;
        Debug.LogError(Singleton2.Instance.num);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
