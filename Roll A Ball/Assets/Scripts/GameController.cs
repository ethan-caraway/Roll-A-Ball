using UnityEngine;

public class GameController : MonoBehaviour
{
	// The current score the player has in the level
	private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AddScore ( int value )
	{
		// Increment the score
		score += value;
	}
}
