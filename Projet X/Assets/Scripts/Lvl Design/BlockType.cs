using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class BlockType : MonoBehaviour
{
    public BType type;
    
    public enum BType
    {
        WALL,
        PERSPECTIVE,
        GRASS,
        WATER,
        DIRT,
    }

    public BType getType()
    {
        return type;
    }
    
    public void BlockDestruction()
    {
        Destroy(gameObject);
    }
}