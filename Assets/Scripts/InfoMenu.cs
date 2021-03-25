using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public static bool InfoIsShown = false;

    public GameObject infoMenuUI;
	
	
    public void ToggleInfo()
    {
        if (InfoIsShown == false)
        {
            ShowInfo();
			//Debug.Log("näytä");
        }
		
		else {
			HideInfo();
			//Debug.Log("piilota");
		}
    }
	

    void HideInfo()
    {
        infoMenuUI.SetActive(false);
        Time.timeScale = 1f;
        InfoIsShown = false;
    }

    void ShowInfo()
    {
        infoMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InfoIsShown = true;
    }
}
