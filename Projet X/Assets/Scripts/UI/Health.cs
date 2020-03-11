using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 5;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
