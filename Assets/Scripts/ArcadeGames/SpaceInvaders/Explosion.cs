using UnityEngine;

public class Explosion : MonoBehaviour
{    
    public AudioSource audioSource;
    private Animator animator;
    private float animationDuration;


    void Start()
    {
        animator = GetComponent<Animator>();
        animationDuration = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Invoke("DestroyExplosion", animationDuration);
        audioSource.Play();
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
