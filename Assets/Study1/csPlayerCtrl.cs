using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerCtrl : MonoBehaviour
{
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDie1()
    {
        Debug.Log("Player Die");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            enemy.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        }
    }
    public void PlayerDie2()
    {
        Debug.Log("Player Die");
        OnPlayerDie();
    }
}
