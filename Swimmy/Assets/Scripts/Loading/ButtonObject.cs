using TMPro;
using UnityEngine;
using Normal.Realtime;

public class ButtonObject : MonoBehaviour
{
    private Realtime _realtime;
    //Find update local player singleton
    public void Awake()
    {
        _realtime = GetComponent<Realtime>();
    }

    public void LoadGame()
    {
<<<<<<< Updated upstream
        SceneLoader.Instance.LoadNewScene("GameScene");
        //_realtime.Connect("Game");
=======
        SceneLoader.instance.LoadNewScene("GameScene");
>>>>>>> Stashed changes
    }

    public void SendLocalPlayerName(TextMeshProUGUI nameField)
    {
<<<<<<< Updated upstream
        UpdateLocalPlayer.Instance.SaveLocalPlayerName( nameField);
=======
        if (nameField.text.Length > 0) //make sure player enters a name
        {
            UpdateLocalPlayer.instance.SaveLocalPlayerName(nameField);
            Debug.Log("Name was sent from button.");
        }
>>>>>>> Stashed changes
    }
}
