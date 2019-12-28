using UnityEngine;

[RequireComponent(typeof(IWalkMotionState))]
[RequireComponent(typeof(IJumpMotionState))]
[RequireComponent(typeof(AnimatorAdapter))]
public class AnimateWorker : MonoBehaviour
{
    private MotionState motionState;
    private IWalkMotionState walkMotion;
    private IJumpMotionState jumpMotion;
    private AnimatorAdapter animator;

    private void Start()
    {
        animator = GetComponent<AnimatorAdapter>();
        motionState = new MotionState(animator);
        walkMotion = GetComponent<IWalkMotionState>();
        jumpMotion = GetComponent<IJumpMotionState>();
    }

    private void Update()
    {
        AnimateLand();
        AnimateFall();
        AnimateWalk();
        AnimateIdle();
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

    private bool AnimateFall()
    {
        if (jumpMotion.Fall && !jumpMotion.Land)
        {
            motionState.Fall();
            return true;
        }
        return false;
    }

    private bool AnimateWalk()
    {
        if (walkMotion.Walk && !jumpMotion.Fall && !jumpMotion.Land)
        {
            motionState.Walk();
            return true;
        }
        return false;
    }

    private bool AnimateIdle()
    {
        if (walkMotion.Stop && !walkMotion.Walk && !jumpMotion.Fall && !jumpMotion.Land)
        {
            motionState.Idle();
            return true;
        }
        return false;
    }
}
