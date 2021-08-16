public class ManagerStates : Singleton<ManagerStates>
{
    public void ChangeStateGame(TypeStateGame stateGame)
    {
        if (stateGame == TypeStateGame.Game)
        {
            ChangeCanSwipe(true);
            ChangeCanSpawnFruit(true);
        }
        else if (stateGame == TypeStateGame.LoadingLevel)
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
