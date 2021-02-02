using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 여기선 where절 뒤에 MonoSingleton2<MSingleton1>, MSingleton1 다 가능.
public class MonoSingleton2<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance = null;
    private static GameObject _singletonGameObject;

    public static T instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = SingletonGameObject.GetComponent<T>();
            if (_instance != null) return _instance;
            _instance = SingletonGameObject.AddComponent<T>();
            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }

    private static GameObject SingletonGameObject
    {
        get
        {
            if(!_singletonGameObject)
            {
                _singletonGameObject = new GameObject("Singleton Script");
            }
            return _singletonGameObject;
        }
        set
        {
            _singletonGameObject = value;
        }
    }
    public void Test1()
    {
        Debug.Log(123);
    }
}
