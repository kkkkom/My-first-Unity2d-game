using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FR_bullet:MonoBehaviour 
{

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player3_blood_and_dead>().TakeDamage(1);
            
        }
        
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
