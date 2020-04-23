using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: mathis GUILBAUD

public class items : MonoBehaviour
{
	public GameObject objet;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player") {
			Destroy(objet);
		}
	}


}
