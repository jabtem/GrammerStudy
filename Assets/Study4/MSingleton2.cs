using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSingleton2 : MonoSingleton3<MSingleton2>
{
    public override void Init()
    {
        Debug.Log(123);
    }

    public override void Test()
    {
        Debug.Log(456);
    }
}
