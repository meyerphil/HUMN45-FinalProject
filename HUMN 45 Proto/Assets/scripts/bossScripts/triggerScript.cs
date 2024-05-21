using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class triggerScript : MonoBehaviour
{   
    public GameObject canvas;

    private bool inside = false;

    private bool insideUpper = false;

    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {

        if(inside && insideUpper){
            Debug.Log("Together");
            // cue ending in 2 seconds
            StartCoroutine(ending());
        }
    
    }

    IEnumerator ending()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        canvas.SetActive(true);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            inside = true;

        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            insideUpper = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("tag " + other.tag);
        if (other.CompareTag("LowerPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            inside = false;
        }

        if (other.CompareTag("UpperPlayer")) // Check if the entering object is tagged as "Player" (you can adjust the tag as needed)
        {
            insideUpper = false;
        }
    }
}
