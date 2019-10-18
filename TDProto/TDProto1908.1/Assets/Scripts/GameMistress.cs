using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMistress : MonoBehaviour
{
    
	private bool gameEnded = false;
    void Update()
    {
		if (gameEnded)
			return;
    
		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}

    }

	void EndGame()
	{
		gameEnded = true;
		Debug.Log("Game is over");
		//scene manager load scene prompt	
	}

}
