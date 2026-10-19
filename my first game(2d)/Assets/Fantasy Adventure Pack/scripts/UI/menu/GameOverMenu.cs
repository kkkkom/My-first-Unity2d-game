using UnityEngine;
using UnityEngine.Analytics;

public class GameOverMenu : MonoBehaviour
{
    public   GameObject gameover;
    public GameObject boss;
    private void Start()
    {
        
        gameover.SetActive(false);
    }
    public void GameOver()
    {
        boss.GetComponent<PauseMenu>().enabled = false;
        gameover.SetActive(true);
        Debug.Log("显示");

    }
}
