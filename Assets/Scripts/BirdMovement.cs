using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D selfRigidbody;
	[SerializeField] private Transform birdImage;
	[Header("Jump")]
	[SerializeField] private float jumpAmount = 10f;
	[SerializeField] private float jumpDuration = 2f;
	[Header("Move")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float moveDuration = 5f;

	private bool isMoveRight;
	private bool isSecondJump;
	private int jumpCount;
	private Quaternion reversalRotation;
	private Quaternion basicRotation;
	

	private void Start()
	{
		reversalRotation = Quaternion.Euler(0, -180, 0);
		basicRotation = Quaternion.Euler(0, 0, 0);
		isMoveRight = true;
		isSecondJump = false;
	}

	private void Update()
	{
		Jump();
		Movement();
	}
	
	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (isSecondJump) return;
			var currentY = transform.position.y;
			selfRigidbody.transform.DOMoveY(currentY + jumpAmount, jumpDuration);
			jumpCount++;
			if(jumpCount >= 1)
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
	}
}
