using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//AUTHOR LEO FERRETTI//ADRIEN LORGE

public class PlayerStat : MonoBehaviour
{
    public bool isAlive = true;
    public Slider slider;
    public static int hp = 100;
    public static int maxHp = 100;
    private Objects.Objects[] inventaire = new Objects.Objects[6];
    private int mainObject =0;
    internal static string playerName;
    private static int exhp = 0;

    

    public void Use(ref PlayerStat player)
    {
        if (!(inventaire[mainObject] is null))
        {
            inventaire[mainObject].Use(ref player);
        }
        
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
                hp = 0;
            }
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

    //int ammo pour le nb de munition restantes 
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
        slider.maxValue = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp!=exhp)
        {
            slider.value = hp;
            exhp = hp;
        }

    }

    public static void TakeDamage(int damage)
    {
        Debug.Log("Hp : " + hp.ToString());
        Debug.Log("Degats pris : " +damage.ToString());
        hp -= damage;
        Debug.Log("Hp : "+hp.ToString());
        
    }
    
}
