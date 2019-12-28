using UnityEngine;

public class LandState : IMotionState
{
    private AnimatorAdapter _motionAnimator;

    public LandState(AnimatorAdapter motionAnimator)
    {
        _motionAnimator = motionAnimator;
        _motionAnimator.SetTrigger("Land");
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
        return this;
    }
}
