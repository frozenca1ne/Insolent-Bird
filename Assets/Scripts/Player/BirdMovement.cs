using UnityEngine;
using System;

public class BirdMovement : MonoBehaviour
{
	public static event Action OnDie;

	[SerializeField] private Animator animator;
	[SerializeField] private Rigidbody2D selfRigidbody;
	[SerializeField] private Collider2D selfCollider;
	[SerializeField] private Transform birdImage;
	[Header("Jump")]
	[SerializeField] private float jumpAmount = 10f;
	[Header("Move")]
	[SerializeField] private float moveSpeed = 5f;

	private bool isGameStarted;
	private bool isMoveRight;
	private bool isSecondJump;
	private int jumpCount;
	private Quaternion reversalRotation;
	private Quaternion basicRotation;


	private void OnEnable()
	{
		StartMenuController.OnGameStart += AllowMovemenet;
	}
	private void OnDisable()
	{
		StartMenuController.OnGameStart -= AllowMovemenet;
	}
	private void Start()
	{
		reversalRotation = Quaternion.Euler(0, -180, 0);
		basicRotation = Quaternion.Euler(0, 0, 0);
		isMoveRight = true;
		isSecondJump = false;
		isGameStarted = false;
	}

	private void Update()
	{
		if (!isGameStarted) return;
		Jump();
		Movement();
	}
	private void AllowMovemenet()
	{
		isGameStarted = isGameStarted != true;
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (isSecondJump) return;
			selfRigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
			jumpCount++;
			if(jumpCount >= 2)
			{
				isSecondJump = true;
			}
		}
	}
	private void Movement()
	{

		if(isMoveRight == true)
		{
			selfRigidbody.transform.Translate(Vector2.right * moveSpeed * Time.fixedDeltaTime);
			birdImage.transform.rotation = reversalRotation;
		}
		else
		{
			selfRigidbody.transform.Translate(Vector2.left * moveSpeed *  Time.fixedDeltaTime);
			birdImage.transform.rotation = basicRotation;
		}	
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Wall"))
		{
			isMoveRight = isMoveRight != true;
		}

		if(collision.gameObject.CompareTag("Step"))
		{
			isSecondJump = false;
			jumpCount = 0;
		}
		if(collision.gameObject.CompareTag("Enemy"))
		{
			Die();
		}
	}
	private void Die()
	{
		AllowMovemenet();
		selfCollider.enabled = false;
		animator.SetTrigger("Die");
		OnDie?.Invoke();
	}
}
