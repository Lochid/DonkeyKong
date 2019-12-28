using UnityEngine;

public class TransformAdapter : MonoBehaviour, ITransformAdapter
{
    public void Translate(Vector2 vector)
    {
        transform.Translate(vector);
    }
}
