using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 20;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 30.0f)]
    public float minSpeed;
    [Range(0.0f, 30.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighborDistance;
    [Range(0.0f, 30.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Add each fish to the flock
        allFish = new GameObject[numFish];
        for (int i=0; i<numFish; i++)
        {
            Vector3 pos = this.transform.position 
                + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y),
                Random.Range(-swimLimits.z, swimLimits.z));

            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);

            //Connect Flock.cs and FlockManager.cs
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

}
