using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class OverlordMovement : MonoBehaviour
{
    private Transform target;
	private int overlordWayPointIndex = 0;

    private Enemy overlordEnemy;

	void Start()
    {
	    overlordEnemy = GetComponent<Enemy>();

		target = OverlordWaypoints.olPoints[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * overlordEnemy.speed * Time.deltaTime, Space.World);
		transform.LookAt(target);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

	}

	void GetNextWaypoint()
	{
		if (overlordWayPointIndex>= OverlordWaypoints.olPoints.Length - 1)
		{
			FinalWaypoint();
			return;
		}
		overlordWayPointIndex++;
		target= OverlordWaypoints.olPoints[overlordWayPointIndex];
	}


	void FinalWaypoint()
	{
		PlayerStats.Lives=0;
		Destroy(gameObject);
	}


	
}
