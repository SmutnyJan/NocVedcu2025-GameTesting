using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;
    private Dictionary<Scene, int> sceneIndexes = new Dictionary<Scene, int>()
    {
        { Scene.Lobby, 0 }
    };
    public enum Scene
    {
        Lobby
    }
    public void Awake()
    {
        Instance = this;
    }

    public void ResetScene()
    {
        ChangeScene(GetCurrentScene());
    }   

    public void ChangeScene(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndexes[scene]);
    }

    public Scene GetCurrentScene()
    {
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        return GetSceneFromIndex(index) ?? Scene.Lobby;
    }

    private Scene? GetSceneFromIndex(int index)
    {
        return sceneIndexes.ContainsValue(index) ? (Scene?)index : null;
    }
}
