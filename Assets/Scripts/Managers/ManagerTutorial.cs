using UnityEngine;

public class ManagerTutorial : Singleton<ManagerTutorial>
{
    [SerializeField] private TutorSwipeTap tutorSwipeTap;
    [SerializeField] private TutorDanger tutorDanger;

    private int[] levelsWithTutor = new int[4] { 0, 2, 4, 6 };

    public void CheckLevel(int number)
    {
        foreach (var numberLevel in levelsWithTutor)
        {
            if (number == numberLevel)
            {
                StartTutor(number);
            }
        }
    }

    private void StartTutor(int number)
    {
        if (number == 0)
        {
            tutorSwipeTap.StartTutor();
        }
        else if (number == 2)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.Tree);
        }
        else if (number == 4)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.Ice);
        }
    }

    private void SetWaitTutor()
    {
        ManagerLevel.Instance.SetWaitTutor = true;
    }
}
