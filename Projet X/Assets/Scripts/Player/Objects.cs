using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

//Author : Adrien Lorge

namespace Objects
{
    public class Objects : MonoBehaviour
    {
        public enum ObjectType
        {
            NONE, CONSOMABLES, WEAPON, ARMOR
        }
        
        
        
        
        
        //Tir repris du script Weapon, à vérifier
        public Transform projectilePoint;
        public GameObject projectilePrefab;
        //Repris de Arrows
        public float speed = 10f;
        //
        private int soin;
        //private int damage; La flèche est instanciée depuis Arrows avec damage fix (40)
        private ObjectType type;
        private string name;

        
        
        
        
        
        public Objects(string name, int soin, int damage, ObjectType type )
        {
            this.name = name;
            this.soin = soin;
            //this.damage = damage;
            this.type = type;
        }

        public void Use(ref PlayerStat Player)
        {
            switch (type)
            {
                case ObjectType.NONE:
                    break;
                case ObjectType.CONSOMABLES:
                    Consomme(ref Player);
                    break;
                case ObjectType.WEAPON:
                    Attaque();
                    break;
                case ObjectType.ARMOR:
                    Player.MaxHp += soin;
                    break;
            }
        }

        public void Consomme(ref PlayerStat Player)
        {
            Player.Hp += soin;
        }

        public void Attaque()
        {
            //Tir repris du script Weapon, à vérifier
            Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
            //
        }
    }
}

