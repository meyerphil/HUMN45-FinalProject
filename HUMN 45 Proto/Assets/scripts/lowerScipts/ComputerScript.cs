using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerScript : MonoBehaviour
{
    public lowerInteractions lowerInteractions;
    public TMP_Text promptUI;
    public Image computerPromptPanel;
    private string prompt;
    private bool inside = false;
    
    // upper
    public upperInteractions upperInteractions;
    public TMP_Text promptUIUpper;
    public Image computerPromptPanelUpper;
    private string promptUpper;
    private bool insideUpper = false;

    // Start is called before the first frame update
    void Start()
    {        
        lowerInteractions = GameObject.Find("LowerInteractions").GetComponent<lowerInteractions>();
        promptUI = GameObject.Find("ComputerPromptUI").GetComponent<TMP_Text>();
        computerPromptPanel = GameObject.Find("ComputerPromptPanel").GetComponent<Image>();

        // hide prompt
        computerPromptPanel.enabled = false;
        promptUI.enabled = false;


        // upper
        lowerInteractions = GameObject.Find("UpperInteractions").GetComponent<lowerInteractions>();
        promptUIUpper = GameObject.Find("UpperComputerPromptUI").GetComponent<TMP_Text>();
        computerPromptPanelUpper = GameObject.Find("UpperComputerPromptPanel").GetComponent<Image>();

        // hide prompt
        computerPromptPanelUpper.enabled = false;
        promptUIUpper.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPrompt(string inPrompt){
        prompt = inPrompt;
        promptUI.text = prompt;
    }

        public void setUpperPrompt(string inPrompt){
        promptUpper = inPrompt;
        promptUIUpper.text = promptUpper;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            computerPromptPanel.enabled = true;
            promptUI.enabled = true;
            inside = true;

        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            computerPromptPanelUpper.enabled = true;
            promptUIUpper.enabled = true;
            insideUpper = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            computerPromptPanel.enabled = false;
            promptUI.enabled = false;
            inside = false;
        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            computerPromptPanelUpper.enabled = false;
            promptUIUpper.enabled = false;
            insideUpper = false;
        }
    }
}
