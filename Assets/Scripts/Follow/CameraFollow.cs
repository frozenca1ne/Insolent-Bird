using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
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

	private void FixedUpdate()
	{
		Follow();
	}
	
	private void Follow()
	{
		if (target == null) return;
		if(!isGameStarted)
		{
			transform.position = startPosition;
		}
		else
		{
			Vector3 newPosition = target.position + offset;
			newPosition.x = transform.position.x;
			transform.position = newPosition;
		}
		
	}
	private void SetStart()
	{
		isGameStarted = isGameStarted != true;
	}
}

