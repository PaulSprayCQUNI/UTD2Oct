using UnityEngine.UI;
using UnityEngine;

public class LivesCount : MonoBehaviour
{
	public Text LivesText;
    void Update()
    {
        if (GameMistress.GameOverMan)
        {
            this.enabled = false;
            return;
        }

        LivesText.text = "Lives: " + PlayerStats.Lives.ToString();
    }
}
