using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
	public float speed = 20f;

	public int enemyHealth = 100;

	public int enemyCred = 50;

	public GameObject deathEffect;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points[0];
	}

	// damage dealt to enemy to be called from Bullet class
	public void HitDamage(int damageAmount)
	{
		enemyHealth -= damageAmount;

		if (enemyHealth <= 0)
		{
			EnemyDeath();
		}
	}

	void EnemyDeath()
	{
		PlayerStats.Creds += enemyCred;
		GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);

		Destroy(gameObject);
	}

	// dir normalized so the only thing that controls speed is the public float speed
	// deltaTime accounting for framerats variation
	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

	}

	void GetNextWaypoint()
	{
		if (wavepointIndex>= Waypoints.points.Length - 1)
		{
			FinalWaypoint();
			return;
		}
		wavepointIndex++;
		target= Waypoints.points[wavepointIndex];
	}


	void FinalWaypoint()
	{
		PlayerStats.Lives--;
		Destroy(gameObject);
	}


	
}
