using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class csDelegateButtStudy : MonoBehaviour
{

    public GameObject obj;

    void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("BUTTON");
    }
    // Start is called before the first frame update
    void Start()
    {
        obj.GetComponent<Button>().onClick.AddListener(delegate { OnClickButton("버튼이벤트동적할당"); });
    }

    void OnClickButton(string name)
    {
        Debug.Log(name);
    }
}
