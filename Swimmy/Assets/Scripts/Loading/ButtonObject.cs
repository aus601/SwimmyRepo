using TMPro;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    //Find update local player singleton

    public void LoadGame()
    {

        SceneLoader.Instance.LoadNewScene("GameScene");
    }

    public void SendLocalPlayerName(TextMeshProUGUI nameField)
    {
        UpdateLocalPlayer.Instance.SaveLocalPlayerName( nameField);
    }
}
