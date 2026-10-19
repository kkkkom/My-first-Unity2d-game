using UnityEngine;
using UnityEngine.SceneManagement;

public class restartorexitgame:MonoBehaviour 
{    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
   
   
    
    public  void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
