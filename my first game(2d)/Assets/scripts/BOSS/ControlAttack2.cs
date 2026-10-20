using UnityEngine;

public class ControlAttack2:MonoBehaviour 
{
    public  bool isrolling = false;
    private Rigidbody2D _rb;
    public Transform player3;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public Collider2D _collider2D;
    public void OpenCollider2D()
    {
        _collider2D.enabled = true;
    }
    public void CloseCollider2D()
    {
        _collider2D.enabled = false;
    }
    public void StartRolling()
    {
       
        isrolling = true;
        Debug.Log("当前速度" + _rb.linearVelocity.y);
        if (isrolling &&player3 !=null )
        {
            float BtoPditance = transform.position.x - player3.position.x;
            if (Mathf.Abs(BtoPditance) < 0.1f)
            {
                return;
            }
            if (BtoPditance > 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                _rb.linearVelocity = new Vector2(-8f, _rb.linearVelocity.y  );
            }

            else if (BtoPditance < 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                _rb.linearVelocity = new Vector2(8, _rb.linearVelocity.y);
            }
        }
    }
    public void StopRolling()
    {
        isrolling = false;
    }
}
