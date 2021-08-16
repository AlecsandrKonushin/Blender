using UnityEngine;

[RequireComponent(typeof(BlenderMovement))]
public class Blender : MonoBehaviour
{
    private int numberLine = 0;
    private int numberNextLine;
    public int GetNumberLine { get => numberLine; }

    private BlenderMovement movement;
    private BlenderFloorCollision collision;

    private void Start()
    {
        movement = GetComponent<BlenderMovement>();

        ManagerSwipeTap.Instance.Tap += MoveToLine;
        ManagerSwipeTap.Instance.Swipe += MoveToLineBeside;
    }

    /// <summary>
    /// Заморозка Блендер на текущей позиции
    /// </summary>
    public void Freeze()
    {

    }

    public void EndFreeze()
    {

    }

    private void MoveToLine(int numberLine)
    {
        numberNextLine = numberLine;
        movement.AfterEndMove += ChangeNumberLine;
        movement.MoveToLine(numberLine);
    }

    private void MoveToLineBeside(bool right)
    {
        movement.MoveToLineBeside(right);
    }

    private void ChangeNumberLine()
    {
        movement.AfterEndMove -= ChangeNumberLine;
        numberLine = numberNextLine;
    }
}
