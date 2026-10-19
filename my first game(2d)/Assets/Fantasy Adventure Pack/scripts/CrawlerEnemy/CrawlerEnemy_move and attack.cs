using UnityEngine;

public class CrawlerEnemy_moveandattack:MonoBehaviour 
{ private  float patroltarget ;
    public float patroldistance = 2.5f;
    private float startx;
    public float movespeed = 3f;
    private Rigidbody2D _rigidbody2D;
    public   Transform attackpos;
    public Vector2 attacksize = new Vector2(1f, 0.5f);
    public LayerMask playermask;


    private void Start()

    { _rigidbody2D = GetComponent<Rigidbody2D>();
        startx = transform.position.x;
        patroltarget = startx + patroldistance;
        if (transform.localEulerAngles.y > 90f)
        {
            patroltarget = startx - patroldistance;
        }
        else
        {
            patroltarget = startx + patroldistance;
        }
    }
    private void Update()
    {   
        CatchPlayer3();
        Patrol();

    }
    private void Patrol()
    {
        if (transform.position.x >= startx + patroldistance)
        {
            patroltarget = startx - patroldistance;
        }
        if (transform.position.x <= startx - patroldistance)
        {
            patroltarget = startx + patroldistance;
        }
        MoveTo(patroltarget);
    }
    private void MoveTo(float traget)
    {
        float distance = traget - transform.position.x;

       
        _rigidbody2D.linearVelocity = new Vector2(Mathf.Sign(distance) * movespeed, _rigidbody2D.linearVelocityY);
        if (distance > 0)
        {
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (distance < 0)
        {
            _rigidbody2D.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
      }
    public void CatchPlayer3()
    {
        Animator animator;
        animator = GetComponent<Animator>();
        Collider2D[] hitplayer = Physics2D.OverlapBoxAll(attackpos.position, attacksize, 0, playermask);
        foreach (Collider2D player in hitplayer)
        {
            player.GetComponent<player3_blood_and_dead>().TakeDamage(1);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackpos.position, attacksize);
    }
}
