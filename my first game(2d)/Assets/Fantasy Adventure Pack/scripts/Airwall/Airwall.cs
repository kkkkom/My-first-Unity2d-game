using UnityEngine;

public class Airewall:MonoBehaviour 
{
    private Collider2D _collider2D;
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("检测到物体" + other.tag);
        if(other .CompareTag ("Player"))
        {
            Invoke("OpenWall", 0.5f);
            Debug.Log("检测到玩家");
        }
    }
    private void OpenWall()
    {
        _collider2D.isTrigger = false;
    }
}
