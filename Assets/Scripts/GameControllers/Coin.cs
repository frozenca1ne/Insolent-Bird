using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] private int coinValue = 1;


	private void OnCollisionEnter2D(Collision2D collision)
	{
	
		if (collision.gameObject.CompareTag("Bird"))
		{
			var helper = new ScoreHelper();
			helper.CurrentCoinsEarn += coinValue;
			Destroy(gameObject);
		}
	}
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
