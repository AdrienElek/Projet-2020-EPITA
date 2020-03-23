using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstanciateRoom : MonoBehaviour
{
    public GameObject[] wall;
    public GameObject[] ground; //sol à faire spawn
    public GameObject[] perpective;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRoom(char[,] roomToInstanciate)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector2 posToInstanciate = new Vector2(i,j);
                transform.position = posToInstanciate;
                
                if (roomToInstanciate[i,j] == 'W')
                {
                    int rand = Random.Range(0, wall.Length);
                    GameObject instanceGround = Instantiate(wall[rand], transform.position, Quaternion.identity);
                }
                else if (roomToInstanciate[i,j] == 'n') //si il n'y a rien, alors on instancie du sol
                {
                    int rand = Random.Range(0, ground.Length);
                    GameObject instanceGround = Instantiate(ground[rand], transform.position, Quaternion.identity);
                }
                else
                {
                    throw new ArgumentException("Un objet de la room à un type inconnue");
                }
            }
        }
    }
}
