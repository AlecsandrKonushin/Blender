public class ManagerStates : Singleton<ManagerStates>
{
    public void ChangeStateGame(TypeStateGame stateGame)
    {
        if (stateGame == TypeStateGame.Game)
        {
            ChangeCanSwipe(true);
            ChangeCanSpawnFruit(true);
            ManagerObjects.Instance.GoFruits();
        }
        else if (stateGame == TypeStateGame.LoadingLevel || stateGame == TypeStateGame.Pause)
        {
            ChangeCanSwipe(false);
            ChangeCanSpawnFruit(false);
            ManagerObjects.Instance.StopFallObjects();
        }
    }

    private void ChangeCanSwipe(bool canSwipe)
    {
        ManagerSwipeTap.Instance.ChangeCanSwipe(canSwipe);
    }

    private void ChangeCanSpawnFruit(bool canSpawn)
    {
        ManagerSpawner.Instance.SetCanSpawn(canSpawn);
    }
}
