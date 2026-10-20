using UnityEngine;

public class FlyinRideEnemy_move_and_attack : MonoBehaviour
{
    public GameObject bulleprefabs;
    public Transform firepoint;
    private Vector3 idlepos;
    public float patroldistance = 5f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;


    public float attackrange_ = 1f;

    public float movespeed = 2f;
    public Transform player3;
    private bool isflying;
    private bool isattacking = false;





    public LayerMask player3mask;
    private void Start()
    {
        idlepos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()

    {   
        if (player3 == null)
        {
            return;
        }
        if (isattacking)
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }

        float PtoEdistance = Vector2.Distance(player3.position, transform.position);
        float EtoIdleDistance = Vector2.Distance(idlepos, transform.position);
        if (PtoEdistance > patroldistance)
        {
            _animator.SetBool("Fly", false);

        }
        if (PtoEdistance < patroldistance && PtoEdistance > attackrange_)
        {
            GoToPlayer();
        }
        if (PtoEdistance < attackrange_ && isattacking == false)
        {
            AttackPlayer();
            isattacking = true;
            
            Invoke("DoNotAttack", 1f);

        }
        if (PtoEdistance > patroldistance && isflying || EtoIdleDistance > 10f)
        {
            Retrun();



        }
    }
    private void DoNotAttack()
    {
        isattacking = false;
    }
    private void GoToPlayer()
    {
        _animator.SetBool("Fly", true);
        _animator.SetBool("Attack", false);
        isflying = true;
        float distance_2 = transform.position.x - player3.position.x;
        if (Mathf.Abs(distance_2) < 0.1)
        {
            return;
        }
        if (distance_2 > 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        Vector2 disenemytoplayer = (player3.position - transform.position).normalized;
        _rigidbody2D.linearVelocity = disenemytoplayer * movespeed;

    }
    private void AttackPlayer()
    {   
        _animator.SetBool("Attack", true);

        float distance_2 = transform.position.x - player3.position.x;
        if (Mathf.Abs(distance_2) < 0.1)
        {
            return;
        }
        if (distance_2 > 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);


        }
    }
    private void Retrun()
    {
        _animator.SetBool("Fly", false);
        _animator.SetBool("Attack", false);
        float distance_1 = idlepos.x - transform.position.x;
        if (Mathf.Abs(distance_1) < 0.1f)
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }
        if (distance_1 > 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
        Vector2 disenemytoidlepos = (idlepos - transform.position).normalized;
        _rigidbody2D.linearVelocity = disenemytoidlepos * movespeed;
    }


    public void CreatBulletObject()
    {
        if (player3 == null)
        {   
            return;
        }

        GameObject bulletobject = Instantiate(bulleprefabs, firepoint.position, firepoint.rotation);
       
    }
}
