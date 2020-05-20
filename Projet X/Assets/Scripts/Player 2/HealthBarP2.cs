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
			 Val = Mathf.Clamp(value,0,max);
			if (Bar != null) {
				Bar.fillAmount = (1 / max) * Val;
			}
		}
	}

    void Start()
    {
		Bar = GetComponent<Image>();
    }


}
