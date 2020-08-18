using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player : RealtimeComponent
{
    private PlayerModel _model;
    public string playerName;
    public int playerID;

    private PlayerModel model
    {
        set
        {
            if (_model != null)
            {
                //Unregister from events
                _model.playerNameDidChange -= PlayerNameChanged;
            }

            //Store the model
            _model = value;

            if (_model != null)
            {
                //Update mesh render to match new model
                UpdatePlayerName();
                //Register for events so we know if color changes later
                _model.playerNameDidChange += PlayerNameChanged;
            }

            playerID = realtime.clientID;
        }
    }

    private void PlayerNameChanged(PlayerModel model, string value)
    {
        UpdatePlayerName();
    }

    private void UpdatePlayerName()
    {
        playerName = _model.playerName;
    }

    public void SetPlayerName(string _name)
    {
        _model.playerName = _name;
    }

    public string GetPlayerName()
    {
        return _model.playerName;
    }

    public int GetPlayerID()
    {
        return playerID;
    }
}
