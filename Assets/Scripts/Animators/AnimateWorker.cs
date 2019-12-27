using UnityEngine;

[RequireComponent(typeof(IWalkMotion))]
[RequireComponent(typeof(Animator))]
public class AnimateWorker : MonoBehaviour
{

    private MotionState _motionState;
    private IWalkMotion _walkMotion;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _motionState = new MotionState(animator);
        _walkMotion = GetComponent<IWalkMotion>();
    }

    private void Update()
    {
        AnimateIdle();
        AnimateWalk();
    }

    private void AnimateIdle()
    {
        if (_walkMotion.Stop)
        {
            _motionState.Idle();
        }
    }

    private void AnimateWalk()
    {
        if (_walkMotion.Walk)
        {
            _motionState.Walk();
        }
    }
}
