using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
        ApplyRules();
    }

    void ApplyRules()
    {
        GameObject[] currentFish;
        currentFish = myManager.allFish;

        Vector3 groupCenter = Vector3.zero;
        Vector3 avoidanceVector = Vector3.zero;

        float globalSpeed = 0.01f;
        float neighborDistance;
        int groupSize = 0;

        foreach (GameObject fish in currentFish)
        {
            neighborDistance = Vector3.Distance(fish.transform.position, this.transform.position);
            if (neighborDistance <= myManager.neighborDistance)
            {
                groupCenter += fish.transform.position;
                groupSize++;

                //How close each fish can be until avoiding neighbor
                if (neighborDistance < 1.0f)
                {
                    //avoidanceVector = avoidanceVector + (this.transform.position - fish.transform.position);
                }

                //Add total speed of each fish in the flock
                Flock anotherFlock = fish.GetComponent<Flock>();
                globalSpeed = globalSpeed + anotherFlock.speed;
            }
        }

        if (groupSize > 0)
        {
            groupCenter = groupCenter / groupSize;
            speed = globalSpeed / groupSize;

            //Direction to travel in
            Vector3 direction = (groupCenter ) - transform.position;
            //Slowly turn fish in direction
            //if (direction != Vector3.zero)
            //{
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                    Quaternion.LookRotation(direction), 
                    myManager.rotationSpeed * Time.deltaTime);
            //}
        }
    }
}
