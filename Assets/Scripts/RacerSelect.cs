using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacerSelect : MonoBehaviour
{

    public Image racerImager;
    public CarContoler racerToSet;


    public void SelectRacer()
    {
        Info.instance.racerToUse = racerToSet;

        Menu.instance.raceSelectImage.sprite = racerImager.sprite;

        Menu.instance.CloseRacer();

    }
    
}
