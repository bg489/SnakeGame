using UnityEngine;

public abstract class SnakeAbilitySO : ScriptableObject, ISnakeAbility
{
    public abstract void Execute(SnakeContext context);
}
