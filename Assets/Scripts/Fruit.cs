using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    
    public int scoreAmount = 3;

    private GameManager myGameManager;

    private void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
    }
    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        /*
        * transform property of a GameObject holds the information about its position, rotation, scale
        * GetComponentsInChildren<T>() is a method provided by Unity's Transform class. 
        * It returns an array of components of type T. (in this case, Rigidbody)
        * gets components in children of type rigidbody
        */

        foreach(Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(100,600), transform.position, explosionRadius);
            
        }

        myGameManager.IncreaseScore(scoreAmount);

        Destroy(inst, 5f);

        Destroy(gameObject);
    }
    /*
     * instantiate at an arbitrary position:
     * 
     * Vector3 arbitraryPosition = new Vector3(5.0f, 2.0f, 3.0f);
     * Quaternion arbitraryRotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
     * GameObject inst = Instantiate(slicedFruitPrefab, arbitraryPosition, arbitraryRotation);
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        
        if(!b)
        {
            return;
        }
        CreateSlicedFruit();
    }

    
}
