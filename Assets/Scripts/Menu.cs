using MoveLogic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool game_is_paused = false;
   
    public GameObject PauseMenu;
    public GameObject HowToPlayPanel;
    public GameObject HowToPlayPanel2;
    public GameObject StatisticsPanel;
    public GameObject SesionPanel;

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
      
        game_is_paused = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false) ;
        game_is_paused = false;
        Time.timeScale = 1f;
    }

    public void Help()
    {
        HowToPlayPanel.SetActive(true);
        
    }
    public void NextHelp()
    {
        HowToPlayPanel2.SetActive(true);
        HowToPlayPanel.SetActive(false);
    }

    public void FromNextHelpToHelp()
    {
        HowToPlayPanel.SetActive(true);
        HowToPlayPanel2.SetActive(false);
    }

    public void FromHelpToMenu()
    {
        HowToPlayPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Statistics()
    {
        //LoadPlayer();
        StatisticsPanel.SetActive(true);
    }

    public void FromStatisticsToMenu()
    {
        StatisticsPanel.SetActive(false);
        SesionPanel.SetActive(false);
    }


    public void FromStatsToSesion()
    {
       
        SesionPanel.SetActive(true);
        
    }
    
    public void FromSesionToStats()
    {
        SesionPanel.SetActive(false);
        StatisticsPanel.SetActive(true);

    }

}
