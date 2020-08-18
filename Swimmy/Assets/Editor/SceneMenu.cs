using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/Lobby")]
    public static void OpenMenu()
    {
        OpenScene("Lobby");
    }

    [MenuItem("Scenes/Game")]
    public static void OpenGame()
    {
        OpenScene("GameScene");
    }

    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/PersistentScene.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}