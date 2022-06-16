using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using UnityEngine.UI;

public class SetupUpgradeItemController : MonoBehaviour {

    public Button UpgradeButton;

    public Text UpgradeName;
    public Text UpgradeLevel;
    public Text UpgradeCurrentBonus;
    public Text UpgradeCostText;
    public Text UpgradeIncreaseText;

    public string Level0Name;
    public BigDouble Level0Price;
    public BigDouble Level0Bonus;
    public string Level1Name;
    public BigDouble Level1Price;
    public BigDouble Level1Bonus;
    public string Level2Name;
    public BigDouble Level2Price;
    public BigDouble Level2Bonus;
    public string Level3Name;
    public BigDouble Level3Price;
    public BigDouble Level3Bonus;
    public string Level4Name;
    public BigDouble Level4Price;
    public BigDouble Level4Bonus;
    public string Level5Name;
    public BigDouble Level5Price;
    public BigDouble Level5Bonus;

    public int TotalPurchased;
    public int MaxLevel;

    private bool IsChanged = true;

    // Start is called before the first frame update
    void Start() {

    }

    void Update() {
        if(IsChanged) {

            UpdateNameText();
            UpdateLevelText();
            UpdateCurrentBonus();
            UpdateNextPrice();
            UpdateNextBonus();

            IsChanged = false;
        }
    }

    public void BuyUpgrade() {
        if(HasNotHitMaxLevel()){
            if(HasMoney()) {
                GameManager.Money -= GetNextUpgradePrice();
                TotalPurchased ++;
                IsChanged = true;
            }
        }
    }

    private bool HasMoney() {
        bool result = false;

        if(GameManager.Money <= GetNextUpgradePrice()) {
            result = true;
        }

        Debug.Log("HasMoney : " + result);
        return result;
    }

    private bool HasNotHitMaxLevel() {
        return TotalPurchased != MaxLevel;
    }

    private void UpdateNameText() {
        string[] LevelNameArray = {Level0Name, Level1Name, Level2Name, Level3Name, Level4Name, Level5Name};
        
        string CurrentName = LevelNameArray[TotalPurchased];

        UpgradeName.text = CurrentName;
    }

    private void UpdateLevelText() {
        UpgradeLevel.text = "lvl: " + TotalPurchased;
    }

    private void UpdateCurrentBonus() {
        BigDouble[] BonusValueArray = {Level0Bonus, Level1Bonus, Level2Bonus, Level3Bonus, Level4Bonus, Level5Bonus};

        BigDouble CurrentBonus = 0;

        for(int Index = 0; Index < TotalPurchased + 1; Index++) {
            CurrentBonus += BonusValueArray[Index];
        }

        UpgradeCurrentBonus.text = CurrentBonus.ToString();
    }

    private void UpdateNextPrice() {
        BigDouble[] NextPriceArray = {Level0Price, Level1Price, Level2Price, Level3Price, Level4Price, Level5Price};

        if(TotalPurchased < 5){
            string NextPrice = NextPriceArray[TotalPurchased + 1].ToString();
            UpgradeCostText.text = NextPrice;
        } else {
            UpgradeCostText.text = "MAX LEVEL";
        }
    }

    private void UpdateNextBonus() {
        BigDouble[] BonusValueArray = {Level0Bonus, Level1Bonus, Level2Bonus, Level3Bonus, Level4Bonus, Level5Bonus};
        

        if(TotalPurchased < 5){
            UpgradeIncreaseText.text = "Buy\n+ " + BonusValueArray[TotalPurchased + 1].ToString();
        } else {
            UpgradeIncreaseText.text = "MAX LEVEL";
        }
    }

    private BigDouble GetNextUpgradePrice() {
        BigDouble result = 0;
        BigDouble[] NextPriceArray = {Level0Price, Level1Price, Level2Price, Level3Price, Level4Price, Level5Price};

        if(TotalPurchased < MaxLevel) {
            result = NextPriceArray[TotalPurchased + 1];
        }

        return result;
    }
}
