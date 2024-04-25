using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public AnimationState animationState;

    public enum AnimationState { IDLE, WALK }

    private void Start()
    {
        animationState = AnimationState.IDLE;
    }


    public void Walk()
    {
        if (animationState == AnimationState.IDLE)
        {
            animator.SetTrigger("Walk");
            animationState = AnimationState.WALK;
        }        
    }

    public void Idle()
    {
        if (animationState == AnimationState.WALK)
        {
            animator.SetTrigger("Idle");
            animationState = AnimationState.IDLE;
        }        
    }
}
