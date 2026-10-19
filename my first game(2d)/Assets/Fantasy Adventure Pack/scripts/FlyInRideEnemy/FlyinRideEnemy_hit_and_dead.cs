using System.Collections;
using UnityEngine;

public class FlyinRideEnemy_hit_and_dead:MonoBehaviour 
{
    private Animator _animator;
    private bool isdead = false;
    private int maxblood = 3;
    private int currentblood;
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        currentblood = maxblood;
    }
    private void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        if (isdead == true)
        {
            return;
        }
        currentblood -= damage;
        if (currentblood > 0)
        {
            StartCoroutine(HitStop());
            _animator.SetTrigger("Hit");
        }
        else
        {
            isdead = true;           
            _animator.SetTrigger("Dead");
            GetComponent<FlyinRideEnemy_move_and_attack>().enabled = false;
            _collider2D.enabled = false;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
           

        }
    }
    public void DestroyEnemy()
    {
        
        Destroy(gameObject);
        Debug.Log("销毁");
    }
    public IEnumerator HitStop()
    {
        Time.timeScale = 0.08f;
        yield return new WaitForSecondsRealtime(0.08f);
        Time.timeScale = 1f;
    }


}
