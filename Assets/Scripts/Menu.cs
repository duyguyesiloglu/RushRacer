using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour

{
    public static Menu instance;

    public GameObject racesetupPanel, trackSelectPanel, racerPanel;
    public string leveltoLoad;

    public Image trackSelectImage, raceSelectImage;

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
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(Info.instance.trackToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");

    }

    public void OpenRaceSetup()
    {
        racesetupPanel.SetActive(true);
    }
    public void CloseRaceSetup()
    {
        racesetupPanel.SetActive(false);
    }
    public void OpenTrackSelect()
    {
        trackSelectPanel.SetActive(true);
        CloseRaceSetup();
    }
    public void CloseTrackSelect()
    {
        trackSelectPanel.SetActive(false);
        OpenRaceSetup();
    }
    public void OpenRacer()
    {
        racerPanel.SetActive(true);
        CloseRaceSetup();
    }
    public void CloseRacer()
    {
        racerPanel.SetActive(false);
        OpenRaceSetup();
    }

}
