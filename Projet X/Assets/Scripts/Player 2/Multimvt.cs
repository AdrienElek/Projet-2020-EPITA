using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimvt : MonoBehaviour
{
	[SerializeField] private float movespeed = 6f;
	[SerializeField] private float dashforce = 10f;
	private Rigidbody2D rb;

	[SerializeField] private GameObject projectile;
	private Transform shootpos;
	[SerializeField] private float shootspeed = 20f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		shootpos = GetComponent<Transform>();
	}
	private void Move()
	{
		float moverg = Input.GetAxisRaw("Horizontal2");
		float movehb = Input.GetAxisRaw("Vertical2");
		transform.Translate(new Vector2(moverg * movespeed * Time.deltaTime, movehb * movespeed * Time.deltaTime));

	}

	void Shoot()
	{


		if (Input.GetKeyDown(KeyCode.M))
		{

			float x;
			float y;

			/*if (rb.velocity.x > 0)
			{
				shootpos.Rotate(new Vector3(0, 0, 90));
			}
			else if (rb.velocity.x < 0) {
				shootpos.Rotate(new Vector3(0, 0, 270));
			}
			if (rb.velocity.y > 0) {
				shootpos.Rotate(new Vector3(0, 0, 0));
			}
			else if (rb.velocity.y < 0) {
				shootpos.Rotate(new Vector3(0,0,180));
			}*/

			if (Input.GetAxisRaw("Vertical2") == 0 || Input.GetAxisRaw("Vertical2") == 0)
			{
				x = 0;
				y = shootspeed;
			}
			else
			{
				x = Input.GetAxisRaw("Horizontal2") * shootspeed;
				y = Input.GetAxisRaw("Vertical2") * shootspeed;
			}

			GameObject proj = Instantiate(projectile, shootpos.position, shootpos.rotation);
			Rigidbody2D projrb = proj.GetComponent<Rigidbody2D>();
			projrb.velocity = new Vector2(x, y);
			Destroy(proj, 5);

		}
	}

	void Stopdash()
	{
		rb.velocity = new Vector2(0, 0);
	}

	void Dash()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal2") * dashforce, Input.GetAxisRaw("Vertical2") * dashforce);
			Invoke("Stopdash", 1);
		}
	}


	// Update is called once per frame
	void Update()
	{
		Move();
		Shoot();
		Dash();
	}
}
