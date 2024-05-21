using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buyScript : MonoBehaviour
{   
    public lowerInteractions lowerInteractions;
    public TMP_Text promptUI;
    public Image lowerPromptPanel;   
    private bool inside = false;

    // upper
    public upperInteractions upperInteractions;
    public TMP_Text promptUIUpper;
    public Image upperPromptPanel;
    private string promptUpper;
    private bool insideUpper = false;
    
    public int price;
    public string prompt;
    public string itemType;


    // Start is called before the first frame update
    void Start()
    {        
        promptUI = GameObject.Find("lowerPromptUI").GetComponent<TMP_Text>();
        lowerInteractions = GameObject.Find("LowerInteractions").GetComponent<lowerInteractions>();
        lowerPromptPanel = GameObject.Find("lowerPromptPanel").GetComponent<Image>();

        // hide prompt
        lowerPromptPanel.enabled = false;
        promptUI.enabled = false;


        // UPPER
        promptUIUpper = GameObject.Find("upperPromptUI").GetComponent<TMP_Text>();
        upperInteractions = GameObject.Find("UpperInteractions").GetComponent<upperInteractions>();
        upperPromptPanel = GameObject.Find("upperPromptPanel").GetComponent<Image>();

        // hide prompt
        upperPromptPanel.enabled = false;
        promptUIUpper.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(inside){
            if (Input.GetKeyDown(KeyCode.E)){
                lowerInteractions.spend(price, itemType);
            }
        }

        if(insideUpper){
            if (Input.GetKeyDown(KeyCode.M)){
                upperInteractions.spend(price, itemType);
            }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            lowerPromptPanel.enabled = true;
            promptUI.enabled = true;
            promptUI.text = prompt; // Change the text of the Text UI object
            inside = true;

        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            upperPromptPanel.enabled = true;
            promptUIUpper.enabled = true;
            promptUIUpper.text = prompt; // Change the text of the Text UI object
            insideUpper = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            lowerPromptPanel.enabled = false;
            promptUI.enabled = false;
            inside = false;
        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            upperPromptPanel.enabled = false;
            promptUIUpper.enabled = false;
            insideUpper = false;
        }
    }
}
