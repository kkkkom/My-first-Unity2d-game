using UnityEngine;

public class TrapEnemy_attack:MonoBehaviour
{
    public Vector2  attacksize = new Vector2 (1f,0.5f);//攻击范围
    public Transform attackpos;
    public LayerMask playermask;
    
    private void Start()
    {
        
    }
    public void CatchPlayer3()
    {  
        
        Collider2D[] hitplayer = Physics2D.OverlapBoxAll (attackpos.position, attacksize ,0, playermask);
        foreach (Collider2D player in hitplayer)
        {if (player !=null )
            player.GetComponent<player3_blood_and_dead>().TakeDamage(1);
        else
            {
                return;
            }
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos .color = Color.yellow;
        Gizmos.DrawWireCube (attackpos.position, attacksize );
    }
}
