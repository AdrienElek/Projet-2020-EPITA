using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multistat : MonoBehaviour
{
	private Rigidbody2D rb;
	private GameObject instance;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		instance = GetComponent<GameObject>();
	}
	private int hp;
	private int maxhp;
	public int Hp
	{
		get => hp;
		set
		{
			if (value < 0)
			{
				hp = 0;
			}
			else if (value > maxhp) hp = maxhp;
			else hp = value;
		}
	}
	private int damage;
	public int Damage
	{
		get => damage;
		set => damage = value;
	}

	
}
