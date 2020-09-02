using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;


public class ScoreManager : RealtimeComponent
{
    public static ScoreManager instance = null;
    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Text scoreText4;
    public Text scoreText5;

    public int player1Score = 0;
    public int player2Score = 0;
    public int player3Score = 0;
    public int player4Score = 0;
    public int player5Score = 0;

    public int player1ID = 0;
    public int player2ID = 0;
    public int player3ID = 0;
    public int player4ID = 0;
    public int player5ID = 0;

    private ScoreManagerModel _model;

    private SwimmyAvatarManager _swimmyAvatarManager = null;

    private ScoreManagerModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.player1ScoreDidChange -= player1ScoreChanged;
                _model.player2ScoreDidChange -= player2ScoreChanged;
                _model.player3ScoreDidChange -= player3ScoreChanged;
                _model.player4ScoreDidChange -= player4ScoreChanged;
                _model.player5ScoreDidChange -= player5ScoreChanged;
            }
            // Store the model
            _model = value;
            if (_model != null)
            {
                // Update the mesh render to match the new model
                player1UpdateScore();
                player2UpdateScore();
                player3UpdateScore();
                player4UpdateScore();
                player5UpdateScore();

                //Register for events
                _model.player1ScoreDidChange += player1ScoreChanged;
                _model.player2ScoreDidChange += player2ScoreChanged;
                _model.player3ScoreDidChange += player3ScoreChanged;
                _model.player4ScoreDidChange += player4ScoreChanged;
                _model.player5ScoreDidChange += player5ScoreChanged;
            }
}
    }

    //Player 1
    private void player1ScoreChanged(ScoreManagerModel model, int value)
    {
        player1UpdateScore();
    }
    private void player1UpdateScore()
    {
        //updates scoreboard of p1
        player1Score = _model.player1Score;
    }
    public void setPlayer1Score(int score)
    {
        _model.player1Score += score;
    }

    //Player 2
    private void player2ScoreChanged(ScoreManagerModel model, int value)
    {
        player2UpdateScore();
    }
    private void player2UpdateScore()
    {
        player2Score = _model.player2Score;
    }
    public void setPlayer2Score(int score)
    {
        _model.player2Score += score;
    }

    //Player 3
    private void player3ScoreChanged(ScoreManagerModel model, int value)
    {
        player3UpdateScore();
    }
    private void player3UpdateScore()
    {
        player3Score = _model.player3Score;
    }
    public void setPlayer3Score(int score)
    {
        _model.player1Score += score;
    }

    //Player 4
    private void player4ScoreChanged(ScoreManagerModel model, int value)
    {
        player4UpdateScore();
    }
    private void player4UpdateScore()
    {
        player4Score = _model.player4Score;
    }
    public void setPlayer4Score(int score)
    {
        _model.player4Score += score;
    }

    //Player 5
    private void player5ScoreChanged(ScoreManagerModel model, int value)
    {
        player5UpdateScore();
    }
    private void player5UpdateScore()
    {
        player5Score = _model.player5Score;
    }
    public void setPlayer5Score(int score)
    {
        _model.player5Score += score;
    }


    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);

        //Get reference for SwimmyAvatarManager
        _swimmyAvatarManager = FindReferences.Instance.getSwimmyAvatarManager();
    }

    /* Check if this score is big enough to be a win
     * Called from AddToScore()
     */
    public bool checkForWin(int score)
    {
        if (score >= 20)
        {
            return true;
        }
        return false;
    }

    /* Adds an objects score to the total score of the player who collected
     * Called by Collectible.CollectObject()
     */
    public void AddToScore(int scoreValue, int playerID)
    {
        List<int> IDList = new List<int>(_swimmyAvatarManager.avatars.Keys);
        List<SwimmyAvatar> avatarList = new List<SwimmyAvatar>(_swimmyAvatarManager.avatars.Values);

        //Testing purposes only
        scoreText2.text = "id list length: " + IDList.Count + " and this ID: " + playerID;
        scoreText3.text = "avatar list length: " + avatarList.Count;
        scoreText4.text = "dictionary length: " + _swimmyAvatarManager.avatars.Count;

        //Loop through the dictionary to find matching player
        SwimmyAvatar currentAvatar = null;
        foreach (KeyValuePair<int, SwimmyAvatar> currentPair in _swimmyAvatarManager.avatars)
        {
            if (currentPair.Key == playerID)
            {
                currentAvatar = currentPair.Value.GetComponent<SwimmyAvatar>();
            }
        }

        //Testing purposes
        if (currentAvatar == null)
            scoreText1.text = "avatar null";
        else if (currentAvatar._player == null)
            scoreText1.text = "player component null";
        else
            scoreText1.text = currentAvatar._player.GetPlayerName() + "name and ID: " + playerID;

        //check which player #1-5 based on player ID
        int scoreToCheck = 0;
        int whichPlayer = 0;
        try 
        {
            if (playerID == IDList[0])
            {
                player1Score += scoreValue;
                scoreToCheck = player1Score;
                whichPlayer = 1;
                scoreText1.text = currentAvatar.GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[1])
            {
                player2Score += scoreValue;
                scoreToCheck = player2Score;
                whichPlayer = 2;
                scoreText2.text = avatarList[1].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[2])
            {
                player3Score += scoreValue;
                scoreToCheck = player3Score;
                whichPlayer = 3;
                scoreText3.text = avatarList[2].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[3])
            {
                player4Score += scoreValue;
                scoreToCheck = player4Score;
                whichPlayer = 4;
                scoreText4.text = avatarList[3].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[4])
            {
                player5Score += scoreValue;
                scoreToCheck = player5Score;
                whichPlayer = 5;
                scoreText5.text = avatarList[4].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else
            {
                scoreText1.text = "no matching ID for: " + playerID;
            }
        } catch (System.ArgumentOutOfRangeException) {
            Debug.Log("Index out of bounds. Client ID not found");
            scoreText1.text = "out of bounds index";
        }

        //Check if there is a win
        if (checkForWin(scoreToCheck))
        {
            WinManager.Instance.playerHasWon(whichPlayer);
        }

    }

}
