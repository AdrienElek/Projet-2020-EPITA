using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: Mathis Guilbaud

public class Multimvt : MonoBehaviour
{
	[SerializeField] private float movespeed = 8f;
	[SerializeField] private float dashforce = 10f;
	private Rigidbody2D rb;
	Vector2 move;
	[SerializeField] private GameObject projectile;
	[SerializeField]private Transform shootpos;
	[SerializeField] private float shootspeed = 20f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Move()
	{
		move.x = Input.GetAxisRaw("Horizontal2");
		move.y = Input.GetAxisRaw("Vertical2");
	}
	private void Mvtupdate() {
		rb.MovePosition(rb.position + move * movespeed * Time.fixedDeltaTime);
	}

	void Shoot()
	{
		shootpos.Rotate(new Vector3(0,0,90f * Input.GetAxis("Horizontal2")),Space.Self);

		if (Input.GetKeyDown(KeyCode.M))
		{

			float x = Input.GetAxisRaw("Horizontal2") * shootspeed;
			float y = Input.GetAxisRaw("Vertical2") * shootspeed;
			if (x == 0 && y == 0) {
				x = 0;
				y = shootspeed;
			}

			GameObject proj = Instantiate(projectile, shootpos.position, shootpos.rotation);
			Rigidbody2D projrb = proj.GetComponent<Rigidbody2D>();
			projrb.velocity = new Vector2(x, y);
			Destroy(proj, 5);
		}
	}


	void Dash()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal2") * dashforce, Input.GetAxisRaw("Vertical2") * dashforce));
		}
	}


	// Update is called once per frame
	void Update()
	{
		Move();
		Shoot();
		Dash();
	}
	private void FixedUpdate()
	{
		Mvtupdate();
	}
}
