using UnityEngine;

[RequireComponent(typeof(IWalkMotionState))]
[RequireComponent(typeof(ISpriteRendererAdapter))]
public class TurnWorker : MonoBehaviour
{
    private ISpriteRendererAdapter sprite;
    private IWalkMotionState walkMotion;
    private IJumpMotionState jumpMotion;

    private void Start()
    {
        walkMotion = GetComponent<IWalkMotionState>();
        jumpMotion = GetComponent<IJumpMotionState>();
        sprite = GetComponent<ISpriteRendererAdapter>();
    }

    private void Update()
    {
        TurnLeft();
        TurnRight();
    }

    private bool TurnLeft()
    {
        if (walkMotion.WalkLeft && !jumpMotion.Fall)
        {
            sprite.flipX = true;
            return true;
        }

        return false;
    }

    private bool TurnRight()
    {
        if (walkMotion.WalkRight && !jumpMotion.Fall)
        {
            sprite.flipX = false;
            return true;
        }
        return false;
    }
}
