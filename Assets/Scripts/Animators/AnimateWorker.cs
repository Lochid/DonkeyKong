using UnityEngine;

[RequireComponent(typeof(IWalkMotion))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class AnimateWorker : MonoBehaviour
{

    private MotionState _motionState;
    private IWalkMotion _walkMotion;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _motionState = new MotionState(animator);
        _walkMotion = GetComponent<IWalkMotion>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        AnimateIdle();
        AnimateWalk();
        TurnLeft();
        TurnRight();
    }

    private void TurnLeft()
    {
        if (_walkMotion.WalkLeft)
        {
            sprite.flipX = true;
        }
    }

    private void TurnRight()
    {
        if (_walkMotion.WalkRight)
        {
            sprite.flipX = false;
        }
    }

    private void AnimateIdle()
    {
        if (_walkMotion.Stop)
        {
            _motionState.Idle();
        }
    }

    private void AnimateWalk()
    {
        if (_walkMotion.Walk)
        {
            _motionState.Walk();
        }
    }
}
