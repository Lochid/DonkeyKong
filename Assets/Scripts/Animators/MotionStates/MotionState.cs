using UnityEngine;

public class MotionState : IMotionState
{
    private IMotionState state;

    public MotionState(AnimatorAdapter motionAnimator)
    {
        state = new IdleState(motionAnimator);
    }

    public IMotionState Idle()
    {
        state = state.Idle();
        return this;
    }

    public IMotionState Walk()
    {
        state = state.Walk();
        return this;
    }

    public IMotionState Fall()
    {
        state = state.Fall();
        return this;
    }

    public IMotionState Land()
    {
        state = state.Land();
        return this;
    }
}
