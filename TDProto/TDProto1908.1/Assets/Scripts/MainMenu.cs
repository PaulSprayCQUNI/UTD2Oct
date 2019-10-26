using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public string levelToLoad = "FirstLevel";

	public void Play()
	{
		SceneManager.LoadScene(levelToLoad);
	}

   public void Quit()
   {
	   Debug.Log("Quit/Exit program function called");
	   Application.Quit();
   }
}
