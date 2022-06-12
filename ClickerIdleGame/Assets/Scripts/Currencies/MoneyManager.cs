using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class MoneyManager : MonoBehaviour {

    private static BigDouble _IdleGain;
    private static bool hasIdleBeenChecked = false;

    public static BigDouble Money;
    public static BigDouble ClickPower;
    public static BigDouble IdleGain {
        get {
            if(!hasIdleBeenChecked) {
                _IdleGain = UpdateIdleGain();
                hasIdleBeenChecked = true;
            }

            return _IdleGain;
        }
    }

    void Start() {
        Money = SaveManager.LoadMoney();
        ClickPower = SaveManager.LoadMoneyClickPower();
    }

    void Update() {
        if(IdleGain > 0) {
            Money += IdleGain * Time.deltaTime;
            SaveManager.SaveMoney();
        }
    }

    public static BigDouble UpdateIdleGain(){
        Debug.Log("UpdateIdleGain");
        BigDouble result = 0;

        var buttonObject = FindObjectsOfType<Button>();
        for(int i = 0; i < buttonObject.Length; i ++){
            var button = buttonObject[i];
            UpgradeButtonController UpgradeButton = button.GetComponent<UpgradeButtonController>();
            if(UpgradeButton != null && UpgradeButton.IsIdleGain && UpgradeButton.TotalPurchased > 0){
                Debug.Log(button.name);
                Debug.Log(UpgradeButton.TotalPurchased);
                Debug.Log(UpgradeButton.UpgradeIncrease);
                result += UpgradeButton.TotalPurchased * UpgradeButton.UpgradeIncrease;
            }
        }

        Debug.Log("UpdateIdleGain result : " + result);

        _IdleGain = result;

        return result;
    }

    public static bool HasAnyIdleGains() {
        Debug.Log("GameManager.HasAnyIdleGains");
        Debug.Log("IdleGain > 0 : " + (IdleGain > 0));
        return IdleGain > 0;
    }
}
