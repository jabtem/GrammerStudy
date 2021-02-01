using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideStudy : MonoBehaviour
{
    public class Player
    {
        internal virtual void ItemUse()
        {
            Debug.Log("Potion Use");
        }
    }

    class GunPlayer : Player
    {
        internal override void ItemUse()
        {
            Debug.Log("Item Use");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player player1 = new Player();
        Player player2 = new GunPlayer();

        GunPlayer player3 = new GunPlayer();

        player1.ItemUse();
        player2.ItemUse();
        player3.ItemUse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
