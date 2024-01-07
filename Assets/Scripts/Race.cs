using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Race : MonoBehaviour
{
    public static Race instance;

    public CheckPoints[] allcheckPoints;

    public int totalLaps;

    public CarContoler playerCar;
    public List<CarContoler> allAICars = new List<CarContoler>();

    public int playerPos;

    public float timebetweenPos = .2f;
    private float posCheckCount;

    public bool isStart;
    public float timeBetweenStartCount = 1f;
    private float startCounter;
    public int countdownCurrent = 3;

    public int playerStartPosition, aiNumbertoSpawn;
    public Transform[] starts;

    public List<CarContoler> carstoSpawn = new List<CarContoler>();

    public bool racecomp;

    public string raceCompleteScene;







    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < allcheckPoints.Length; i++)
        {
            allcheckPoints[i].cpNumber = i;
        }
        isStart = true;
        startCounter = timeBetweenStartCount;



        UIManager.instance.countdown.text = countdownCurrent + "!";

        playerStartPosition = Random.Range(0, aiNumbertoSpawn + 1);

        playerCar.transform.position = starts[playerStartPosition].position;

        playerCar.theRB.position = starts[playerStartPosition].position;

        for( int i = 0; i < aiNumbertoSpawn; i++)
        {
            if(i != playerStartPosition)
            {
                int selected = Random.Range(0, carstoSpawn.Count);



                allAICars.Add(Instantiate(carstoSpawn[selected], starts[i].position, starts[i].rotation));

                if (carstoSpawn.Count > aiNumbertoSpawn - i)
                {

                    carstoSpawn.RemoveAt(selected);
                }
            }
        }

    }

    void Update()
    {
        if (isStart)
        {
            startCounter -= Time.deltaTime;
            if(startCounter <= 0)
            {
                countdownCurrent--;
                startCounter = timeBetweenStartCount;
                UIManager.instance.countdown.text = countdownCurrent + "!";

                if (countdownCurrent == 0)
                {
                    isStart = false;
                    UIManager.instance.countdown.gameObject.SetActive(false);
                    UIManager.instance.go.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (posCheckCount <= 0)
            {
                playerPos = 1;

                foreach (CarContoler aicar in allAICars)
                {
                    if (aicar.current > playerCar.current)
                    {
                        playerPos++;
                    }
                    else if (aicar.current == playerCar.current)
                    {
                        if (aicar.nextCheckpoint > playerCar.nextCheckpoint)
                        {
                            playerPos++;
                        }
                        else if (aicar.nextCheckpoint == playerCar.nextCheckpoint)
                        {
                            // Indeks sınırları kontrolü
                            if (aicar.nextCheckpoint >= 0 && aicar.nextCheckpoint < allcheckPoints.Length)
                            {
                                if (Vector3.Distance(aicar.transform.position, allcheckPoints[aicar.nextCheckpoint].transform.position) < Vector3.Distance(playerCar.transform.position, allcheckPoints[aicar.nextCheckpoint].transform.position))
                                {
                                    playerPos++;
                                }
                            }
                        }
                    }
                }

                UIManager.instance.posText.text = playerPos + "/" + (allAICars.Count + 1);
            }
        }
    }
    public void fisih()
    {
        racecomp = true;

        UIManager.instance.resultsScreen.SetActive(true);

        switch (playerPos)
        {
            case 1:
                UIManager.instance.resulttext.text = "You finished 1st";
                break;

            case 2:
                UIManager.instance.resulttext.text = "You finished 2nd";
                break;

            case 3:
                UIManager.instance.resulttext.text = "You finished 3rd";
                break;

            default:
                UIManager.instance.resulttext.text = "You finished " + playerPos + "th";
                break;
        }

        

    }
    public void ExitRace()
    {
        SceneManager.LoadScene(raceCompleteScene);
    }
}