using UnityEngine;

public class player3_blink:MonoBehaviour 
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Blink", 5f, 5f);
        
    }
    private void Blink()
    {
        animator.SetTrigger("blink");
    }
}
