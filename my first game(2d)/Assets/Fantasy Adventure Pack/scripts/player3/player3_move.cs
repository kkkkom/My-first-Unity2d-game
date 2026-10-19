using System.Xml.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class player3_move:MonoBehaviour 
{
    public float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private float x;
    private player3_attack1 _player3;
    private void Start()
    {
       _player3 = GetComponent<player3_attack1>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
       
    }
    private void Update()
    {if (_rigidbody2D .bodyType ==RigidbodyType2D.Static  )
        {
            
            return;
        }
     
       

        if (x > 0 && _rigidbody2D.linearVelocityY < 0.1f && _rigidbody2D.linearVelocityY > -0.1f)
        {
           
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 0, 0);
            _animator.SetBool("idletorun", true);

        }
        else if (x < 0 && _rigidbody2D.linearVelocityY < 0.1f && _rigidbody2D.linearVelocityY > -0.1f)
        {
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 180, 0);
            
            _animator.SetBool("idletorun", true );
        }
        else if  (x < 0.001 && x > -0.001||_rigidbody2D .linearVelocityY >0.1||_rigidbody2D.linearVelocityY <-0.1)
        {
            _animator.SetBool("idletorun", false);
        }
       
       
        
    }
    private void  FixedUpdate ()
    {  if(_player3 .isattacking )
        {
            return;
        }
        x = Input.GetAxis("Horizontal");

        _rigidbody2D.linearVelocity = new Vector2(x * speed , _rigidbody2D.linearVelocityY);
     } 

}

