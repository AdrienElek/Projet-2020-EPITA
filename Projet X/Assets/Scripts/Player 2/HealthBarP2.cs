using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarP2 : MonoBehaviour
{
	static Image Bar;
	public float max { get; set; }

	private float Val;

	public float val {
		get { return Val; }
		set {
			if (value > max)
			{
				Val = max;
			}
			else if (value < 0) {
				Val = 0;
			}
			if (Bar != null) Bar.fillAmount = (1 / max) * Val;
		}
	}

    void Start()
    {
		Bar = GetComponent<Image>();
    }


}
