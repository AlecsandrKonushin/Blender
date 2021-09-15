using UnityEngine;

public class ManagerTutorial : Singleton<ManagerTutorial>
{
    [SerializeField] private TutorSwipeTap tutorSwipeTap;

    private int[] levelsWithTutor = new int[4] { 0, 2, 3, 4 };

    public void CheckLevel(int number)
    {
        foreach (var numberLevel in levelsWithTutor)
        {
            if(number == numberLevel)
            {
                StartTutor(number);
            }
        }
    }

    private void StartTutor(int number)
    {
        if(number == 0)
        {
            tutorSwipeTap.StartTutor();
        }
    }
}
