using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

	private void FixedUpdate()
	{
		Follow();
	}
	
	private void Follow()
	{
		if (target == null) return;
		Vector3 newPosition = target.position + offset;
		newPosition.x = transform.position.x;
		transform.position = newPosition;
	}
}

