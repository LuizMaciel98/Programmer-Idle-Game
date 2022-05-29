using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float Money;
    public static float ClickPower;
    public static float IddleGain {
        get {
            float result = 0;

            var buttonObject = FindObjectsOfType<Button>();
            for(int i = 0; i < buttonObject.Length; i ++){
                var button = buttonObject[i];
                UpgradeButtonController UpgradeButton = button.GetComponent<UpgradeButtonController>();
                if(UpgradeButton != null && UpgradeButton.IsIddleGain){
                    result += UpgradeButton.TotalPurchased * UpgradeButton.UpgradeIncrease;
                }
            }

            return result;
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
}
