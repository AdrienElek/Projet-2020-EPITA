using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mathis Guilbaud
public class MultiArrow : MonoBehaviour
{
	private BoxCollider2D bc;
	private Rigidbody2D rb;
	[SerializeField] private GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
    }


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.GetComponent<EnemySlimeController>().Death();
			Destroy(instance);
		}


	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
