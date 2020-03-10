using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Rigidbody2D rb;
    Vector2 mouvement;
    float moveSpeed = 5f;
    
    public Camera cam;
    Vector2 mousePos;
    
    private bool isAlive;
    private int hp;
    private int maxHp;
    
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp > maxHp)
            {
                hp = maxHp;
            }

            if (hp < 0)
            {
                isAlive = false;
                hp = 0;
            }
        }

    }

    private float torch;

    public float Torch
    {
        get => torch;
        set
        {
            torch = value;
            if (torch < 0)
            {
                torch = 0;
            }

            if (torch > 100)
            {
                torch = 100;
            }
        }
    }

    private float stamina;

    public float Stamina
    {
        get => stamina;
        set
        {
            stamina = value;
            if (stamina > 100)
            {
                stamina = 100;
            }
        }
    }

    private bool shot;
    public bool Shot
    {
        get => shot;
        set
        {
            if (stamina >= 10)
            {
                stamina -= 10;
                shot = true;
            }
            else
            {
                shot = false;
            }
        }
    }

    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;

    private bool dash;
    public bool Dash
    {
        get => dash;
        set
        {
            if (stamina >= 40)
            {
                stamina -= 40;
                dash = true;
            }
            else
            {
                dash = false;
            }
        }
    }
    
    

    private bool spell;
    public bool Spell
    {
        get => spell;
        set
        {
            if (stamina >= 40)
            {
                stamina -= 40;
                spell = true;
            }
            else
            {
                spell = false;
            }
        }
    }

    private int switchSpell;

    public int SwitchSpell
    {
        get => switchSpell;
        set
        {
            if (switchSpell < 0)
            {
                switchSpell = (switchSpell + 3) % 3;
            }
            else
            {
                switchSpell %= 3;
            }
        }
    }

    public int point = 0; //Score

    public void TorchUpdate()
    {
        if (Input.GetKey(KeyCode.U))
        {
            torch--;
        }
        if (Input.GetKey(KeyCode.I))
        {
            torch++;
        }
    }
    
    public bool ShotUpdate()
    {
        if (Input.GetKey(KeyCode.H) && shot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool dashUpdate()
    {
        if (Input.GetKey(KeyCode.J) && dash)
        {
            return true;
        }
        else
        {
            return false;
        }
        // J
    }
    
    public bool spellUpdate()
    {
        if (Input.GetKey(KeyCode.K) && spell)
        {
            return true;
        }
        else
        {
            return false;
        }

        // K
    }
    public void SwitchSpellUpdate()
    {
        if (Input.GetKey(KeyCode.O))
        {
            switchSpell--;
        }

        if (Input.GetKey(KeyCode.P))
        {
            switchSpell++;
        }
        
    }







    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = starDashTime;
    }


    // Update is called once per frame
    void Update()
    {
        Mouvement();
        MousePosition();
    }
    
        
    private void Mouvement()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
         
    }
    private void MousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    void FixedUpdate()
    {
        MouvementUpdate();
        LookDirection();

    }

    private void MouvementUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.fixedDeltaTime) ;
    }

    private void LookDirection()
    {
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
