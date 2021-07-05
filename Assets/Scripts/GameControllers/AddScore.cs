using UnityEngine;

public class AddScore : MonoBehaviour
{
	[SerializeField] private int point = 1;

	private bool isPointAdd;

	private void Start()
	{
		isPointAdd = false;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{	
		if (isPointAdd) return;
		if(collision.gameObject.CompareTag("Bird"))
		{
			var helper = new ScoreHelper();
			helper.CurrentScoreEarn += point;
			isPointAdd = true;
		}
	}
}
