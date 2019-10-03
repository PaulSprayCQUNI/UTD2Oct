using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Creds;
    public int startCreds = 1000;

    private

    void Start()
    {
        Creds = startCreds;
    }
}
