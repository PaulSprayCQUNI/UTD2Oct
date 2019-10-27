using UnityEngine;

public class FlyerEnemyMovement : MonoBehaviour
{

    private Transform flyTarget;
    private int flypointIndex = 0;

    private Enemy flyEnemy;

    void Start()
    {

        flyEnemy = GetComponent<Enemy>();
        flyTarget = OverlordWaypoints.olPoints[0];
    }

    
    void Update()
    {
        Vector3 dir = flyTarget.position - transform.position;
        transform.Translate(dir.normalized * flyEnemy.speed * Time.deltaTime, Space.World);
        transform.LookAt(flyTarget);

        if (Vector3.Distance(transform.position, flyTarget.position) <= 0.4f)
        {
            GetNextOverlordWaypoint();
        }

    }
    void GetNextOverlordWaypoint()
    {
        if (flypointIndex >= OverlordWaypoints.olPoints.Length - 1)
        {
            FinalWaypoint();
            return;
        }
        flypointIndex++;
        flyTarget = OverlordWaypoints.olPoints[flypointIndex];
    }


    void FinalWaypoint()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
