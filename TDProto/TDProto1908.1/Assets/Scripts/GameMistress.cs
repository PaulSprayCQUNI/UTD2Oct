using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMistress : MonoBehaviour
{
    // this static variable for the Game managing class GameMistress will persist between scenes
    // therefore GamerOverMan should not be set to false at game start, because a reset would leave it true when a scene resets
	public static bool GameOverMan;

    public GameObject gameOverUI;

    void Start()
    {
        GameOverMan = false;
    }



    void Update()
    {
		if (GameOverMan)
			return;

/* can be uncommented to enable keydown of 'e' for easier testing involving end game scenarios
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
 */

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}

    }

	void EndGame()
	{

		GameOverMan = true;
        gameOverUI.SetActive(true);
        
        //scene manager load scene prompt	
	}

}
