public interface IMotionState
{
    IMotionState Idle();
    IMotionState Walk();
    IMotionState Fall();
    IMotionState Land();
}
