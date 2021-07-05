using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D selfRigidbody;
	[SerializeField] private Transform enemyImage;
    [SerializeField] private float moveSpeed = 2f;

	private bool isMoveRight;
	private Quaternion reversalRotation;
	private Quaternion basicRotation;

	private void Start()
	{
		reversalRotation = Quaternion.Euler(0, -180, 0);
		basicRotation = Quaternion.Euler(0, 0, 0);
	}

	private void Update()
	{
		Movement();
	}
	private void Movement()
	{

		if (isMoveRight == true)
		{
			selfRigidbody.transform.Translate(moveSpeed * Time.fixedDeltaTime * Vector2.right);
			enemyImage.transform.rotation = reversalRotation;
		}
		else
		{
			selfRigidbody.transform.Translate(moveSpeed * Time.fixedDeltaTime * Vector2.left);
			enemyImage.transform.rotation = basicRotation;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			isMoveRight = isMoveRight != true;
		}
	}
	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
