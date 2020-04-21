using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimvt : MonoBehaviour
{
	[SerializeField]private float movespeed = 10f;
	[SerializeField]private float dashforce = 20f;
	private Rigidbody2D rb;

	[SerializeField]private GameObject projectile;
	[SerializeField]private Transform shootpos;
	[SerializeField]private float shootspeed = 20f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Move()
	{
		float moverg = Input.GetAxisRaw("Horizontal2");
		float movehb = Input.GetAxisRaw("Vertical2");
		transform.Translate(new Vector2(moverg * movespeed * Time.deltaTime,movehb * movespeed * Time.deltaTime));
	}

	void Shoot() {
		if (Input.GetKeyDown(KeyCode.M)) {

			GameObject proj = Instantiate(projectile,shootpos);
			proj.transform.Translate(Vector2.up *  shootspeed );
		}
	}

    // Update is called once per frame
    void Update()
    {
		Move();
    }
}
