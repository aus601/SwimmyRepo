using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

<<<<<<< Updated upstream
public class FindReferences : Singleton<FindReferences>
{
    private static FindReferences _instance = null;

=======
/* Retrieve the single instances of various classes, to be accessed anywhere else
 */
public class FindReferences : MonoBehaviour
{
    public static FindReferences instance;
>>>>>>> Stashed changes
    public static SwimmyAvatarManager _realtimeAvatarManager;
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
<<<<<<< Updated upstream
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);
=======
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
>>>>>>> Stashed changes

        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = FindObjectOfType<SwimmyAvatarManager>();
        _updateLocalPlayer = FindObjectOfType<UpdateLocalPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SwimmyAvatarManager getSwimmyAvatarManager()
    {
        if (_realtimeAvatarManager == null)
            Debug.Log("realtime avatar manager is null");

        return _realtimeAvatarManager;
    }

}
