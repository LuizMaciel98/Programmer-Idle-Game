using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float money;
    public static float clickPower;
    public static float iddleGain {
        get {
            float result = 0;

            var buttonObject = FindObjectsOfType<Button>();
            for(int i = 0; i < buttonObject.Length; i ++){
                var button = buttonObject[i];
                UpgradeButtonController upgradeButton = button.GetComponent<UpgradeButtonController>();
                if(upgradeButton != null && upgradeButton.isIddleGain){
                    result += upgradeButton.totalPurchased * upgradeButton.upgradeIncrease;
                    //Debug.Log(button.name + " iddleGain: " + upgradeButton.totalPurchased * upgradeButton.upgradeIncrease);
                }
            }
            //Debug.Log(" iddleGain " + result);

            return result;
        }
    }

    // Start is called before the first frame update
    void Start() {
        
        clickPower = PlayerPrefs.GetFloat("clickPower", 1);
        money = PlayerPrefs.GetFloat("money", 0);
    }

    public void Update() {

        if(iddleGain > 0){
            money += iddleGain * Time.deltaTime;
            GameManager.SaveMoney();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public static void SaveMoney() {
        PlayerPrefs.SetFloat("money", GameManager.money);
        PlayerPrefs.SetFloat("clickPower", GameManager.clickPower);
    }
}
