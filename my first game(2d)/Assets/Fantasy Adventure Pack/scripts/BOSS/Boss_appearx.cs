using UnityEngine;

public class Boss_appearx:MonoBehaviour 
    
{
    private Collider2D _collider2D;
    private Animator _animator;
    private Boss_move_attack boss;
    private void Start()
    {
        boss = GetComponent<Boss_move_attack>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }
    
    public void Roar()
    {
        _animator.SetTrigger("Roar");
    }
    public void StopMove()
    {
        boss.enabled = false;
    }
    public void StartMove()
    {
        boss.enabled = true;
    }
}
