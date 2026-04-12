using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	// The game controller keeping score
	public GameController GameManager;

	// The Rigidbody component attached to the player
	Rigidbody rb;

	// The movement input values along the X and Y axes
	float inputX;
	float inputY;

	// The speed at which the player will move
	public float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// Get and store the Rigidbody component attached to the player
		rb = GetComponent<Rigidbody> ( );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// Create a 3D vector using the X and Y input values
		Vector3 movement = new Vector3 ( inputX, 0f, inputY );

		// Apply a physics force to the Rigidbody to move the player
		rb.AddForce ( movement * speed );
    }

	void OnMove ( InputValue moveValue )
	{
		// Convert the movement input value into a 2D vector
		Vector2 moveVector = moveValue.Get<Vector2> ( );

		// Store the X and Y input values for the movement
		inputX = moveVector.x;
		inputY = moveVector.y;
	}

	void OnTriggerEnter ( Collider other )
	{
		// Check if the game object the Collider is attached to has a Collectible tag
		if ( other.tag == "Collectible" )
		{
			// Get a reference to the Score Value component
			ScoreValue scoreValue = other.gameObject.GetComponent<ScoreValue> ( );

			// Update the game score with the score from the collectible
			GameManager.AddScore ( scoreValue.Value );

			// Disable the game object collided into
			other.gameObject.SetActive ( false );
		}
	}
}