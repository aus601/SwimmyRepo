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

    private RealtimeAvatarManager _realtimeAvatarManager = null;

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

            /*
            //Match a player ID with a player number 1-5
            player1ID = _realtimeAvatarManager.avatars[1];
            player2ID = 0;
            player3ID = 0;
            player4ID = 0;
            player5ID = 0;
            */

}
    }

    public void Start()
    {
        
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

        //Get reference for RealtimeAvatarManager
        _realtimeAvatarManager = FindReferences.Instance.getRealtimeAvatarManager();
    }

    public void AddToScore(int scoreValue, int playerID)// Player player)
    {
        //RealtimeAvatar playerAvatar;
        //if (_realtimeAvatarManager.avatars.ContainsKey(playerID))
            //playerAvatar = _realtimeAvatarManager.avatars[playerID];

        //Player player = playerAvatar.GetComponent<Player>();
        //scoreText2.text = "player name " + player.GetPlayerName();

        List<int> IDList = new List<int>(_realtimeAvatarManager.avatars.Keys);
        List<RealtimeAvatar> avatarList = new List<RealtimeAvatar>(_realtimeAvatarManager.avatars.Values);

        //check which player #1-5 based on player ID
        try
        {
            if (playerID == IDList[0])
            {
                player1Score += scoreValue;
                scoreText1.text = avatarList[0].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[1])
            {
                player2Score += scoreValue;
                scoreText2.text = avatarList[1].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[2])
            {
                player3Score += scoreValue;
                scoreText3.text = avatarList[2].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[3])
            {
                player4Score += scoreValue;
                scoreText4.text = avatarList[3].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else if (playerID == IDList[4])
            {
                player5Score += scoreValue;
                scoreText5.text = avatarList[4].GetComponent<Player>().GetPlayerName() + "'s Score: " + player1Score.ToString();
            }
            else
            {
                scoreText1.text = "no matching ID";
            }
        } catch (System.IndexOutOfRangeException e) {
            Debug.Log("Index out of bounds. Client ID not found");
            scoreText1.text = "out of bounds index";
        }
        

    }

}
