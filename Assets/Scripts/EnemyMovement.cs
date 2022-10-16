using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	void Start()
	{
        // funcion de movimiento, lee los enemigos
		enemy = GetComponent<Enemy>();
        // establece el primer Waypoint
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // en caso de alcanzar epsilon cerca de wavepoint, destruirse
		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
        // al recorrer todo wavepoint
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();  //terminar el camino
			return;
		}
        // cada wavepoint, aumenta el index y cambia el target
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
        // actualiza vidas y destruye la entidad enemigo
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--; //actualiza el wavespawner
		Destroy(gameObject);
	}

}
