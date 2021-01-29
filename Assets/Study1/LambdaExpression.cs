using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaExpression : MonoBehaviour
{
    delegate int DelegateMethod(int a, int b);
    DelegateMethod method = null;

    public int ia, ib;
    public bool menu;
    public char[] chNums;
    public bool result;

    // Start is called before the first frame update
    void Start()
    {
        result = false;
        Debug.Log("A =>덧셈,B =>뺄셈, C =>곱셈, D =>나눗셈, E =>나머지, Q => 끝");
        Debug.Log("선택?");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && result)
        {
            StartCoroutine(this.Result());
        }
        else if(Input.anyKeyDown && !result)
        {
            StartCoroutine(this.Calculator());
        }
    }
    IEnumerator Calculator()
    {
        //인덱스 , 길이만큼 배열에서 문자를입력받음
        chNums = Input.inputString.ToCharArray(0, 1);

        while(!menu)
        {
            switch(chNums[0])
            {
                case 'A':
                case 'a':
                    method = ( a,  b) => { return a + b; };
                    menu = true;
                    result = true;
                    break;
                case 'B':
                case 'b':
                    method = (a, b) => { return a - b; };
                    menu = true;
                    result = true;
                    break;
                case 'C':
                case 'c':
                    method = (a, b) => { return a * b; };
                    menu = true;
                    result = true;
                    break;
                case 'D':
                case 'd':
                    method = (a, b) => { return a / b; };
                    menu = true;
                    result = true;
                    break;
                case 'E':
                case 'e':
                    method = (a, b) => { return a % b; };
                    menu = true;
                    result = true;
                    break;
                case 'Q':
                case 'q':
                    Debug.Log("종료");
                    menu = true;
                    result = false;
                    Application.Quit();
                    yield break; //코루틴 빠져나감
                default:
                    Debug.Log("다시 입력하세요 ");
                    menu = true;
                    result = false;
                    break;

            }
        }
        if(result == false)
        {
            menu = false;
        }
        yield return null;
    }
    IEnumerator Result()
    {
        Debug.Log(method(ia, ib));
        menu = false;
        result = false;
        Debug.Log("A => 덧셈, B => 뺄셈, C => 곱셈, D => 나눗셈, E => 나머지, Q => 끝 ");
        Debug.Log("선택?");
        yield return null;
    }

    //C#변천사
    //대리자(Delegate)
    private int Cal_add(int a, int b)
    {
        return a + b;
    }
    //함수포인터의역할
    delegate int Func1(int a, int b);

    private void Use1()
    {

        Func1 func1 = Cal_add;
        int t1 = func1(100, 100);
    }
    //무명메소드
    delegate int Func2(int a, int b);
    private void Use2()
    {
        Func2 func2 = delegate (int a, int b)
        {
            return a + b;
        };

        int t2 = func2(100, 100);
    }
    //람다식
    delegate int Func3(int a, int b);
    private void Use3()
    {
        Func3 func3 = (a, b) => { return a + b; };
        int t3 = func3(100, 100);
    }
}
