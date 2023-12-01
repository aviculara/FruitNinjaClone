using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitToSpawnPrefab;
    public Transform[] spawnPlaces;
    public float minWait = 0.5f;
    public float maxWait = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    /*IEnumerator return type : indicates a coroutine
     * yield return is a syntax of C#
     * Methods using yield return are called iterator blocks.
     * Timed delays, animations, and waiting for conditions are common use cases for yield return in Unity.
     * The execution of a coroutine doesn't block the main thread
     */
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait,maxWait));
            GameObject fruit = Instantiate(fruitToSpawnPrefab, transform.position , transform.rotation);
            Debug.Log("spawning a fruit");
        }
    }
}
