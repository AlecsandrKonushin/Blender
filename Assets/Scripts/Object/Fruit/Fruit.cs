using UnityEngine;

public class Fruit : FallingObject
{
    [SerializeField] private TypeFruit TypeFruit;

    public TypeFruit GetTypeFruit { get => TypeFruit; }
}
