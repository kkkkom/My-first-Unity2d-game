using UnityEngine;

public class Boss_appear:MonoBehaviour 
{
    private Collider2D _collider2D;
    

    public  Boss_appearx boss;
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("有东西，他的标签是=" + other.tag);
        if(other .CompareTag ("Player"))
        {  if (boss != null)
            {
                boss.Roar();
                _collider2D.enabled = false;
                Debug.Log("触碰到玩家了");
            }
        else
            {
                Debug.Log("错误");
            }
        }
    }
}
