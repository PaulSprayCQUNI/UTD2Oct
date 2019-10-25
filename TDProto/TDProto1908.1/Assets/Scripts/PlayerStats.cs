using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Creds;
    public int startCreds = 500;

    public static int Lives;
	public int startLives = 1;

    public static int Waves;

    void Start()
    {
        Creds = startCreds;
		Lives = startLives;
        Waves = -1;
    }
}
