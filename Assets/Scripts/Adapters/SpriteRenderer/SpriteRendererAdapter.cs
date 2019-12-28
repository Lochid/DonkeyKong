using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererAdapter : MonoBehaviour, ISpriteRendererAdapter
{
    public bool flipX
    {
        get => sprite.flipX;
        set => sprite.flipX = value;
    }

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
}
