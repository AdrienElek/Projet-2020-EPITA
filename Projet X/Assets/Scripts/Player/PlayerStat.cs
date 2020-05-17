using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//AUTHOR LEO FERRETTI

public class PlayerStat : MonoBehaviour
{
    public bool isAlive;
    private int hp;
    private int maxHp;
    private Objects.Objects[] inventaire;
    private int mainObject;
    internal static string playerName;
    public Text healthText;//For UI health
    
    public PlayerStat (int hp,int maxHp)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        healthText.text = hp.ToString();
        isAlive = true;
        inventaire = new Objects.Objects[6];
        inventaire[0] = new Objects.Objects("Cailloux", 0, 0, Objects.Objects.ObjectType.WEAPON);
        mainObject = 0;

    }

    public void Use(ref PlayerStat player)
    {
        inventaire[mainObject].Use(ref player);
    }
    

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

            healthText.text = hp.ToString();
        }

    }

    public int MaxHp
    {
        get => maxHp;
        set => maxHp += value;
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

    private int money;

    //int ammo pour le nb de munition restantes (si ya rien devant il le met automatiquement en private)
    //peut etre une fontion ou une variable à ajouter pour les coups critiques

    private int switchWeapon;

    //TODO
    public int SwitchShot
    {
        get => switchWeapon;
        set
        {
            switchWeapon = value;
            if (switchWeapon < 0)
            {
                switchWeapon = switchWeapon % 6;
            }
            else
            {
                switchWeapon %= 3;
            }
        }
    }

    internal static int score = 0; //Score
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
