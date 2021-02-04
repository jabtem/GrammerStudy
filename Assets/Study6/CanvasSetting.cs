using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : MonoBehaviour
{
    Canvas canvas;
    public int sortingOrder;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.sortingLayerName = "FOREGROUND";
        canvas.sortingOrder = sortingOrder;
    }
}
