using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Leo Ferretti
public class ItemStat : MonoBehaviour
{
    public string item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (item == "bread")
            {
                
            }
            if (item == "fish")
            {
            }
            if (item == "armor")
            {

            }
            if (item == "boot")
            {
            }
        }
    }
}
