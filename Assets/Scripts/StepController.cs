using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StepController : MonoBehaviour
{
	[SerializeField] private Transform selfTransform;
	[SerializeField] private float shakedChangeDelay = 0.5f;

	private bool isShaked;

	private void OnEnable()
	{
		isShaked = true;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Bird"))
		{
			ShakeStep();
		}
	}
	private void ShakeStep()
	{
		if (!isShaked) return;
		var punchVector = new Vector2(0, -0.1f);
		selfTransform.DOPunchPosition(punchVector, 0.1f, 1);
		StartCoroutine(ChangeShakedState(shakedChangeDelay));
	}

	private IEnumerator ChangeShakedState(float delay)
	{
		isShaked = false;
		yield return new WaitForSeconds(delay);
		isShaked = true;
	}

}
