using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
	[SerializeField] private Transform targetCamera;
	[SerializeField] private Vector3 offset;
	[SerializeField] private Vector3 startPosition;

	private bool isGameStarted;
	private void OnEnable()
	{
		isGameStarted = false;
		StartMenuController.OnGameStart += SetStart;
	}
	private void OnDisable()
	{
		StartMenuController.OnGameStart -= SetStart;
	}
	private void Update()
	{
		Follow();
	}
	private void Follow()
	{
		if (targetCamera == null) return;
		if (!isGameStarted)
		{
			transform.position = startPosition;
		}
		else
		{
			transform.position = targetCamera.position + offset;
		}		
	}
	private void SetStart()
	{
		isGameStarted = isGameStarted != true;
	}
}
