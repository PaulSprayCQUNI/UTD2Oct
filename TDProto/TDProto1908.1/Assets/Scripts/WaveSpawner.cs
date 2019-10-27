using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    
    public Wave[] waves;

	public Transform spawnPoint;

	public float waveInterval = 5f;
	private float countdown = 0f;

	public Text waveCountdownText;

    public GameMistress gameMistress;

	private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
	{
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameMistress.LevelWin();
            this.enabled = false;
        }

        if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = waveInterval;
            return;

        }
		
		
		countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

       waveCountdownText.text = string.Format("Next wave in: {0:00.00}", countdown);
    }
	
	IEnumerator SpawnWave()
	{
        PlayerStats.Waves++;
        Wave wave = waves[waveIndex];

	    for (int i= 0; i < wave.count; i++)
        {
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
            
        }	

		waveIndex++;
        
	}
	
	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
	

}
