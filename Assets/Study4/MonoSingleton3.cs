using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MonoSingleton 클래스
// 마지막에 where T : MonoSingleton3<T> 이렇게 써도 된다. 잘 생각해보자...
// 어떤것이 더 좋은 표현일까?
public class MonoSingleton3<T> : MonoBehaviour where T: MSingleton2
{
    private static T _Instance = null;

    public static T Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(T)) as T;//이미 존재하는대상이있을때

                if(_Instance == null)//아예 아무것도 없을때
                {
                    Debug.Log(3);
                    //초기화가 2번이뤄짐
                    //_Instance = new GameObject("Singleton_" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    _Instance = new GameObject("Singleton_" + typeof(T).ToString()).AddComponent<T>();
                    //_Instance.Init();
                    Debug.Log(2);
                    DontDestroyOnLoad(_Instance);
                }
            }
            return _Instance;
        }
    }

    public static T IsExist()
    {
        if (_Instance)
            return _Instance;

        return null;
    }

    virtual protected void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
            Debug.Log(1);
            _Instance.Init();
        }
    }

    virtual protected void OnDestroy()
    {
        if (_Instance != null)
        {
            _Instance.Clear();
            _Instance = null;
        }
    }

    private void OnApplicationQuit()
    {
        _Instance = null;
    }

    public virtual void Init() { }
    public virtual void Clear() { }
    public virtual void Test() { }

}
