using System.Collections;
using UnityEngine;

public class Boss_move_attack:MonoBehaviour 
{
    public  float attackdistance=8f;
    public float speed = 2f;
    private float patroldistance=20;
    private Animator _animator;
    public Transform player3;
    private Rigidbody2D _rb;
    public  bool isattacking = false;
    private ControlAttack2 CAK2;
    
    private void Start()
    {
        CAK2 = GetComponent<ControlAttack2>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        StartCoroutine(AttackLoop());
    }
    private void Update()
    {   if(player3 ==null )
        {
            return;
        }
        if(isattacking==true &&!CAK2 .isrolling  )
        {
            _rb.linearVelocity = Vector2.zero;
            return;
        }
        float distance = transform.position.x - player3.position.x;
        if( Mathf.Abs (distance) >patroldistance )
        {
            _animator.SetBool("Walk", false);
        }
      else   if (Mathf.Abs (distance )<patroldistance &&distance >attackdistance )
        {
            MoveToPlayer();
        }
       
        
        
    }
    private IEnumerator AttackLoop()
    {
        
        while (true)
        {


            if (isattacking == false && player3 != null)
            {
                float distance = transform.position.x - player3.position.x;


                if (Mathf.Abs (distance) < attackdistance&&!CAK2 .isrolling )
                {
                    _animator.SetBool("Walk", false);
                    _rb.linearVelocity = Vector2.zero;

                    isattacking = true;
                    int skill = Random.Range(0, 2);
                    if (skill == 0)
                    {
                        Attack1();
                    }
                    else if (skill == 1)
                    {
                        Attack2();
                    }

                    yield return new WaitForSeconds(1f);
                    isattacking = false;


                }
                else
                {
                    yield return null;
                }

            }
            else { break; }
        }
    }
    private void MoveToPlayer()
    {  
        _animator.SetBool("Walk", true);
        float BtoPditance = transform.position.x - player3.position.x;
        if (Mathf .Abs (BtoPditance )<0.1f)
        {
            return;
        }
        if(BtoPditance >0&&!CAK2 .isrolling )
        {
            transform.localEulerAngles = new Vector3(0,0, 0);
            _rb.linearVelocity = new Vector2(- speed, _rb.linearVelocity .y  );
        }
        
        else if (BtoPditance < 0 && !CAK2.isrolling)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            _rb.linearVelocity = new Vector2(speed, _rb.linearVelocity.y);
        }
            
         

        
    }
    private void Attack1()
    {
        _animator.SetTrigger ("Attack1");
       
        float BtoPditance = transform.position.x - player3.position.x;
        if (Mathf.Abs(BtoPditance) < 0.1f)
        {
            return;
        }
        if (BtoPditance > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
           
        }

        else if (BtoPditance < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            
        }
    }
    private void Attack2()
    {
        _animator.SetTrigger ("Attack2");
       
        float BtoPditance = transform.position.x - player3.position.x;
        if (Mathf.Abs(BtoPditance) < 0.1f)
        {
            return;
        }
        if (BtoPditance > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
           
        }

        else if (BtoPditance < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            
        }
    }
    

    
}
