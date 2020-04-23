using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AUTHOR LEO FERRETTI
public class Weapon : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
        }
    }
}
