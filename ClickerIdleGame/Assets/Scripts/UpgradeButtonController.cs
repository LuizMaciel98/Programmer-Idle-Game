using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class UpgradeButtonController : MonoBehaviour {

    public bool IsIdleGain;
    public Button UpgradeButton;
    public Text UpgradeCostText;
    public Text UpgradeIncreaseText;

    public double UpgradeBaseIncrease;
    public double UpgradeBaseCost;
    public double UpgradeCostInterestRate;

    public int TotalPurchased;

    //Later this can be increased by some percent formula
    private BigDouble UpgradeCost {
        get {
            BigDouble result = UpgradeBaseCost;

            double interestRate = UpgradeCostInterestRate/100;

            // if(TotalPurchased != null && TotalPurchased > 0){

            // if (TotalPurchased == 1) {
            //     result = result * (1 + interestRate);
            // } if (TotalPurchased > 1) {
                for(int i = 1; i < TotalPurchased+1; i++) {
                    result = result * (1 + interestRate);
                }
            // }

            // }

            Debug.Log(UpgradeButton.name + " UpgradeCust " + result.ToString("F2"));
            // Debug.Log(result);
            return result;
        }
    }

    public double UpgradeIncrease {
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

        if(IsIdleGain){
            HandleIdleGainIncrease();
        } else {
            HandleClickPowerIncrease();
        }

        SaveTotalPurchased();

        SaveManager.SaveMoney();
    }

    private void HandleClickPowerIncrease() {
        GameManager.MoneyClickPower += UpgradeBaseIncrease;
        SaveManager.SaveMoneyClickPower();
    }

    private void handleButtonTextValues() {
        UpgradeCostText.text = "$ " + UpgradeCost.ToString("F2");
        if(IsIdleGain){
            UpgradeIncreaseText.text = "Iddle\n+" + UpgradeIncrease.ToString("F2") + " /s";
        } else {
            UpgradeIncreaseText.text = "Click\n+ " + UpgradeIncrease.ToString("F2");
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
