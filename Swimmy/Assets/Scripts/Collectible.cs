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

    /* Get the ID of the player holding this object
     * Called from Interactable event OnSelectEnter()
     */
    public void setLastOwnerID()
    {
        lastOwnerID = GetComponent<RealtimeView>().ownerID;
        //lastOwner = GetComponent<RealtimeView>().GetComponent<Player>();
        Debug.Log("Last owner ID: " + lastOwnerID);
    }

    /* Sends this objects score value and the player ID to singleton ScoreManager
     * Called from Interactable event OnSelectExit()
     * 
     * Commented lines are off for testing, for now.
     */
    public void CollectObject()
    {
        //if (handInBag)
        ScoreManager.instance.AddToScore(scoreValue, lastOwnerID);
        //this.GetComponent<MeshRenderer>().enabled = false;

    }

    /* Check if this object is held inside the hip bag trigger box: located in player prefab "Custom Avatar"
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bag")
            handInBag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bag")
            handInBag = false;
    }

    // Used for UI button testing only
    public void testCollect()
    {
        ScoreManager.instance.AddToScore(5, 0);
    }
}
