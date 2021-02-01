using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csListStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Program1 test1 = new Program1();
        //test1.test1();
        //test1.test2();
        //test1.test3();

        Program2 test2 = new Program2();
        //test2.test1();

        Program3 test3 = new Program3();
        //test3.test1();
        test3.test2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class Program1
{
    public void test1()
    {
        List<int> number = new List<int>();

        number.Add(10);
        number.Add(20);
        number.Add(30);

        Debug.Log(number[0]);
        Debug.Log(number[1]);
        Debug.Log(number[2]);

        
        //number.Remove(10);//값을기준으로삭제
        number.RemoveAt(2);//인덱스기준으로삭제

        Debug.Log(number[0]);
        Debug.Log(number[1]);
        //Debug.Log(number[3]);

        int I = 20;
        if(number.Contains(I))
        {
            Debug.Log(I + "이 리스트에 존재함");
        }
    }

    public void test2()
    {
        List<string> list = new List<string>();

        list.Add("a");
        list.Add("b");
        list.Add("c");

        foreach(string it in list)
        {
            Debug.Log(it);
        }

        string key = "b";

        string result = list.Find(
            delegate (string data){ return (key == data); }
            );

        if(result !=null)
        {
            Debug.Log(result);
        }
    }

    public void test3()
    {
        List<int> sortList = new List<int>();
        sortList.Add(10);
        sortList.Add(3);
        sortList.Add(7);
        sortList.Add(1);
        sortList.Add(4);

        //sortList.Sort();
        //sortList.Reverse();

        sortList.Sort(delegate (int a, int b)
        {
            Debug.Log(a.CompareTo(b));
            return a.CompareTo(b);//오름차순
            //return b.CompareTo(a);//내림차순
        });

        foreach (int it in sortList)
        {
            Debug.Log(it);
        }


    }
    /*
    //이렇게 하면 더 간단함.

    List<int> sortList = new List<int>();
    sortList.Add(10);
    sortList.Add(3);
    sortList.Add(7);
    sortList.Add(1);
    sortList.Add(4);

    // 알아서 정렬 !!
    sortList.Sort();
    */
}


class Program2
{
   public void test1()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Compsognathus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Velociraptor");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Dilophosaurus");
        dinosaurs.Add("Gallimimus");
        dinosaurs.Add("Triceratops");

        Debug.Log(dinosaurs.Find(EndWithSaurus));
        dinosaurs.RemoveAll(EndWithSaurus);
        Debug.Log(dinosaurs.Count);

        dinosaurs.RemoveAll(
            delegate (string data)
            {
                return (data == "Velociraptor" || data == "Gallimimus");
            });
        Debug.Log(dinosaurs.Count);

        dinosaurs.Clear();
        Debug.Log(dinosaurs.Count);
    }
    private static bool EndWithSaurus(string s)
    {
        if((s.Length>5)&&(s.Substring(s.Length-6).ToLower() == "saurus"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /* C# string에서  Substring(StartIndex), Replace(문자변환), ToUpper(대문자), ToLower(소문자), Trim(공백제거)
     * 
     * Substring()은 인자로 전달되는 StartIndex 번째 자리부터 끝까지 제외한 나머지 문자를 자른다. 
     * string val = "t..t"; => val.Replace("t","^^"); => t..t 가 ^^..^^ 로 변환
     * string val = "abc" => val.ToUpper(); =>"ABC" 로 변환
     * string val = "     abc" => val.Trim(); => "abc" 로 변환
     * 
     * 
     */

}

class Program3
{
    public void test1()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Compsognathus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Velociraptor");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Dilophosaurus");
        dinosaurs.Add("Gallimimus");
        dinosaurs.Add("Triceratops");

        string searchPoint = "saurus";
        Debug.Log(dinosaurs.Find(
            delegate (string s)
            {
                if ((s.Length > 5) && (s.Substring(s.Length - 6).ToLower() == searchPoint))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }));
    }

    public void test2()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Compsognathus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Velociraptor");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Dilophosaurus");
        dinosaurs.Add("Gallimimus");
        dinosaurs.Add("Triceratops");

        string searchPoint = "saurus";
        List<string> dinoList = dinosaurs.FindAll(
            delegate (string s)
            {
                if ((s.Length > 5) && (s.Substring(s.Length - 6).ToLower() == searchPoint))
                {
                    return true;
                }
                else
                    return false;
            }
        );
        foreach(string _dino in dinoList)
        {
            Debug.Log(_dino);
        }
    }
}
