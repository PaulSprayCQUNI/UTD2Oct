using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public float speed = 20f;

    public float enemyStartHealth = 100;
    private float enemyHealth;

	public int enemyCred = 50;

	public GameObject deathEffect;

    [Header("Unity Stuff")]

    public Image healthBar;

    private bool isDead = false;

    void Start()
    {

        enemyHealth = enemyStartHealth;

    }


	// damage dealt to enemy to be called from Bullet class
	public void HitDamage(int damageAmount)
	{
		enemyHealth -= damageAmount;

        healthBar.fillAmount = enemyHealth / enemyStartHealth;

		if (enemyHealth <= 0 && !isDead)
		{
			EnemyDeath();
		}
	}

	void EnemyDeath()
    {
        isDead = true;

		PlayerStats.Creds += enemyCred;
		GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
        WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

	

	
}
