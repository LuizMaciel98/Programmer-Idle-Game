using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour {

    public bool isIddleGain;
    public Button upgradeButton;
    public Text upgradeCostText;
    public Text upgradeIncreaseText;

    public int upgradeBaseIncrease;
    public int upgradeBaseCost;

    public int totalPurchased;

    //Later this can be increased by some percent formula
    private int upgradeCost {
        get { return upgradeBaseCost; }
    }

    public int upgradeIncrease {
        get { return upgradeBaseIncrease; }
    }

    //Initialize the purchased for every upgrade button
    void Start () {
        totalPurchased = PlayerPrefs.GetInt(upgradeButton.name, 0);
    }

    public void Buy() {
        // Debug.Log("Tried to buy: " + upgradeButton.name);
        if(canBuy()){
            handleBuyActions();
        }
    }

    void Update() {
        // Debug.Log("UpgradeButtonController update");
        handleButonInteractive();
        handleButtonTextValues();
    }

    //Turns button disabled or enabled by the current money
    private void handleButonInteractive(){
        if(canBuy()){
            upgradeButton.interactable = true;
        } else {
            upgradeButton.interactable = false;
        }
    }

    //Handle every buy actions like decrease money, increase click power, savew money
    private void handleBuyActions(){

        GameManager.money -= upgradeCost;

        if(isIddleGain){

        } else {
            GameManager.clickPower += upgradeBaseIncrease;
        }

        saveTotalPurchased();

        GameManager.SaveMoney();
    }

    private void handleButtonTextValues(){
        upgradeCostText.text = "$ " + upgradeCost;
        if(isIddleGain){
            upgradeIncreaseText.text = "Iddle\n+" + upgradeIncrease + " /s";
        } else {
            upgradeIncreaseText.text = "Click\n+ " + upgradeIncrease;
        }
    }

    private bool canBuy(){
        return GameManager.money >= upgradeCost;
    }

    private void saveTotalPurchased(){
        //Debug.Log("saveTotalPurchased");
        totalPurchased += 1;
        //Debug.Log("totalPurchased: " + totalPurchased);
        PlayerPrefs.SetInt(upgradeButton.name, totalPurchased);
    }
}
