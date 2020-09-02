using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

/* Retrieve the single instances of various classes, to be accessed anywhere else
 */
public class FindReferences : Singleton<FindReferences>
{

    public static SwimmyAvatarManager _realtimeAvatarManager;
    public static Realtime _realtime;
    public static UpdateLocalPlayer _updateLocalPlayer;

    void Awake()
    {
        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = FindObjectOfType<SwimmyAvatarManager>();
        _updateLocalPlayer = FindObjectOfType<UpdateLocalPlayer>();

    }

    public SwimmyAvatarManager getSwimmyAvatarManager()
    {
        if (_realtimeAvatarManager == null)
            Debug.Log("realtime avatar manager is null");

        return _realtimeAvatarManager;
    }

}
