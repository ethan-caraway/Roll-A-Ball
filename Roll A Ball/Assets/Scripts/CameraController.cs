using UnityEngine;

public class CameraController : MonoBehaviour
{
	// A reference to the player game object
	public GameObject player;

	// The distance between the camera and the player
	private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// Calculate and store the initial offseft between the camera's position and the player's position
		offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// Maintain the same offset between the camera and player each frame
		transform.position = player.transform.position + offset;
    }
}
