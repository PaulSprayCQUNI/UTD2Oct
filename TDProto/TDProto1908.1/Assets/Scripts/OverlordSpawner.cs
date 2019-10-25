using UnityEngine;
using System.Collections;

// use instantiate to spawn 
public class OverlordSpawner : MonoBehaviour
{

    

    public Transform overlordPrefab;
	public Transform overlordspawnPoint;

	public float overlordArrival = 30f;
	private float overlordCountdown = 0f;

	
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

      
    }
	
	IEnumerator SpawnWave()
	{
	
	for (int i= 0; i < overlordWaveIndex; i++) 
		{

            SpawnEnemy();
			yield return new WaitForSeconds(60f);
        }	

		overlordWaveIndex++;
        
	}
	
	void SpawnEnemy()
	{
		Instantiate(overlordPrefab, overlordspawnPoint.position, overlordspawnPoint.rotation);
	}
	

}
