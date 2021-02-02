using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


class TestGenericClass<T>
{
    public TestGenericClass(T value)
    {
        Value = value;
    }
    public T Value { get; set; }
}
public class GenericTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestGenericClass<Int32> intClass = new TestGenericClass<Int32>(12345);
        TestGenericClass<string> stringClass = new TestGenericClass<string>("12345");
        TestGenericClass<Boolean> boolClass = new TestGenericClass<Boolean>(true);

        Debug.Log("클래스의 이름");
        Debug.LogFormat("\tIntClass : {0}", intClass.GetType());
        Debug.LogFormat("\tstringClass : {0}", stringClass.GetType());
        Debug.LogFormat("\tboolClass : {0}", boolClass.GetType());

        Debug.Log("Value 속성의 반환 값");
        Debug.LogFormat("\tIntClass : {0} (형식: {1}",intClass.Value, intClass.GetType());
        Debug.LogFormat("\tstringClass : {0} (형식: {1}", stringClass.Value, stringClass.GetType());
        Debug.LogFormat("\tboolClass : {0} (형식: {1}", boolClass.Value, boolClass.GetType());
    }
}
