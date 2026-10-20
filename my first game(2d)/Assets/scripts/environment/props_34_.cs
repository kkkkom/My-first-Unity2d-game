using UnityEngine;

public class props_34_:MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player3_blood_and_dead>().TakeDamage(1);
        }


    }

}
