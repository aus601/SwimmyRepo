using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class UpdateLocalPlayer : Singleton<FindReferences>
{
    private static UpdateLocalPlayer _instance = null;

    private string localPlayerName;
    private RealtimeAvatarManager _realtimeAvatarManager;
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
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);

        //_realtime = GameObject.Find("Realtime + VR Player");
        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();
    }

    public void SaveLocalPlayerName(TextMeshProUGUI nameField)
    {
        localPlayerName = nameField.text;
        if (_realtime.connected)
        {
            TransferLocalPlayerInfoToModel();
        }
    }

    public void TransferLocalPlayerInfoToModel()
    {
        if (!_realtime.connected)
        {
            Debug.LogError("Not connected to Realtime, but we are trying to update the model!");
            return;
        }
        GameObject localPlayer = _realtimeAvatarManager.localAvatar.gameObject;
        localPlayer.GetComponent<Player>().SetPlayerName(localPlayerName);
    }
}
