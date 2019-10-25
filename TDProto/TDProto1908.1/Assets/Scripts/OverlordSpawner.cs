using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// use instatiate to spawn 
public class OverlordSpawner : MonoBehaviour
{
    public Transform overlordPrefab;
	public Transform overlordspawnPoint;

	public float overlordArrival = 30f;
	private float overlordCountdown = 0f;

	public Text overlordArrivalText;

	private int overlordWaveIndex = 0;



	void Update()
	{
		if (overlordCountdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			overlordCountdown = overlordArrival;
			
		}
		
		
		overlordCountdown -= Time.deltaTime;
        overlordCountdown = Mathf.Clamp(overlordCountdown, 0f, Mathf.Infinity);

       overlordArrivalText.text = string.Format("An Overlord Approaches: {0:00.00}", overlordCountdown);
    }
	
	IEnumerator SpawnWave()
	{
	Debug.Log("Wave Incoming");
	for (int i= 0; i < overlordWaveIndex; i++) 
		{
			SpawnEnemy();
			yield return new WaitForSeconds(60f);
		}	

		overlordWaveIndex++;
        PlayerStats.Waves++;
	}
	
	void SpawnEnemy()
	{
		Instantiate(overlordPrefab, overlordspawnPoint.position, overlordspawnPoint.rotation);
	}
	

}
