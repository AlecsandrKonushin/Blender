using UnityEngine.SceneManagement;

public class ManagerScenes : DontDestroySingleton<ManagerScenes>
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
