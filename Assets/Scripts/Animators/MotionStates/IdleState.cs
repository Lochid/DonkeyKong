using UnityEngine;

public class IdleState : IMotionState
{
    private AnimatorAdapter _motionAnimator;

    public IdleState(AnimatorAdapter motionAnimator)
    {
        _motionAnimator = motionAnimator;
        _motionAnimator.SetTrigger("Idle");
    }

    public IMotionState Idle()
    {
        return this;
    }

    public IMotionState Walk()
    {
        return new WalkState(_motionAnimator);
    }

    public IMotionState Fall()
    {
        return new FallState(_motionAnimator);
    }

    public IMotionState Land()
    {
        return new LandState(_motionAnimator);
    }
}
