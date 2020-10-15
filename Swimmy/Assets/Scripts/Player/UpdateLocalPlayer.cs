using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

<<<<<<< Updated upstream
public class UpdateLocalPlayer : Singleton<FindReferences>
{
    private static UpdateLocalPlayer _instance = null;

=======
public class UpdateLocalPlayer : MonoBehaviour
{
    public static UpdateLocalPlayer instance;
>>>>>>> Stashed changes
    private string localPlayerName;
    private SwimmyAvatarManager _swimmyAvatarManager;
    private Realtime _realtime;

    public static UpdateLocalPlayer Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UpdateLocalPlayer is null");

            return _instance;
        }
    }

    private void Awake()
    {
<<<<<<< Updated upstream
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);

        //_realtime = GameObject.Find("Realtime + VR Player");
=======
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);

>>>>>>> Stashed changes
        _realtime = GetComponent<Realtime>();
        _swimmyAvatarManager = GetComponent<SwimmyAvatarManager>();
    }

    public void SaveLocalPlayerName(TextMeshProUGUI nameField)
    {
        localPlayerName = nameField.text;
        TransferLocalPlayerInfoToModel();
        
    }

    public void Update()
    {
        //if (SceneLoader.instance.gameIsLoading)
            //TransferLocalPlayerInfoToModel();
    }

    public void TransferLocalPlayerInfoToModel()
    {
        //if (!_realtime.connected)
        //{
            //Debug.LogError("Not connected to Realtime, but we are trying to update the model!");
            //return;
        //}
        _swimmyAvatarManager.localAvatar.gameObject.GetComponent<Player>().SetPlayerName(localPlayerName);

        Debug.Log("UpdateLocalPlayer sent to Player: " + localPlayerName);
    }
}
