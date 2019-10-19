using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMistress : MonoBehaviour
{
    
	public static bool GameOverMan = false;

    public GameObject gameOverUI;

    void Update()
    {
		if (GameOverMan)
			return;

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

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
