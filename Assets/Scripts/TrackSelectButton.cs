using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrackSelectButton : MonoBehaviour
{
    public string trackSceneName;

    public Image trackImage;

    public int raceLap = 1;

    public GameObject unlockedText;
    private bool isLocked;

    public string trackToUnlockOnWin;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectTrack()
    {
        Info.instance.trackToLoad = trackSceneName;
        Info.instance.noOfLaps = raceLap;
        Menu.instance.trackSelectImage.sprite = trackImage.sprite;

        Menu.instance.CloseTrackSelect();
    }
}
