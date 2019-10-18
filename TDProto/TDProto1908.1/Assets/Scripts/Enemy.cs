using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 20f;

    public int enemyHealth = 100;

	public int enemyCred = 50;

	public GameObject deathEffect;

	
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

	

	
}
