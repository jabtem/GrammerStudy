using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  C#에서는 abstract 키워드를 사용하여 클래스를 정의하여 상속을 통해서만
 *  사용할 수 있는 기반 클래스를 만들 수 있다. 이 클래스를 추상 클래스라 한다.
 *  추상 클래스는 객체를 생성할 수 없으며 단지 상속을 통해 기반 클래스 역할만 함.
 * 
 */

//추상클래스
abstract class Sword1
{
    public Sword1()
    {
        Debug.Log("Sword1 생성자");
    }
    public void Attack()
    {
        Debug.Log("Swing1");
    }
    ~Sword1()
    {
        Debug.Log("Sword1 소멸자");
    }
}

abstract class Sword2
{
    //추상 메소드
    public abstract void Attack();
    public Sword2()
    {
        Debug.Log("Sword1 생성자");
    }
    ~Sword2()
    {
        Debug.Log("Sword1 소멸자");
    }
}

class Man1 : Sword1
{
    public Man1()
    {
        Debug.Log("Man1 생성자");
    }
    ~Man1()
    {
        Debug.Log("Man1 소멸자");
    }
}
class Man2 : Sword2
{
    //추상메소드는 재정의해야 사용할수잇다
    public override void Attack()
    {
        Debug.Log("Swing2");
    }
}
public class csAbstract : MonoBehaviour
{
    //레퍼런스 선언
    Sword1 sword;
    Man1 man1;
    Man2 man2;

    // Start is called before the first frame update
    void Start()
    {
        man1 = new Man1();
        man2 = new Man2();

        man1.Attack();
        man2.Attack();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
