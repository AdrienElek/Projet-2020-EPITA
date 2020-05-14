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

	private int hp {
		get {
			return hp;
		}
		set {
			if (value < 0) hp = 0;
			else if (value > maxhp) hp = maxhp;
			else hp = value;
		}
	}
	private int damage {
		get {
			return damage;
		}
		set {
			damage = value;
		}
	}
	public void takedamage(int damage) {
		hp -= damage;
		if (hp == 0) Destroy(instance);
	}
	
}
