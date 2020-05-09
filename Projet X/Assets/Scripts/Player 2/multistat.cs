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
			if (hp < 0) Destroy(instance);
			else if (hp > maxhp) hp = maxhp;
		}
	}
	private int damage {
		get {
			return damage;
		}
	}
	
}
