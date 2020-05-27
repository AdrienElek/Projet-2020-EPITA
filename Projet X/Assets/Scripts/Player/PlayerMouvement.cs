using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using UnityEngine.UI;
// Leo Ferretti

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Rigidbody2D rb;
    
    Vector2 mouvement;
    
    float moveSpeed = 5f;
    
    public PlayerStat Player;

    public GameObject player1BulletPrefab;
    
    public float bulletSpeed;

    private float lastBullet;

    public float bulletDelay;


	[SerializeField] private Camera CamP1;
    

    

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        canShoot();
        Use();

		if (!multistat.IsAlive || InstanciateMatrice.nombreJoueur == 1) {
			CamP1.rect = new Rect(0, 0, 1, 1);
		}
    }
    
        
    private void Mouvement()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
         
    }

    private void canShoot()
    {
        float bulletHorizontal = Input.GetAxis("HorizontalShoot");
        float bulletVertical = Input.GetAxis("VerticalShoot");

        if ((bulletHorizontal != 0 || bulletVertical != 0) && Time.time > lastBullet + bulletDelay )
        {
            Shoot(bulletHorizontal, bulletVertical);
            lastBullet = Time.time;
            

        }
        
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(player1BulletPrefab, transform.position, transform.rotation);
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity =
            new Vector3(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                0);


    }


    private void Use()
    {
        if (Input.GetButton("Fire1"))
        {
            Player.Use(ref Player);
        }
    }


    void FixedUpdate()
    {
        MouvementUpdate();

    }
    
    private void MouvementUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.fixedDeltaTime) ;
    }
    
}
