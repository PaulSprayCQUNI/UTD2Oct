using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
	private int wavepointIndex = 0;

    private Enemy enemy;

	void Start()
    {
        enemy = GetComponent<Enemy>();

		target = Waypoints.points[0];
	}

	// dir normalized so the only thing that controls speed is the public float speed
	// deltaTime accounting for framerats variation
	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

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
