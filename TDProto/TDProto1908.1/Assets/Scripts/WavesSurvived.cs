using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesSurvived : MonoBehaviour
{
    public Text wavesText;

    // like Start() but called everytime a game object gets enabled
    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        wavesText.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(.7f);

        while (wave < PlayerStats.Waves)
        {
            wave++;
            wavesText.text = wave.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
