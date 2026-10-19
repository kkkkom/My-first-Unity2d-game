using UnityEditor;
using UnityEngine;

public class exit:MonoBehaviour 
{
    public void ExitGame()
    {
#if UNITY_EDITOR 
       
        UnityEditor.EditorApplication.isPlaying = false;
#endif  
        
        Application.Quit();
    }
}
