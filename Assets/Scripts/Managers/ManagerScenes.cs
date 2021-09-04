using UnityEngine.SceneManagement;

public class ManagerScenes : DontDestroySingleton<ManagerScenes>
{
    private bool isGameScene;
    public bool GetIsGameScene { get => isGameScene; }

    public void LoadGameScene()
    {
        isGameScene = true;
        SceneManager.LoadScene(1);
    }
}
