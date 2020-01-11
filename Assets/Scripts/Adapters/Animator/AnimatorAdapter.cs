using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorAdapter : MonoBehaviour, IAnimatorAdapter
{
    private Animator animator;

    
    private void Start() //doesn't init correctly
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
