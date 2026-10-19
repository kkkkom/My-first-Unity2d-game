using UnityEngine;

public class Attack2:MonoBehaviour 

{ public  GameObject player3;
    private Collider2D _collider2d;
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
