using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	// The game controller keeping score
	public GameController GameManager;

	// The Rigidbody component attached to the player
	private Rigidbody rb;

	// The movement input values along the X and Y axes
	private float inputX;
	private float inputY;

	// The speed at which the player will move
	public float speed = 10f;

	// The starting position of the player in the scene
	private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// Get and store the Rigidbody component attached to the player
		rb = GetComponent<Rigidbody> ( );

		// Store the starting position of the player for respawning
		startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// Create a 3D vector using the X and Y input values
		Vector3 movement = new Vector3 ( inputX, 0f, inputY );

		// Apply a physics force to the Rigidbody to move the player
		rb.AddForce ( movement * speed );
    }

	// OnMove is called when the Input System triggers the Move action
	void OnMove ( InputValue moveValue )
	{
		// Convert the movement input value into a 2D vector
		Vector2 moveVector = moveValue.Get<Vector2> ( );

		// Store the X and Y input values for the movement
		inputX = moveVector.x;
		inputY = moveVector.y;
	}

	// OnTriggerEnter is called when the Collider of this game object enters the Collider of another game object set as a trigger
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
		// Check if the game object the Collider is attached to has a Bounds tag
		else if ( other.tag == "Bounds" )
		{
			// Reset the player's position to the starting position
			transform.position = startPosition;

			// Reset the player's rotation
			transform.rotation = Quaternion.identity;

			// Remove any physics forces applied to the player
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}
}