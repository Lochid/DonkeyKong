using UnityEngine;

public class TransformAdapter : MonoBehaviour, ITransformAdapter
{
    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public void Translate(Vector2 vector)
    {
        transform.Translate(vector);
    }
}
