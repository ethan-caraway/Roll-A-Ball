using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	// The score text UI element
	public TMP_Text ScoreText;

	// The game object containing the win lose text UI element
	public GameObject WinLoseContainer;

	// The win lose text UI element
	public TMP_Text WinLoseText;

	// The timer text UI element
	public TMP_Text TimerText;

	// The button element for loading the next level scene
	public GameObject NextLevelButton;

	// The button element for returning to the main menu scene
	public GameObject MainMenuButton;

	// The amount of score needed to win
	public int Goal;

	// The amount of time in seconds to complete the goal
	public float Timer;

	// The current score the player has in the level
	private int score = 0;

	// Whether or not the game is still being actively played
	// Set to false when the player has won or lost
	private bool isGameActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// Update the UI with the starting score
		SetScoreText ( );

		// Hide the win lose text at the start of the level
		WinLoseContainer.SetActive ( false );

		// Hide the next level button at the start of the level
		NextLevelButton.SetActive ( false );

		// Hide the main menu button at the start of the level
		MainMenuButton.SetActive ( false );
	}

    // Update is called once per frame
    void Update()
    {
		// Check if the game is still being played
		if ( isGameActive )
		{
			// Check if time remains
			if ( Timer >= 0f )
			{
				// Decrement the time
				Timer -= Time.deltaTime;
			}
			else
			{
				// Mark the game as over
				isGameActive = false;

				// Display the win lose text
				WinLoseContainer.SetActive ( true );

				// Set the win lose text to display You Lose!
				WinLoseText.text = "You Lose!";

				// Set the color the win lose text to red
				WinLoseText.color = Color.red;

				// Display the main menu button
				MainMenuButton.SetActive ( true );
			}

			// Convert the timer in seconds to a TimeSpan value
			TimeSpan timeData = TimeSpan.FromSeconds ( Timer );

			// Display the timer in a format of MM:SS.ss
			TimerText.text = timeData.ToString ( @"mm\:ss\.ff" );
		}
        
    }

	// AddScore increments the player's score by a given value
	public void AddScore ( int value )
	{
		// Check if the game is still being played
		if ( isGameActive )
		{
			// Increment the score
			score += value;

			// Update the UI with the new score
			SetScoreText ( );

			// Check if the goal has been reached
			if ( score >= Goal )
			{
				// Mark game as over
				isGameActive = false;

				// Display the win lose text
				WinLoseContainer.SetActive ( true );

				// Set the win lose text to display You Win!
				WinLoseText.text = "You Win!";

				// Set the color of the win lose text to green
				WinLoseText.color = Color.green;

				// Get the current scene data
				Scene scene = SceneManager.GetActiveScene ( );

				// Display the next level button only if it is not the last level
				NextLevelButton.SetActive ( scene.name != "Level 3" );

				// Display the main menu button
				MainMenuButton.SetActive ( true );
			}
		}
	}

	public void NextLevel ( )
	{
		// Get the current scene data
		Scene scene = SceneManager.GetActiveScene ( );

		// Get the index of the current scene
		int index = scene.buildIndex;

		// Load the next scene
		SceneManager.LoadScene ( index + 1 );
	}

	public void MainMenu ( )
	{
		// Load the main menu scene
		SceneManager.LoadScene ( "Main Menu" );
	}

	// SetScoreText updates the ScoreText UI element to display the current score
	private void SetScoreText()
	{
		// Set the text of the ScoreText UI element
		ScoreText.text = $"Score: {score}/{Goal}";
	}
}
