﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretSchema
{
    public GameObject prefab;
    public int schemaCost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

	public int GetSellAmount()
	{
		return schemaCost / 2;
	}
}
