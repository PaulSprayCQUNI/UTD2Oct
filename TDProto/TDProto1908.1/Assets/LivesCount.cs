using UnityEngine.UI;
using UnityEngine;

public class LivesCount : MonoBehaviour
{
	public Text LivesText;
    void Update()
    {
	    LivesText.text = PlayerStats.Lives.ToString() + " LIVES:";
    }
}
