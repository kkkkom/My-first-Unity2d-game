

using UnityEngine;

public class enemy2_move_and_attack:MonoBehaviour 
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float startx;
    private float partoldistance = 2f;
    private float attackrange1 = 0.8f;
    private float partorllook = 4f;
    private float movespeed = 2f;
    public Transform player3;
    private bool  isattacking = false;
    private float partoltarget;
    public Transform attackpos;
    public  float attackrange=0 ;
    public LayerMask player3mask;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        startx = transform.position.x;
        partoltarget = startx + partoldistance;
        if(transform .localEulerAngles .y>90f)
        {
            partoltarget = startx - partoldistance;
        }
        else
        {
            partoltarget = startx + partoldistance;
        }

    }
    private void Update()
        

    {   if(player3 ==null)
        {
            return;
        }
        if(isattacking )

        {
            _rigidbody2D.linearVelocity = new Vector2(0, _rigidbody2D.linearVelocityY);
            return;
        }
        float distancetoplayer = Vector2.Distance(transform.position, player3.position);
        if(distancetoplayer >partorllook )
        {
            Partorl();
        }
        if(distancetoplayer <=partorllook &&distancetoplayer >attackrange1 )
        {
            GoToPlayer3();
        }
        
        if(distancetoplayer <=attackrange1&&!isattacking  )
        {  
        float distance_1=transform .position.x  - player3.position.x ;
            if (Mathf .Abs (distance_1 )<0.1f)
                    {
                return; }
            if (distance_1 >0)
            {
                transform.localEulerAngles = Vector3.zero;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
            Attack();
            Invoke("DoNotAttack", 2f);
        }
    }
    private void Partorl()
    {
        _animator.SetBool("iswalking", true);
        _animator.SetBool("isrunning", false);
        if(transform .position .x>=startx +partoldistance )
        {
            partoltarget = startx - partoldistance;
        }
        if(transform .position .x <=startx - partoldistance )
        {
            partoltarget = startx + partoldistance;
        }
        MoveTo(partoltarget );

         
    }
    private void GoToPlayer3()
    {
        _animator.SetBool("isrunning", true);
        _animator.SetBool("iswalking", false);
        MoveTo(player3.position.x );

    }
    private void Attack()
    {   
        isattacking = true;
        _animator.SetBool("iswalking", false);
        _animator.SetBool("isrunning", false);
        _animator.SetTrigger("attack");
       
        
        
    }
    private void DoNotAttack()
    {
        isattacking = false;
    }
    private void MoveTo(float traget)
    {
        float distance = traget - transform.position.x;

        if(Mathf .Abs (distance )<0.1f)
        {
            return;
        }
        _rigidbody2D.linearVelocity =new Vector2  (Mathf.Sign(distance) * movespeed, _rigidbody2D.linearVelocityY);
        if(distance >0)
        {
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if(distance <0)
        {
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackpos.position, attackrange);
        
    }
    public  void CatchPlayer()
    {
        Collider2D[] hitplayer3 = Physics2D.OverlapCircleAll(attackpos.position, attackrange, player3mask);
        foreach (Collider2D player in hitplayer3)
        { Debug.Log("抓到玩家了；" + player.gameObject.name + "图层是；" + LayerMask.LayerToName(player.gameObject.layer));
            if (player != null)
            { player.GetComponent<player3_blood_and_dead>().TakeDamage(1); }

            else
            {
                Debug.Log("未发现物体");
            }
            
        

       
        }
    }
}
