using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Rigidbody2D rb;
    Vector2 mouvement;
    float moveSpeed = 5f;
    
    /*
    public Camera cam;
    Vector2 mousePos;
    */
    /*
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = starDashTime;
    }

    */

    // Update is called once per frame
    void Update()
    {
        Mouvement();
       // MousePosition();
    }
    
        
    private void Mouvement()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
         
    }
    /*
    private void MousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    */


    void FixedUpdate()
    {
        MouvementUpdate();
        //LookDirection();

    }
    
    private void MouvementUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.fixedDeltaTime) ;
    }
    
    /*
    private void LookDirection()
    {
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    */
}
