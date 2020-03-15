using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
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

    private int torch;

    public int Torch
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

    private int stamina;
    private int maxStamina;

    public int Stamina
    {
        get => stamina;
        set
        {
            stamina = value;
            if (stamina > maxStamina) 
            {
                stamina = maxStamina;
            }
        }
    }

    private int money;

    //int ammo pour le nb de munition restantes (si ya rien devant il le met automatiquement en private)
    //peut etre une fontion ou une variable à ajouter pour les coups critiques
    private bool shot;
    private int shotStamina;
    public bool Shot
    {
        get => shot;
        set
        {
            shot = value;
            if (stamina >= shotStamina)
            {
                stamina -= shotStamina;
                shot = true;
            }
            else
            {
                shot = false;
            }
        }
    }

    private int switchWeapon;
    private int weaponInventoryLength;
    
    public int SwitchShot
    {
        get => switchWeapon;
        set
        {
            switchWeapon = value;
            if (switchWeapon < 0)
            {
                switchWeapon = switchWeapon % weaponInventoryLength + weaponInventoryLength;
            }
            else
            {
                switchWeapon %= 3;
            }
        }
    }


    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;
    private int dashStamina;

    private bool dash;
    public bool Dash
    {
        get => dash;
        set
        {
            dash = value;
            if (stamina >= dashStamina)
            {
                stamina -= dashStamina;
                dash = true;
            }
            else
            {
                dash = false;
            }
        }
    }
    
    

    private bool spell;
    private int spellStamina;
    public bool Spell
    {
        get => spell;
        set
        {
            spell = value;
            if (stamina >= spellStamina)
            {
                stamina -= spellStamina;
                spell = true;
            }
            else
            {
                spell = false;
            }
        }
    }

    private int switchSpell;
    private int spellInventoryLength;

    public int SwitchSpell
    {
        get => switchSpell;
        set
        {
            switchSpell = value;
            if (switchSpell < 0)
            {
                switchSpell = switchSpell % spellInventoryLength + spellInventoryLength;
            }
            else
            {
                switchSpell %= spellInventoryLength;
            }    
        }
    }

    public int score = 0; //Score

    public void TorchUpdate()
    {
        if (Input.GetKey(KeyCode.J))
        {
            torch--;
        }
        if (Input.GetKey(KeyCode.U))
        {
            torch++;
        }
    }
    
    public bool ShotUpdate()
    {
        if (Input.GetKey(KeyCode.J) && shot)
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
        if (Input.GetKey(KeyCode.L) && dash)
        {
            return true;
        }
        else
        {
            return false;
        }
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

        
    }
    public void SwitchSpellUpdate()
    {
        if (Input.GetKey(KeyCode.O))
        {
            switchSpell++;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
