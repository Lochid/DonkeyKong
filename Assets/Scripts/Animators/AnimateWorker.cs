using UnityEngine;

[RequireComponent(typeof(IWalkMotion))]
[RequireComponent(typeof(IJumpMotion))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimateWorker : MonoBehaviour
{

    private MotionState _motionState;
    private IWalkMotion _walkMotion;
    private IJumpMotion _jumpMotion;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _motionState = new MotionState(animator);
        _walkMotion = GetComponent<IWalkMotion>();
        _jumpMotion = GetComponent<IJumpMotion>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var next = true;
        if (next)
        {
            next = !AnimateLand();
        }
        if (next)
        {
            next = !AnimateIdle();
        }
        if (next)
        {
            next = !AnimateFall();
        }
        if (next)
        {
            next = !AnimateWalk();
        }
        if (next)
        {
            next = !TurnLeft();
        }
        if (next)
        {
            next = !TurnRight();
        }
    }

    private bool TurnLeft()
    {
        if (_walkMotion.WalkLeft)
        {
            sprite.flipX = true;
            return true;
        }

        return false;
    }

    private bool TurnRight()
    {
        if (_walkMotion.WalkRight)
        {
            sprite.flipX = false;
            return true;
        }
        return false;
    }

    private bool AnimateIdle()
    {
        if (_walkMotion.Stop)
        {
            _motionState.Idle();
            return true;
        }
        return false;
    }

    private bool AnimateWalk()
    {
        if (_walkMotion.Walk)
        {
            _motionState.Walk();
            return true;
        }
        return false;
    }

    private bool AnimateFall()
    {
        if (_jumpMotion.Fall)
        {
            _motionState.Fall();
            return true;
        }
        return false;
    }

    private bool AnimateLand()
    {
        if (_jumpMotion.Land)
        {
            _motionState.Land();
            return true;
        }
        return false;
    }
}
