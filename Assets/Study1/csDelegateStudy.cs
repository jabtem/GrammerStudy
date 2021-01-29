using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDelegateStudy : MonoBehaviour
{
    delegate void CallNumDelegate1(int num);
    delegate int CallNumDelegate2(int num1, int num2);

    CallNumDelegate1 calNum1;

    // Start is called before the first frame update
    void Start()
    {
        calNum1 = OnePlusNum;
        calNum1(4);

        calNum1 = PowerNum;
        calNum1(5);

        calNum1 = new CallNumDelegate1(OnePlusNum);
        calNum1(4);

        calNum1 = new CallNumDelegate1(PowerNum);
        calNum1(5);

        //람다식
        CallNumDelegate2 calNum2;

        calNum2 = (int num1, int num2) => { return num1 * num2; };
        Debug.Log(calNum2(7, 7));
        calNum2 = (int num1, int num2) => (num1 * num2);
        Debug.Log(calNum2(7, 7));
        calNum2 = (num1, num2) => (num1 * num2);
        Debug.Log(calNum2(7, 7));
        calNum2 = (num1, num2) => num1 * num2;
        Debug.Log(calNum2(7, 7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnePlusNum(int num)
    {
        int result = num + 1;
        Debug.Log("One Plus = " + result);
    }
    void PowerNum(int num)
    {
        int result = num + num;
        Debug.Log("Power Num = " + result);
    }
}
