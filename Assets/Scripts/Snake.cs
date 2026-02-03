using System.Collections.Generic;
using UnityEngine;

public abstract class Snake : MonoBehaviour
{
    public List<ISnakeAbility> abilities;

    public void UseAbility(int index)
    {
        abilities[index].Execute(new SnakeContext(this));
    }
    public abstract void Eating();
    public abstract void Growing();

}
