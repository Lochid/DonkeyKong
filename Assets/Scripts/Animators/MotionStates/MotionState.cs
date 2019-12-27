using UnityEngine;

public class MotionState : IMotionState
{
    private IMotionState state;

    public MotionState(Animator motionAnimator)
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
}
