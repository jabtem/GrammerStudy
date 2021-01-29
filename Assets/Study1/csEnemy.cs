using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour
{
    public bool isPlyaerDie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //이벤트연결
        csPlayerCtrl.OnPlayerDie += this.OnPlayerDie;
    }

    void OnDisable()
    {
        //이벤트해제
        csPlayerCtrl.OnPlayerDie -= this.OnPlayerDie;
    }

    void OnPlayerDie()
    {
        isPlyaerDie = true;
    }
}
