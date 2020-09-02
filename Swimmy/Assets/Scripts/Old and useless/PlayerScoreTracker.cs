using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerScoreTracker : MonoBehaviour
{
    private int localID;
    public Realtime _realtime;

    private int localScore;
    
    // Start is called before the first frame update
    void Start()
    {
        localID = _realtime.clientID;
        localScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
