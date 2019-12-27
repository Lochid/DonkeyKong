using UnityEngine;

public class WalkState : IMotionState
{
    private Animator _motionAnimator;

    public WalkState(Animator motionAnimator)
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
}
