using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Остановить движение Fruit
    /// </summary>
    public void StopObject()
    {
        if (rigidBody != null)
            rigidBody.useGravity = false;
    }

    /// <summary>
    /// Fruit продолжает движение после паузы
    /// </summary>
    public void GoObject()
    {
        rigidBody.useGravity = true;
    }

    /// <summary>
    /// Включение возможности смещения по оси X
    /// </summary>
    public void AxisXEnable()
    {
        rigidBody.constraints = RigidbodyConstraints.None;
    }

    /// <summary>
    /// Ускорение скорости через drag
    /// </summary>
    public void BoostSpeed()
    {
        rigidBody.drag = .5f;
    }

    /// <summary>
    /// Удалить Fruit
    /// </summary>
    public void DestoyMe()
    {
        Destroy(gameObject);
    }
}
