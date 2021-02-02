using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDictionaryStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Hashtable ht = new Hashtable();

        //ht.Add("홍", "율");
        //ht.Add("장", "이");

        //foreach (DictionaryEntry d in ht)
        //{
        //    Debug.Log(d.Key);
        //    Debug.Log(d.Value);
        //    Debug.Log(d.Key.ToString() + d.Value);
        //}

        //Hashtable ht2 = new Hashtable();

        //ht2["홍"] = "율";
        //ht2["장"] = "이";
        //ht2["홍"] = "대";

        //foreach(DictionaryEntry d in ht2)
        //{
        //    Debug.Log(d.Key);
        //    Debug.Log(d.Value);
        //    Debug.Log(d.Key.ToString() + d.Value);
        //}

        //Hashtable ht3 = new Hashtable();

        //ht3["홍"] = "율";
        //ht3["장"] = "이";
        //ht3["김"] = "대";

        //ht3.Remove("홍");

        //foreach (DictionaryEntry d in ht3)
        //{
        //    Debug.Log(d.Key);
        //    Debug.Log(d.Value);
        //    Debug.Log(d.Key.ToString() + d.Value);
        //}


        Hashtable ht4 = new Hashtable();

        ht4["홍"] = "율";
        ht4["장"] = "이";


        Debug.Log(ht4.Contains("홍"));
        Debug.Log("키 항목");
        foreach (string s in ht4.Keys)

        {

            Debug.Log("    " + s);

        }

        Debug.Log("값 항목");

        foreach (string s in ht4.Values)

        {

            Debug.Log("    " + s);

        }
        foreach (DictionaryEntry d in ht4)
        {
            Debug.Log("    " + d.Key + d.Value);
        }

        IDictionaryEnumerator ide = ht4.GetEnumerator();

        while(ide.MoveNext())
        {
            //0 : key, 1: value
            Debug.Log(string.Format("info{0} : {1}", ide.Key, ide.Value));
        }
    }

}
