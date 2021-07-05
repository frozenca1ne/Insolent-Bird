using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
	[SerializeField] private Transform targetCamera;
	[SerializeField] private Vector3 offset;

	private void Update()
	{
		Follow();
	}
	private void Follow()
	{
		if (targetCamera == null) return;
		transform.position = targetCamera.position + offset;
	}
}
