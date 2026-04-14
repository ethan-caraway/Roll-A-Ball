using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public void PlayGame()
	{
		// Load the first level scene
		SceneManager.LoadScene ( "Level 1" );
	}

    public void QuitGame ()
	{
		// Output message to the console for feedback when in the editor
		Debug.Log ( "Quitting game" );

		// Close the stand-alone application
		Application.Quit ( );
	}
}
