using UnityEngine;

public class FallState : IMotionState
{
    private AnimatorAdapter _motionAnimator;

    public FallState(AnimatorAdapter motionAnimator)
    {
        _motionAnimator = motionAnimator;
        _motionAnimator.SetTrigger("Fall");
    }

    public IMotionState Idle()
    {
        return new IdleState(_motionAnimator);
    }

    public IMotionState Walk()
    {
        return new WalkState(_motionAnimator);
    }

    public IMotionState Fall()
    {
        return this;
    }

    public IMotionState Land()
    {
        return new LandState(_motionAnimator);
    }
}
