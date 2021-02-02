using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csVarStudy : MonoBehaviour
{
    int[] aaa;
    // Start is called before the first frame update
    void Awake()
    {
        //무명형식
        //한번쓰고 사라지는 변수에 사용하면 좋다 auto와 비슷함
        var myinstance = 3;
        Debug.Log(myinstance);

        myinstance = (int)4.5f;
        Debug.Log(myinstance);

        aaa = new int[] { 100, 90, 80, 70 };
        Debug.Log(string.Format("1 {0}, 2 {1}, 3 {2}, 4 {3}", aaa[0], aaa[1], aaa[2], aaa[3]));
    }

    void Start()
    {
        var myinstance1 = new { Name = "홍길동", Age = 28 };
        Debug.Log(myinstance1.Name + "," + myinstance1.Age.ToString());

        myinstance1 = new { Name = "우상준", Age = 100 };
        Debug.Log(myinstance1.Name + "," + myinstance1.Age.ToString());

        //값을변경하고싶다면 배열을사용하면 가능함
        var myInstance2 = new { Subject = "수학", Scores = new int[] { 100, 90, 80, 70 } };
        Debug.Log(myInstance2.Subject + "," + myInstance2.Scores[0].ToString());

        //형식을 신경쓰지않아도되서 편리함 (auto와 같은 장점)
        foreach(var score in myInstance2.Scores)
        {
            Debug.Log(score);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
