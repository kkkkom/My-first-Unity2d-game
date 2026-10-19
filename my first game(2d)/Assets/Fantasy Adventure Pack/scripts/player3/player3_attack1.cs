using UnityEngine;

public class player3_attack1:MonoBehaviour 

{   private Animator _animator;
    public Transform attackposition;
    private Rigidbody2D _rigidbody2D;
    public float attackrange;
    public LayerMask enemymask;
    private bool player3attack = false;
    public bool isattacking = false;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {  
        if(player3attack )
        {
            _rigidbody2D.linearVelocity = new Vector2(0, _rigidbody2D.linearVelocityY);
            return;
        }
        if(Input .GetKeyDown (KeyCode.J )&&!player3attack&&!isattacking  )
        {
            player3attack = true;
            isattacking = true;
            _animator.SetTrigger("attack");
            Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackposition.position, attackrange, enemymask);
            foreach (Collider2D enemy in hitenemy)
            {  if(enemy ==null )
                {
                    return;
                }
                if (enemy.CompareTag("Flyingenemy"))
                {
                    enemy.GetComponent<FlyingEnemy_hit_and_dead>().TakeDamage(1);
                }
             if(enemy .CompareTag ("enemy2"))
                {
                    enemy.GetComponent<enemy2_dead>().TakeDamage(1);
                }
             if(enemy .CompareTag ("FlyinRideEnemy"))
                {
                    enemy.GetComponent<FlyinRideEnemy_hit_and_dead>().TakeDamage(1);
                }
             if(enemy .CompareTag ("Boss"))
                {
                    enemy.GetComponent<Boss_blood_dead>().TakeDamage(1);
                }
               
                
                   
                
            }
            Invoke("StartMove", 0.5f);
            Invoke("NoAttack", 1.5f);
        }
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackposition.position, attackrange);
        
    }
    private void NoAttack()
    {
        player3attack = false;
    }
   
    public void StartMove()
    {
        isattacking = false;
    }
}
