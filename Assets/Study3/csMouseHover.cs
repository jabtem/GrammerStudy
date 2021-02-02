using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class csMouseHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    //현재 컴포넌트를 가리킬 인스턴스
    public static csMouseHover instance = null;

    public bool isUIHover = false;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isUIHover = true;
        Debug.Log(isUIHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isUIHover = false;
        Debug.Log(isUIHover);
    }
}
