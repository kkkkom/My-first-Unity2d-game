using UnityEngine;

public class player3_jump1:MonoBehaviour 
{
    private Rigidbody2D rigidbody2d;
    
    private  bool ground;
   
    
    private  Vector2 boxsize;
    private  Vector2 playersize;
    public LayerMask mask;
    private Animator _animator;
    private bool idletoraise;
    
    
    public float jumpforce = 6;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        playersize = GetComponent <SpriteRenderer >().bounds .size;
        boxsize = new Vector2(playersize .x *0.1f, 0.2f );
    }
   
   
    private void Update()
    {
        Vector2 boxposition = (Vector2)rigidbody2d.transform.position - (Vector2.up * playersize.y * 0.1f);
        if (Physics2D.OverlapBox(boxposition, boxsize, 0, mask) != null)
        {
            ground = true;

        }
        else
        {
            ground = false;
        }
        if (Input.GetButtonDown("Jump") && ground==true )
        {
            rigidbody2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            ground = false;
        }
       else  if (rigidbody2d.linearVelocityY > 0.5f && ground==false )
        {
            _animator.SetBool("idletoraise", true);
        }
        
      else   if(rigidbody2d .linearVelocityY <-0.2f&&ground==false  )
        {
            
          
            _animator.SetBool("falling", true );
        }
      else    if(ground )
        {
            _animator.SetBool("falling", false);
            _animator.SetBool("idletoraise", false);

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
