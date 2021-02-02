using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonoSingleton1 : MonoBehaviour
{
    public static MonoSingleton1 instance { get; private set; }
    int count;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
        {
            Destroy(instance);
            return;
        }
        DontDestroyOnLoad(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MonosingleTon1");
    }

    public void AAA()
    {
        Debug.Log(++count);
        SceneManager.LoadScene("MonosingleTon2");
    }
}
