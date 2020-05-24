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
		[SerializeField] private float shootspeed = 30f;
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

        private void Consomme(ref PlayerStat Player)
        {
            Player.Hp += soin;
        }

        public void Attaque()
        {
			Quaternion rot = Quaternion.Euler(0, 0, 0);
			if (Input.GetKey(KeyCode.D)) rot = Quaternion.Euler(0, 0, -90);
			if (Input.GetKey(KeyCode.Q)) rot = Quaternion.Euler(0, 0, 90);
			if (Input.GetKey(KeyCode.S)) rot = Quaternion.Euler(0, 0, 180);
			if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.D)) rot = Quaternion.Euler(0, 0, -45);
			if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.Q)) rot = Quaternion.Euler(0, 0, 45);
			if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) rot = Quaternion.Euler(0, 0, -135);
			if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Q)) rot = Quaternion.Euler(0, 0, 135);
			projectilePoint.rotation = rot;



				float x = Input.GetAxisRaw("Horizontal2") * shootspeed;
				float y = Input.GetAxisRaw("Vertical2") * shootspeed;
				if (x == 0 && y == 0)
				{
					x = 0;
					y = shootspeed;
				}

				GameObject proj = Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
				BoxCollider2D projbc = proj.GetComponent<BoxCollider2D>();
				Rigidbody2D projrb = proj.GetComponent<Rigidbody2D>();
				projrb.velocity = new Vector2(x, y);
				Destroy(proj, 5);
		}
    }
}

