using UnityEngine;

public class FlyingEnemy_bullet_prefabs:MonoBehaviour 
{
    public float speed = 2f;
    public float lifetime = 3f;
    
    private void Start()
    {
        
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {  
        
        transform.Translate(Vector2 .right    * speed *Time .deltaTime );
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other .CompareTag ("Player"))
        {
            other.GetComponent<player3_blood_and_dead>().TakeDamage(1);
            Destroy(gameObject);
        }
        if(other .CompareTag("ground_bound"))
        {
            Destroy(gameObject);
        }
    }
}
