using UnityEngine;


public class PauseMenu:MonoBehaviour 
{
    public GameObject pause;
    public GameObject panle;
    
   
    private void Update()
    {
        if (Input .GetKeyDown (KeyCode.E ))
        {
            
            Pause();
            
        }
        
    }
    public void Pause()
    {   if (Time .timeScale ==1f)
        {  
            pause.SetActive(true);
            panle.SetActive(true);
            Time.timeScale = 0f;


            Debug.Log("暂停");
        }
    else
        {
            Time.timeScale = 1f;
            pause .SetActive(false);
            
            Debug.Log("开始");
        }
    }
    public  void ButtonPause()
    {  if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pause.SetActive(false);
        }
       
    }
   
}
