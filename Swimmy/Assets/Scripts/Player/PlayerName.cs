using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    private Player _player;
    private TextMeshPro _playerTextUI;
    public string currentName;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _playerTextUI = GetComponent<TextMeshPro>();
        if (_player == null)
        {
            Debug.LogError("No player config found");
        }
        currentName = "x";
    }

    private void Update()
    {
        if (_player == null) return;

        if (currentName != _player.playerName)
        {
            currentName = _player.playerName;
            //currentName = TransferPlayerNames.instance.getName(_player.playerID);
            _playerTextUI.SetText(currentName);

            Debug.Log("PlayerName has set UI text to: " + currentName);
        }
    }
}
