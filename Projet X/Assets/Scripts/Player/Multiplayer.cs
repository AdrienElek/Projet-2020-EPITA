using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    public Transform Spawn1;
    public Transform Spawn2;


    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(Player1, Spawn1.position, Spawn1.rotation);
       // Instantiate(Player2, Spawn2.position, Spawn2.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
