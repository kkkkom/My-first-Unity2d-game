using UnityEngine;

public class player3_appear:MonoBehaviour 
{
    private Animator animator;
    private Rigidbody2D rigidbody2;
    private bool isentering = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator.SetTrigger("appear");
    }

    private void Update()
    {
        if(isentering )
        {
            rigidbody2.linearVelocity = new Vector2(0, 0);
        }
    }
    public void NoEnter()
    {
        isentering = false;
    }
}
