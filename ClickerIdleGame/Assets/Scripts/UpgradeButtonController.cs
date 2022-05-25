using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour {

    public Button upgradeButton;
    public Text upgradeCostText;
    public Text upgradeIncreaseText;

    public int upgradeBaseIncrease;
    public int upgradeBaseCost;

    //Later this can be increased by some percent formula
    private int upgradeCost {
        get { return upgradeBaseCost; }
    }

    private int upgradeIncrease {
        get { return upgradeBaseIncrease; }
    }

    public void Buy() {
        Debug.Log("Tried to buy");
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
        GameManager.multiplier += upgradeBaseIncrease;
        GameManager.SaveMoney();
    }

    private void handleButtonTextValues(){
        upgradeCostText.text = "$ " + upgradeCost;
        upgradeIncreaseText.text = "Click\n+ " + upgradeIncrease;
    }

    private bool canBuy(){
        return GameManager.money >= upgradeCost;
    }
}
