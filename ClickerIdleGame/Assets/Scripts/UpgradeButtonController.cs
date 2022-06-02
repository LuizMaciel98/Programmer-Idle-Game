using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class UpgradeButtonController : MonoBehaviour {

    public bool IsIddleGain;
    public Button UpgradeButton;
    public Text UpgradeCostText;
    public Text UpgradeIncreaseText;

    public int UpgradeBaseIncrease;
    public int UpgradeBaseCost;
    public int IncreaseBasePercentage;

    public int TotalPurchased;

    //Later this can be increased by some percent formula
    private int UpgradeCost {
        get { return UpgradeBaseCost; }
    }

    public int UpgradeIncrease {
        get { return UpgradeBaseIncrease; }
    }

    //Initialize the purchased for every upgrade button
    void Start () {
        TotalPurchased = PlayerPrefs.GetInt(UpgradeButton.name, 0);
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
            UpgradeButton.interactable = true;
        } else {
            UpgradeButton.interactable = false;
        }
    }

    //Handle every buy actions like decrease money, increase click power, savew money
    private void handleBuyActions(){

        GameManager.Money -= UpgradeCost;

        if(IsIddleGain){
            HandleIdleGainIncrease();
        } else {
            HandleClickPowerIncrease();
        }

        SaveTotalPurchased();

        SaveManager.SaveMoney();
    }

    private void HandleClickPowerIncrease() {
        GameManager.ClickPower += UpgradeBaseIncrease;
        SaveManager.SaveClickPower();
    }

    private void handleButtonTextValues() {
        UpgradeCostText.text = "$ " + UpgradeCost;
        if(IsIddleGain){
            UpgradeIncreaseText.text = "Iddle\n+" + UpgradeIncrease + " /s";
        } else {
            UpgradeIncreaseText.text = "Click\n+ " + UpgradeIncrease;
        }
    }

    private bool canBuy(){
        return GameManager.Money >= UpgradeCost;
    }

    private void SaveTotalPurchased(){
        //Debug.Log("saveTotalPurchased");
        TotalPurchased += 1;
        //Debug.Log("totalPurchased: " + totalPurchased);
        PlayerPrefs.SetInt(UpgradeButton.name, TotalPurchased);
    }

    private void HandleIdleGainIncrease(){
        GameManager.UpdateIdleGain();
    }
}
