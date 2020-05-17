using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: mathis GUILBAUD

public class items : MonoBehaviour
{
	private GameObject self;
	private void Awake()
	{
		self = GetComponent<GameObject>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.F)) {
				//ajouter à l'inventaire
				Destroy(self);
			}
		}
	}

}
