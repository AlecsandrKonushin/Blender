using UnityEngine;

public class BlenderAnimation : MonoBehaviour
{
    [SerializeField] private GameObject blender;

    private Animator animator;
    private bool right;

    private void Start()
    {
        animator = blender.GetComponent<Animator>();
    }

    public void SwipeRight()
    {
        right = true;
    }

    public void SwipeLeft()
    {
        right = false;
    }

    public void StopSwipe()
    {
        if (right)
        {
            animator.SetTrigger("StopSwipeRight");
        }
        else
        {
            animator.SetTrigger("StopSwipeLeft");
        }
    }

    public void CutFruit()
    {
        animator.SetTrigger("Cut");
    }
}
