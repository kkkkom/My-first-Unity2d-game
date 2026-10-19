using UnityEngine;

public class camera:MonoBehaviour 
{
    public Transform player3;
    public float smoothspeed;
   
    public Vector3 xposition;
    private void Start()
    {
        
        
    }
    private void LateUpdate()
    {
        if(player3  == null)
        {
            return;
        }
        Vector3 desireposition = player3.position + xposition;//相机相对于玩家的位置
        Vector3 smoothposition = Vector3.Lerp(transform.position, desireposition, smoothspeed * Time.deltaTime);//相机跟随玩家移动
        transform.position = smoothposition;
    }
}
