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

    private Player lastOwner;

    public void Awake()
    {
        //scoreManager = GameObject.Find("ScoreManager");
    }

    public void setLastOwnerID()
    {
        lastOwnerID = GetComponent<RealtimeView>().ownerID;
        //lastOwner = GetComponent<RealtimeView>().GetComponent<Player>();
        Debug.Log("Last owner ID: " + lastOwnerID);
    }

    public int GetScore()
    {
        return scoreValue;
    }

    public void CollectObject()
    {
        //Debug.Log(handInBag);
        //if (handInBag)
        ScoreManager.instance.AddToScore(scoreValue, lastOwnerID);
        //this.GetComponent<MeshRenderer>().enabled = false;

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

    public void testCollect()
    {
        ScoreManager.instance.AddToScore(5, 0);
    }
}
