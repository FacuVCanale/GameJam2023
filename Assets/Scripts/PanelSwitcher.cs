using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PanelSwitcher : MonoBehaviour 
{
    public GameObject[] panels;
    int currentPanel = 0; 

    IEnumerator Start()
    {
        while (true) 
        {
            yield return new WaitForSeconds(3f);
            
            InvokeRepeating("NextPanel", 0.1f, 0.2f);
            
            yield return new WaitForSeconds(4f);
            
            CancelInvoke("NextPanel");
        }
    }

    void NextPanel()
    {
        currentPanel++;
        if(currentPanel >= panels.Length)
            currentPanel = 0;

        ShowCurrentPanel();
    }

    void ShowCurrentPanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == currentPanel)
                panels[i].SetActive(true);
            else
                panels[i].SetActive(false);
        }
    }

}
