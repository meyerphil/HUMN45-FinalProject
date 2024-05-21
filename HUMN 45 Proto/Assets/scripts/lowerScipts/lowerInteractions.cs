using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lowerInteractions : MonoBehaviour
{
    private int wallet;
    private int paycheck = 150;
    private string news = "no news for you.";
    private TMP_Text walletUI;
    private TMP_Text lowerTasksList;
    private TMP_Text walletErrorUI;
    private ComputerScript computer;
    
    public int[] clothesToBuy;
    public int[] foodToBuy;
    public int[] natureToExplore;

    public GameObject player;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        wallet = 0;
        walletUI = GameObject.Find("lowerWalletUI").GetComponent<TMP_Text>();
        walletErrorUI = GameObject.Find("lowerWalletError").GetComponent<TMP_Text>();
        lowerTasksList = GameObject.Find("lowerTasksList").GetComponent<TMP_Text>();
        computer = GameObject.Find("ComputerCollider").GetComponent<ComputerScript>();
        player = GameObject.Find("Red");
        initialPosition = player.transform.position;

        walletErrorUI.enabled = false;

        clothesToBuy = new int[2];

        foodToBuy = new int[2];

        natureToExplore = new int[2];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initDay(){
        wallet += paycheck;

        clothesToBuy[0] = 0;
        clothesToBuy[1] = Random.Range(0,3);

        foodToBuy[0] = 0;
        foodToBuy[1] = Random.Range(0, 5);

        natureToExplore[0] = 0;
        natureToExplore[1] = Random.Range(0, 10);


        // set up news

        news = "no news for you.";


        int newsOutcome = Random.Range(0, 100);
        if(newsOutcome > 70 && newsOutcome < 90){
            news = "You got promoted through our computer.\n+$20 to paycheck";
            paycheck += 20;
        }

        if(newsOutcome > 10 && newsOutcome < 50){
            news = "Your job application was rejected.";
        }

        if(newsOutcome > 90 && newsOutcome < 100){
            news = "Application accepted.\nCongrats on a better job.";
            paycheck += 50;
        }

        computer.setPrompt("I provided your daily tasks.\nDo them.\n\n" 
                            + playerNews() 
                + "\n\n+$" + getPayCheck() + " is your daily pay.");

        updateTaskList();
        updateWallet();
        ResetPlayerPosition();
    }

    public bool completedDay(){
        if (clothesToBuy[0] >= clothesToBuy[1]
            && foodToBuy[0] >= foodToBuy[1]
            && natureToExplore[0] >= natureToExplore[1]){
                return true;
        }
        return false;
    }

    public int getPayCheck(){
        Debug.Log("paycheck" + paycheck);
        return paycheck;
    }

    public string playerNews(){
        return news;
    }

    void ResetPlayerPosition()
    {
        player.transform.position = initialPosition;
    }

    void updateWallet(){
        walletUI.text = "DigiCoin: " + wallet;
    }

    public void spend(int price, string itemType){
        if(wallet - price < 0){ // will be negative
            StartCoroutine(ErrorFunds());
            return;
        }

        wallet -= price;
        updateWallet();

        if(itemType == "clothes"){
            clothesToBuy[0]++;
            updateTaskList();
        }

        if(itemType == "food"){
            foodToBuy[0]++;
            updateTaskList();
        }

        if(itemType == "nature"){
            natureToExplore[0]++;
            updateTaskList();
        }
    }

    IEnumerator ErrorFunds()
    {
        // Set the GameObject active
        walletErrorUI.enabled = true;

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        // After 0.5 seconds, deactivate the GameObject
        walletErrorUI.enabled = false;
    }


    void updateTaskList(){
        string temp = "";
        if(clothesToBuy[1] > 0){
            temp += "[" + clothesToBuy[0] + "/" + clothesToBuy[1] + "] Clothes to buy\n";
        }

        if(foodToBuy[1] > 0){
            temp += "[" + foodToBuy[0] + "/" + foodToBuy[1] + "] Food to buy\n";
        }

        if(natureToExplore[1] > 0){
            temp += "[" + natureToExplore[0] + "/" + natureToExplore[1] + "] Nature to explore\n";
        }

        lowerTasksList.text = temp;
    }

}
