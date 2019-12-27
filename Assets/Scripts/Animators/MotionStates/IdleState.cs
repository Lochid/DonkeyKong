using UnityEngine;

public class IdleState : IMotionState
{
    private Animator _motionAnimator;

    public IdleState(Animator motionAnimator)
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
}
