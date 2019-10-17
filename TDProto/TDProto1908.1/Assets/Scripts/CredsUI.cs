using UnityEngine.UI;
using UnityEngine;


public class CredsUI : MonoBehaviour
{
	public Text credsText;


    void Update()
	{
		credsText.text = "Creds: ($)" + PlayerStats.Creds.ToString();
	}
}