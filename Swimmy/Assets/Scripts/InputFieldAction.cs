using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InputFieldAction : MonoBehaviour
{
    #region Public Fields
    public TMP_InputField inputField;
    public TextMeshProUGUI placeholder;
    #endregion
    public void AppendText(string text)
    {
        if (placeholder.text != "")
        {
            placeholder.text = "";
        }
        if (inputField.text == "")
        {
            inputField.text = text;
            //Debug.Log(inputField.text + "/" + text);
        }
        else
        {
            if (inputField.text.Length <= 15)
                inputField.text += text;
            //Debug.Log(inputField.text + "/" + text);
        }
    }

    public void DeleteText()
    {
        string current = inputField.text;

        if (current.Length >= 1)
            inputField.text = current.Substring(0, current.Length - 1);
    }
}