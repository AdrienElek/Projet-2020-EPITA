using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject instance = Instantiate(objects[rand], transform.position, Quaternion.identity);
        
        /* met les objets dans un dossier parent ici room -> si on RoomDestruction() une room, tout ses objets sont detruit
        -> evite les dead end */
        instance.transform.parent = transform;
    }
}