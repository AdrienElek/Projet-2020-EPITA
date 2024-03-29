﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//AUTHOR: Mathis Guilbaud

public class connection : MonoBehaviour
{
	private string player_name = ""; //Todo: remplacer par PlayerStat.playerName -> Boulot de Adrien/Léo
	private int score = PlayerStat.score;
	public bool playeragree = false; 

	public void callsendscore() {
		StartCoroutine(Sendscore());
			
	}

	IEnumerator Sendscore()
	{
		WWWForm form = new WWWForm();
		form.AddField("player_name", player_name);
		form.AddField("score", score);
		UnityWebRequest www = UnityWebRequest.Post("http://www.projets2dungeon.site/score.php", form);
		yield return www;
		if (www.isHttpError || www.isNetworkError)
		{
			Debug.Log("score send failed with error code: " + www.error);
		}
		else {
			Debug.Log("score sended successfully");
		}
	}

	private void Update()
	{
		if (playeragree)
		{
			callsendscore();
			playeragree = false;
		}
	}
}
