using UnityEngine;

public class Attack1:MonoBehaviour 
{
    private Collider2D _collider2d;
    public  GameObject player3;

    private void Start()
    {
       
        _collider2d = GetComponent<Collider2D>();
        _collider2d.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (player3 != null)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<player3_blood_and_dead>().TakeDamage(1);
            }
        }
    }

}
