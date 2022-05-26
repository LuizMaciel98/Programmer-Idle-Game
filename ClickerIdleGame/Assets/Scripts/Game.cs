using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

    public Text totalMoney;
    public Text clickPower;
    public Text iddleGain;
    

    public void Increment() {
        GameManager.money += GameManager.clickPower;
        Debug.Log("GameManager.money: " + GameManager.money);
        GameManager.SaveMoney();
    }

    void Start() {

    }

    void Update() {
        totalMoney.text = "$: " + GameManager.money.ToString("F0");
        clickPower.text = "Click power \n$: " + GameManager.clickPower.ToString("F0");
        iddleGain.text = GameManager.iddleGain.ToString("F0") + "$ per second";
    }

    // private void LoadUpgradesTotal() {
    //     var buttonObject = FindObjectsOfType<Button>();
    //     for(int i = 0; i < buttonObject.Length; i ++){
    //         var botao = buttonObject[i];
    //         UpgradeButtonController upgradeButton = botao.GetComponent<UpgradeButtonController>();
    //         if(upgradeButton != null){
    //             upgradeButton.totalPurchased = PlayerPrefs.GetInt(botao.name, 0);

    //             Debug.Log(botao.name);
    //             Debug.Log(totalPurchased);
    //         }
    //     }
    // }
}
