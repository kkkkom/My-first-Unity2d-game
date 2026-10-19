using UnityEngine;

public class VictroyMenu:MonoBehaviour
{
    public GameObject panel;
    private  PauseMenu pauseMenu;
   
    
    public void VictoryMenu()
    {
        GetComponent<PauseMenu>().enabled = false;
        
        panel .SetActive (true );
        Time.timeScale = 0f;
    }
}
