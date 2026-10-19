
using UnityEngine;

public class player3_betterjump:MonoBehaviour 
{
    private Rigidbody2D Rigidbody2D;
    public float fall = 2f;
    public float up = 2.5f;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Rigidbody2D.linearVelocityY < 0)
        {
            Rigidbody2D.gravityScale = fall;
            
        }
        if (Rigidbody2D.linearVelocityY> 0&&!Input .GetButton ("Jump")) 
        {
            
            Rigidbody2D.gravityScale = up;
            
        }

        else

        {
            Rigidbody2D.gravityScale = 1f;
           
        }
    }
}
