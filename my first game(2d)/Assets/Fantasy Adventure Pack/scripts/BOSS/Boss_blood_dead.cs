using System.Collections;

using UnityEngine;

public class Boss_blood_dead:MonoBehaviour 
{
    public float maxhp = 3f;
    private float currenthp;
    private bool isdead = false;
    private Animator _animator;
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private Boss_move_attack boss;
    public bool invincible;
    private void Start()
    {
        boss = GetComponent<Boss_move_attack>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        currenthp = maxhp;
    }
    public void TakeDamage(int damage)
    {   if(invincible )
        {
            return;
        }
        if (isdead == true)
        {
            return;
        }
        currenthp -= damage;
        if (currenthp > 0)
        {
            StartCoroutine(HitStop());
            _animator.SetTrigger("Hit");
        }
        else
        {
            isdead = true;
            StartCoroutine(HitStop1());
            _animator.SetTrigger("Dead");
           
            _collider2D.enabled = false;
            
            

        }
    }
      public void DestroyBoss()
    {
        Destroy(gameObject);
    }
    public void StopMove1()
    {
        boss.enabled = false;
    }
    public void StartInvincible()
    {
        invincible = true;
    }
    public void  StopInvincible()
    {
        invincible = false;
    }
    public IEnumerator HitStop()
    {
        Time.timeScale = 0.08f;
        yield return new WaitForSecondsRealtime(0.08f);
        Time.timeScale = 1f;
    }
    public IEnumerator HitStop1()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
    }
}
