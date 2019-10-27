using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    /*
     * references to as yet implemented next levels to go here
     */
     
    public SceneFader sceneFader;

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
