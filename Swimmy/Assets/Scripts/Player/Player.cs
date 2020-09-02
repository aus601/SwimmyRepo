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

            Debug.Log("Player realtime.clientID: " + playerID);
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
        playerName = _name;

        //POSSIBLE BUG - Player name does get set but does not follow Player once the Game scene has loaded
        Debug.Log("Player name has been set.");
    }

    public string GetPlayerName()
    {
        if (_model.playerName == null)
            return playerName;
        else if (playerName == null)
            return _model.playerName;
        else // For testing
            return "I have no name."; //If the Game scene happens to successfully detect a player component, it will always display this
    }
}
