using UnityEngine;

public class FallState : IMotionState
{
    private Animator _motionAnimator;

    public FallState(Animator motionAnimator)
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
}
