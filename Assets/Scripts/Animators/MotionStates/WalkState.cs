using UnityEngine;

public class WalkState : IMotionState
{
    private AnimatorAdapter _motionAnimator;

    public WalkState(AnimatorAdapter motionAnimator)
    {
        _motionAnimator = motionAnimator;
        _motionAnimator.SetTrigger("Walk");
    }

    public IMotionState Idle()
    {
        return new IdleState(_motionAnimator);
    }

    public IMotionState Walk()
    {
        return this;
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
