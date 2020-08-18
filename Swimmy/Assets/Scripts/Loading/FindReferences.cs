using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class FindReferences : Singleton<FindReferences>
{
    private static FindReferences _instance = null;

    public static RealtimeAvatarManager _realtimeAvatarManager;
    public static Realtime _realtime;
    public static UpdateLocalPlayer _updateLocalPlayer;

    public static FindReferences Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("FindReferences is null");

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);

        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = FindObjectOfType<RealtimeAvatarManager>();
        _updateLocalPlayer = FindObjectOfType<UpdateLocalPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RealtimeAvatarManager getRealtimeAvatarManager()
    {
        if (_realtimeAvatarManager == null)
            Debug.Log("realtime avatar manager is null");

        return _realtimeAvatarManager;
    }
}
