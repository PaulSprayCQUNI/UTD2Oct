using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public GameObject pauseUI;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";
  void Update()
  {
  	  if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
	  {
	  	  Toggle();
	  }
  }

  public void Toggle()
  {
	pauseUI.SetActive(!pauseUI.activeSelf);
	
	if (pauseUI.activeSelf)
	{
	/* this setting means that any animations that are required to persist when Toggle() is active
	will need to have their settings changed but timeScale of 0f will not actually affect UI elements, just any animations.
	*/
	Time.timeScale = 0f;
	} else
	{
		Time.timeScale = 1f;
	}
	
  }

  public void Retry()
  {
	Toggle();
    sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	

  }

  public void Menu()
  {
      Toggle();
  	  sceneFader.FadeTo(menuSceneName); 
  }



}
