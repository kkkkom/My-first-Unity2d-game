
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class healthUI:MonoBehaviour 
{
    public List<Image> hearts = new List<Image>();
   
   
    public void UpdateHealthUI(int  currentblood)
    {
        for (int i = 0; i < hearts .Count  ; i++)
        {
            if(i<currentblood )
            {
                hearts[i].enabled =true ;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
