using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player : RealtimeComponent
{
    private PlayerModel _model;
    public string playerName = "xyz";

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
                //Register for events so we know if name changes later
                _model.playerNameDidChange += PlayerNameChanged;
            }

        }
    }

    private void PlayerNameChanged(PlayerModel model, string value)
    {
        UpdatePlayerName();
    }

    private void UpdatePlayerName()
    {
        playerName = _model.playerName;
        Debug.Log("Player UpdatePlayerName(): " + playerName);

        //ulong id = Oculus.Platform.Users.GetLoggedInUser().RequestID;
        //Debug.Log("Oculus ID: " + id);
        //TransferPlayerNames.instance.storeName(_model.playerName, id);
    }

    public void SetPlayerName(string _name)
    {
        _model.playerName = _name;
        UpdatePlayerName();

        //ulong id = Oculus.Platform.Users.GetLoggedInUser().RequestID;
        //Debug.Log("Oculus ID: " + id);
        //TransferPlayerNames.instance.storeName(_model.playerName, id);

<<<<<<< Updated upstream
        Debug.Log("Player name has been set.");
=======
        Debug.Log("Player SetPlayerName(): " + _model.playerName);
>>>>>>> Stashed changes
    }

    public string GetPlayerName()
    {
<<<<<<< Updated upstream
        if (_model.playerName == null)
            return playerName;
        else if (playerName == null)
            return _model.playerName;
        else
            return "I have no name.";
=======
        return _model.playerName;
    }

    private void Update()
    {
        //playerName = TransferPlayerNames.instance.getName(playerID); 
        //_model.playerName = TransferPlayerNames.instance.getName(playerID); ;
        //Debug.Log("Model name: " + _model.playerName + " and playerName local: " + playerName);
>>>>>>> Stashed changes
    }
}
