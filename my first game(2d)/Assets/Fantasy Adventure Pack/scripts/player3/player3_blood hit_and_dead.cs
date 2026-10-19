using System.Collections;
using UnityEngine;

public class player3_blood_and_dead:MonoBehaviour 
{
    public  int  _currentblood;
    public  int  _maxblood = 6;
    private Animator _animator;
    private Rigidbody2D _rigidbody2d;
    private Collider2D _collider2D;
    private bool isdead = false;
    public float invincibletime;
    public healthUI healthUI;
    
    private void Start()
    {   
        
        _currentblood = _maxblood;
        healthUI.UpdateHealthUI(_currentblood);
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        
    }
    private void Update()
    {  if(gameObject ==null )
        {
            return;
        }
        //如果无敌帧大于0秒，每帧减少一帧
        if(invincibletime >0)
        {
            invincibletime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
       
        if(isdead )
        {
            return;
        }
    if(invincibletime >0)
        {
            return;
        }
        _currentblood -= damage;
        if(healthUI !=null )
        {
            healthUI.UpdateHealthUI(_currentblood);
        }
        if(_currentblood >0)
        {
            invincibletime = 0.7f;
            StartCoroutine(HitStop());
            _animator.SetTrigger("player3_hit");
        }
        else
        {
            isdead = true;
            _animator.SetTrigger("player3_dead");
            _collider2D.enabled = false;
            _rigidbody2d.bodyType = RigidbodyType2D.Static;
            GetComponent<player3_move>().enabled = false;

            
            
        }
        Debug.Log("当前血量" + _currentblood);
    }
    public void Destroy()
    {
       
        Destroy(gameObject);
    }
    public void DoNotAttack()
    {
        GetComponent<player3_attack1>().enabled = false;
    }
    public IEnumerator HitStop()
    {
        Time.timeScale = 0.08f;
        yield return new WaitForSecondsRealtime(0.08f);
        Time.timeScale = 1f;
    }
}
