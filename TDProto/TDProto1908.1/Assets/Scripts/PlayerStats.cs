using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Creds;
    public int startCreds = 1000;

    public static int Lives;
	public int startLives = 10;

    void Start()
    {
        Creds = startCreds;
		Lives = startLives;
    }
}
