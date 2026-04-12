using UnityEngine;

public class Oscillator : MonoBehaviour
{
	// The speed at which the game object will move
	public float speed;

	// The range the game object will move
	public float range;

	// The starting position in the scene of the game object
	private Vector3 startPosition;

	// The 3D movement vector to apply to the game object
	private Vector3 movement;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// Store the starting position of the game object to move from
		startPosition = transform.position;

		// Give the game object a random starting position within the movement range
		transform.position += Vector3.up * Random.Range ( range * -1, range );

		// Set the starting movement direction to up
		movement = Vector3.up * speed;
	}

    // Update is called once per frame
    void Update()
    {
        // Check if the game object has moved above the range
		if ( transform.position.y >= startPosition.y + range )
		{
			// Change the movement direction of the game object to down
			movement = Vector3.down * speed;
		}
		// Check if the game object has moved below the range
		else if ( transform.position.y <= startPosition.y - range )
		{
			// Change the movement direction of the game object to up
			movement = Vector3.up * speed;
		}

		// Move the game object
		transform.position += movement * Time.deltaTime;
    }
}
