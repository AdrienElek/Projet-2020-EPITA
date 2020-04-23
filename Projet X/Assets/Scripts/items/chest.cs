using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: Mathis Guilbaud

public class chest : MonoBehaviour
{
	[SerializeField] private GameObject Chest;
	[SerializeField] private Transform pos;
	[SerializeField] private GameObject[] obj = new GameObject[2];
	public int Hp = 3;

	GameObject Content() {
		int x = Random.Range(0, obj.Length);
		return obj[x];
	}

	private void Update()
	{
		if (Hp <= 0) {
			Destroy(Chest);
			Instantiate(Content(),pos.position,pos.rotation);
		}
	}
}
