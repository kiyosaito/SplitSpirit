using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float radius = 1f;
    public float spawnRate = 2f;
    public GameObject prefab;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Awake()
    {
        StartCoroutine(SpawnRepeating());
    }

    IEnumerator SpawnRepeating()
    {
        Vector3 randomPoint = Random.insideUnitSphere * radius;
        Spawn(randomPoint);

        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(SpawnRepeating());
    }


    public void Spawn(Vector2 position)
    {
        Instantiate(prefab, position, transform.rotation);
    }
}
