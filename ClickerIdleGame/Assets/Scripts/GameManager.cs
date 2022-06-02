using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class GameManager : MonoBehaviour
{

    private static BigDouble _IdleGain;
    private static bool hasIdleBeenChecked = false;

    public static BigDouble Money;
    public static BigDouble ClickPower;
    public static BigDouble IddleGain {
        get {
            if(!hasIdleBeenChecked) {
                _IdleGain = UpdateIdleGain();
                hasIdleBeenChecked = true;
            }

            return _IdleGain;
        }
    }

    // Start is called before the first frame update
    void Start() {
        Money = SaveManager.LoadMoney();
        ClickPower = SaveManager.LoadClickPower();
    }

    public void Update() {

        if(IddleGain > 0) {
            Money += IddleGain * Time.deltaTime;
            SaveManager.SaveMoney();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public static BigDouble UpdateIdleGain(){
        Debug.Log("UpdateIdleGain");
        BigDouble result = 0;

        var buttonObject = FindObjectsOfType<Button>();
        for(int i = 0; i < buttonObject.Length; i ++){
            var button = buttonObject[i];
            UpgradeButtonController UpgradeButton = button.GetComponent<UpgradeButtonController>();
            if(UpgradeButton != null && UpgradeButton.IsIddleGain && UpgradeButton.TotalPurchased > 0){
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
        Debug.Log("IddleGain > 0 : " + (IddleGain > 0));
        return IddleGain > 0;
    }
}
