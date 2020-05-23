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

	private void Start()
	{

		hp = maxhp;
		Bar.max = maxhp;
		Bar.val = maxhp;


	} 



	static HealthBarP2 Bar = new HealthBarP2();
	private static int maxhp = (int) PlayerStat.maxHp;
	private static int hp;
	public static int Hp
	{
		get { return hp; }
		set
		{
			if (value < 0)
			{
				hp = 0;
			}
			else if (value > maxhp) {
				hp = maxhp;
			}
			else hp = value;
			Bar.val = hp;
		}
	}
	private int damage;
	public int Damage
	{
		get { if (Random.Range(0, 10) == 5) return (damage * 2);
			else return damage;
		}
		set => damage = value;
	}
	

	public static void TakeDamage(int degat) {
		if (Random.Range(0, 10) == 10)
		{
			Hp -= degat * 2;
		}
		else
		{
			Hp -= degat;
		}
	}

	void Die() {
		if (hp == 0) {
			Destroy(instance);
			Debug.Log("Die method called");
		}
	}

	private void Update()
	{
		Die();
	}
	//fonction de test des degats
	/*
	void degat() {
		if (Input.GetKeyDown(KeyCode.P)) {
			Hp -= 10;
			Debug.Log(hp);
		}
	}
	private void Update()
	{
		degat();
	}
	*/
}
