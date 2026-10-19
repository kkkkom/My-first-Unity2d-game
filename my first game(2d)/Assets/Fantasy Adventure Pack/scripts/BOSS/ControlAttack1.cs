using UnityEngine;

public class ControlAttack1:MonoBehaviour 
{
    public Collider2D _collider2d;
    public void OpenCollider2d()
    {
        _collider2d.enabled  = true;
    }
    public void CloseCollider2d()
    {
        _collider2d.enabled = false;
    }
}
