using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class RoomType : MonoBehaviour
{
    public int type; //le type d'une room est son orientation de sorti (0,1,2,3)

    public void RoomDestruction() //detruit le GameObject ciblé
    {
        Destroy(gameObject);
    }
}
