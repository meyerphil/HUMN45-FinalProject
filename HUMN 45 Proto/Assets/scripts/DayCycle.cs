using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCycle : MonoBehaviour
{
    public GameObject menu;
    public GameObject results;
    public GameObject BreakOut;
    public lowerInteractions lowerInteractions;
    public upperInteractions upperInteractions;
    public float time;
    public float timeSpeed;
    private TMP_Text TimeUI;
    private bool timeRunning;

    private int days = 0;

    private TMP_Text lowerResults;
    private TMP_Text upperResults;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("menu");
        results = GameObject.Find("results");
        BreakOut = GameObject.Find("BreakOut");
        lowerInteractions = GameObject.Find("LowerInteractions").GetComponent<lowerInteractions>();
        upperInteractions = GameObject.Find("UpperInteractions").GetComponent<upperInteractions>();
        TimeUI = GameObject.Find("TimeUI").GetComponent<TMP_Text>();
        timeSpeed = 0.3f;
        
        timeRunning = false;

        lowerResults = GameObject.Find("lowerResults").GetComponent<TMP_Text>();
        upperResults = GameObject.Find("upperResults").GetComponent<TMP_Text>();
        
        menu.SetActive(true);
        results.SetActive(false);
        BreakOut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(timeRunning){
            time+= timeSpeed * Time.deltaTime;
            //Debug.Log(time);
            TimeUI.text = "Time: " + (int)time + ":00";

            if(time > 21){
                timeRunning = false;
                //menu.SetActive(true);
                checkResults();
                
            }
        }

    }

    void checkResults(){
        results.SetActive(true);
        if(days > 3){
            BreakOut.SetActive(true);
        }

        if(lowerInteractions.completedDay()){
            lowerResults.text = "Daily Results\n______________\n\nYou completed \nall of your tasks.\n\nCool.";
        } else {
            lowerResults.text = "Daily Results\n______________\n\nYou did not \nfinish your tasks.\n\n That will be\non your record.";
        }

        if(upperInteractions.completedDay()){
            upperResults.text = "Daily Results\n______________\n\nYou completed \nall of your tasks.\n\nAs expected from you, nice work.";
        } else {
            upperResults.text = "Daily Results\n______________\n\nYou did not \nfinish your tasks.\n\n Try tomorrow.";
        }
    }

    public void startDay(){
        days++;
        time = 8.0f;
        timeRunning = true;
        menu.SetActive(false);
        results.SetActive(false);
        BreakOut.SetActive(false);
        lowerInteractions.initDay();
        upperInteractions.initDay();
    }

    public bool TimeRunning(){
        return timeRunning;
    }
}
