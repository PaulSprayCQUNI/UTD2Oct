using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CredsUI : MonoBehaviour
{
	public Text credsText;
    public Color lowCredColor;

    private BuildManagement buildManagement;


    void Update()
	{
		credsText.text = "Creds: ($)" + PlayerStats.Creds.ToString();

        // to do -- NullReferenceException: Object reference not set to an instance of an object
        // CredsUI.Update()(at Assets / Scripts / CredsUI.cs:19)

        if (!buildManagement.lowCreds)
        {
            credsText.text = string.Format("Creds: ($) <color=lowCredColor>{0}</color" + PlayerStats.Creds.ToString());

        }
	}
}