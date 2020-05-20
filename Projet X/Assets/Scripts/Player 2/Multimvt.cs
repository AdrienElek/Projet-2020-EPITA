using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: Mathis Guilbaud

public class Multimvt : MonoBehaviour
{
	[SerializeField] private float movespeed = 8f;
	[SerializeField] private float dashforce = 10f;
	private Rigidbody2D rb;
	private Animator anim;
	[SerializeField] private GameObject projectile;
	[SerializeField]private Transform shootpos;
	[SerializeField] private float shootspeed = 20f;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	private void Move()
	{
		if (Input.GetAxisRaw("Horizontal2") > 0.5f || Input.GetAxisRaw("Horizontal2") < -0.5f) {
			rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal2") * movespeed * Time.deltaTime,rb.velocity.y);
		}
		if (Input.GetAxisRaw("Vertical2") > 0.5f || Input.GetAxisRaw("Vertical2") < -0.5) {
			rb.velocity = new Vector2(rb.velocity.x,Input.GetAxisRaw("Vertical2") * movespeed * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Horizontal2") < 0.5f && Input.GetAxisRaw("Horizontal2") > -0.5f)
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
		if (Input.GetAxisRaw("Vertical2") < 0.5f && Input.GetAxisRaw("Vertical2") > -0.5)
		{
			rb.velocity = new Vector2(rb.velocity.x, 0f);
		}
	}

	void Shoot()
	{
		Quaternion rot = Quaternion.Euler(0,0,0);
		if (Input.GetKey(KeyCode.RightArrow)) rot = Quaternion.Euler(0,0,-90);
		if (Input.GetKey(KeyCode.LeftArrow)) rot = Quaternion.Euler(0,0,90);
		if (Input.GetKey(KeyCode.DownArrow)) rot = Quaternion.Euler(0,0,180);
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) rot = Quaternion.Euler(0, 0, -45);
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) rot = Quaternion.Euler(0, 0, 45);
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) rot = Quaternion.Euler(0, 0, -135);
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) rot = Quaternion.Euler(0, 0, 135);
		shootpos.rotation = rot;
		if (Input.GetKeyDown(KeyCode.M))
		{

			
			float x = Input.GetAxisRaw("Horizontal2") * shootspeed;
			float y = Input.GetAxisRaw("Vertical2") * shootspeed;
			if (x == 0 && y == 0) {
				x = 0;
				y = shootspeed;
			}

			GameObject proj = Instantiate(projectile, shootpos.position, shootpos.rotation);
			BoxCollider2D projbc = proj.GetComponent<BoxCollider2D>();
			Rigidbody2D projrb = proj.GetComponent<Rigidbody2D>();
			projrb.velocity = new Vector2(x, y);
			Destroy(proj, 5);
		}

	}
	


	// Update is called once per frame
	void Update()
	{
		anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal2"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical2"));
		Move();
		Shoot();
	
	}

}
