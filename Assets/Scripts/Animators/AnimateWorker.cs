using UnityEngine;

[RequireComponent(typeof(IWalkMotion))]
[RequireComponent(typeof(IJumpMotion))]
[RequireComponent(typeof(AnimatorAdapter))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimateWorker : MonoBehaviour
{

    private MotionState motionState;
    private IWalkMotion walkMotion;
    private IJumpMotion jumpMotion;
    private AnimatorAdapter animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        animator = GetComponent<AnimatorAdapter>();
        motionState = new MotionState(animator);
        walkMotion = GetComponent<IWalkMotion>();
        jumpMotion = GetComponent<IJumpMotion>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var moving = true;
        var turning = true;
        if (moving)
        {
            moving = !AnimateLand();
        }
        if (moving)
        {
            moving = !AnimateFall();
            turning = moving;
        }
        if (moving)
        {
            moving = !AnimateIdle();
        }
        if (moving)
        {
            moving = !AnimateWalk();
        }
        if (turning)
        {
            turning = !TurnLeft();
        }
        if (turning)
        {
            turning = !TurnRight();
        }
    }

    private bool TurnLeft()
    {
        if (walkMotion.WalkLeft)
        {
            sprite.flipX = true;
            return true;
        }

        return false;
    }

    private bool TurnRight()
    {
        if (walkMotion.WalkRight)
        {
            sprite.flipX = false;
            return true;
        }
        return false;
    }

    private bool AnimateIdle()
    {
        if (walkMotion.Stop)
        {
            motionState.Idle();
            return true;
        }
        return false;
    }

    private bool AnimateWalk()
    {
        if (walkMotion.Walk)
        {
            motionState.Walk();
            return true;
        }
        return false;
    }

    private bool AnimateFall()
    {
        if (jumpMotion.Fall)
        {
            motionState.Fall();
            return true;
        }
        return false;
    }

    private bool AnimateLand()
    {
        if (jumpMotion.Land)
        {
            motionState.Land();
            return true;
        }
        return false;
    }
}
