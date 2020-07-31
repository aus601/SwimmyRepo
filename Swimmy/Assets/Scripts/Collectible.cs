using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Collectible : MonoBehaviour
{
    //public GameObject scoreManager;
    private bool handInBag = false;
    private int lastOwnerID;

    public int scoreValue;

    public void Awake()
    {
        //scoreManager = GameObject.Find("ScoreManager");
    }

    public void setLastOwnerID()
    {
        lastOwnerID = GetComponent<RealtimeView>().ownerID;
    }

    public int GetScore()
    {
        return scoreValue;
    }

    public void CollectObject()
    {
        if (handInBag)
            ScoreManager.instance.AddToScore(scoreValue, lastOwnerID);
    }

    private void OnTriggerEnter(Collider other)
    {
        //ScoreManager.instance.AddToScore(scoreValue);
        if (other.tag == "Bag")
            handInBag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bag")
            handInBag = false;
    }
}
