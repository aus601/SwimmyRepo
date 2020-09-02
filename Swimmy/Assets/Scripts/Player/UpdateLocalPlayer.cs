using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

public class UpdateLocalPlayer : Singleton<UpdateLocalPlayer>
{

    private string localPlayerName;
    private SwimmyAvatarManager _realtimeAvatarManager;
    private Realtime _realtime;

    private void Awake()
    {
        _realtime = GetComponent<Realtime>();
        _realtimeAvatarManager = GetComponent<SwimmyAvatarManager>();
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
