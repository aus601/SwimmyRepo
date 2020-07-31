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

    private ScoreManagerModel _model;
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

    //Player 5
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

    //Player 5
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



    //realtime dictionary 2 values player id and score

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);

        //get client IDs

    }

    public void AddToScore(int scoreValue, int playerID)
    {
        //check player
        switch (playerID)
        {
            case 1:
                player1Score += scoreValue;
                scoreText1.text = "My Score: " + player1Score.ToString();
                break;
            case 2:
                player2Score += scoreValue;
                scoreText2.text = "My Score: " + player2Score.ToString();
                break;
            case 3:
                player3Score += scoreValue;
                scoreText3.text = "My Score: " + player3Score.ToString();
                break;
            case 4:
                player4Score += scoreValue;
                scoreText4.text = "My Score: " + player4Score.ToString();
                break;
            case 5:
                player5Score += scoreValue;
                scoreText5.text = "My Score: " + player5Score.ToString();
                break;
            default:
                break;
        }
    }

}
