using UnityEngine;

public class player3_jump:MonoBehaviour 
{
    private Rigidbody2D rigidbody2d;
    private bool jumpbutton= false;
    private bool ground;
    
    
    private  Vector2 boxsize;
    private  Vector2 playersize;
    public LayerMask mask;
    private Animator _animator;
    
    
    public float jumpforce = 5;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        playersize = GetComponent <SpriteRenderer >().bounds .size;
        boxsize = new Vector2(playersize .x *0.1f, 0.2f );
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && ground)
        {
            jumpbutton = true;
        }
        if(rigidbody2d .linearVelocityY >0.5f)
        {
            _animator.SetBool("israising", true);
        }
        else if(rigidbody2d .linearVelocityY <-0.5f)
        {
            _animator.SetBool("isfalling", true);
            _animator.SetBool("israising", false );
        }
        else
        {
            _animator.SetBool("isfalling", false);
            _animator.SetBool("israising", false);
        }
        
    }
    private void FixedUpdate()
    {
        Box();

        
        
        if (jumpbutton )
        {
            rigidbody2d.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse );
            jumpbutton = false;
            ground = false;
        }
        
    }
    private void Box()
    {
        Vector2 boxposition = (Vector2)rigidbody2d.transform .position -(Vector2 .up*playersize .y*0.1f);
        if(Physics2D .OverlapBox (boxposition ,boxsize ,0,mask )!=null )
        {
            ground = true;
            
        }
        else
        {
            ground = false;
        }
        
    }
    private void OnDrawGizmos()
    {
        if(ground)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Vector2 boxposition = (Vector2)transform .position -(Vector2 .up *playersize .y*0.1f);
        Gizmos.DrawWireCube(boxposition , boxsize );
    }
}
