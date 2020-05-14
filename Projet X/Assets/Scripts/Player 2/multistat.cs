using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multistat : MonoBehaviour
{
	private int maxhp;
	private Rigidbody2D rb;
	private GameObject instance;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		instance = GetComponent<GameObject>();
	}

	private int Hp
	{
		get => Hp;
		set
		{
			if (value < 0)
			{
				Hp = 0;
			}
			else if (value > maxhp) Hp = maxhp;
			else Hp = value;
		}
	}
	private int Damage
	{
		get => Damage;
		set => Damage = value;
	}
	public void Takedamage(int damage) {
		Hp -= damage;
		if (Hp == 0) Destroy(instance);
	}
	
}
