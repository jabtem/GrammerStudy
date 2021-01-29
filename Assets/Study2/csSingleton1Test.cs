using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSingleton1Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton1.Instance.num = 10;

        Debug.LogWarning(Singleton1.Instance.num);
    }
}
