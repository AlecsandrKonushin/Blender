public class StartButton : ButtonMy
{
    protected override void OtherButtonAction()
    {
        ManagerScenes.Instance.LoadGameScene();
    }
}
