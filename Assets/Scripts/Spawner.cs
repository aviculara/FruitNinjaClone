using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitToSpawnPrefab;
    public Transform[] spawnPlaces;
    public float minWait = 0.5f;
    public float maxWait = 1.3f;
    public float minForce = 10f;
    public float maxForce = 20f;

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
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
            yield return new WaitForSeconds(Random.Range(minWait,maxWait));
            GameObject fruit = Instantiate(fruitToSpawnPrefab, t.transform.position , t.transform.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(
                t.transform.up*Random.Range(minForce,maxForce), ForceMode2D.Impulse);

            Debug.Log("spawning a fruit");

            Destroy(fruit, 5f);
        }
    }
}
