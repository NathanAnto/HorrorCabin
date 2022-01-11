using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float mMovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool mAirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask mWhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform mGroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform mCeilingCheck;							// A position marking where to check for ceilings

	const float K_GROUNDED_RADIUS = .2f; // Radius of the overlap circle to determine if grounded
	private bool mGrounded;            // Whether or not the player is grounded.
	const float K_CEILING_RADIUS = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D mRigidbody2D;
	private bool mFacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 mVelocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		mRigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = mGrounded;
		mGrounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(mGroundCheck.position, K_GROUNDED_RADIUS, mWhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				mGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (mGrounded || mAirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, mRigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			mRigidbody2D.velocity = Vector3.SmoothDamp(mRigidbody2D.velocity, targetVelocity, ref mVelocity, mMovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !mFacingRight) {
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && mFacingRight) {
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (mGrounded && jump && mRigidbody2D.velocity.y == 0)
		{
			// Add a vertical force to the player.
			mGrounded = false;
			mRigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		mFacingRight = !mFacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
