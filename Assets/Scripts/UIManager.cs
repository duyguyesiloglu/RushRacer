using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text LapCounterText, bestLapTimeText, currentLapTimeText, posText, countdown, go, resulttext;

    public GameObject resultsScreen;

    public GameObject pauseScreen;

    public bool isPaused;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
        
    }
    public void Paused()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
    public void ExitRace()
    {
        Race.instance.ExitRace();
    }
    public void QuitRace()
    {
        Application.Quit();
    }
    public void ShowResultsPanel()
    {
        // Sonuç panelini aktive etmek için bu fonksiyonu kullanabilirsiniz.
        resultsScreen.SetActive(true);
    }
}
