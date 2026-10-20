using UnityEngine;

public class TE_bullet:MonoBehaviour 
{ public Collider2D _collider2D;
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other .CompareTag ("Player"))
        {
            other.GetComponent<player3_blood_and_dead>().TakeDamage(1);
        }
    }
    public void OpenCollider()
    {
        _collider2D.enabled = true;
    }
    public void CloseCollider()
    {
        _collider2D.enabled = false;
    }
}
