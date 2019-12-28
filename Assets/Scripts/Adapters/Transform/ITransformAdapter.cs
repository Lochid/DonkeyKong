using UnityEngine;

public interface ITransformAdapter
{
    Vector2 position { get; }

    void Translate(Vector2 vector);
}
