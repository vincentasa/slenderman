using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    
    void OnTriggerEnter(Collider other)
    {
        print("page collected");
        Destroy(other.gameObject);
        pages++;

        if (pages == 1)
        {
            enemy.target = transform;
        }
        
        if (pages == 2)
        {
            // slenderman speed times 2
            enemy.speed *= 2;
        }

        if (pages == 3)
        {
            // increase view distance
            enemy.viewDistance += 3;
        }
        
        if (pages == 4)
        {
            // viewdistance + speed
            enemy.viewDistance += 15;
            enemy.speed *= 1.25f;
        }
        
        if (pages == 5)
        {
            // u cant hide
            enemy.viewDistance += 1000;
            enemy.speed *= 2f;
        }
    }
}
