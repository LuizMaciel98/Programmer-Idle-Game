using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

    public ParticleSystem codeParticleSystem;
    
    public Text TotalMoney;
    public Text ClickPower;
    public Text IddleGain;
    

    public void Increment() {
        GameManager.Money += GameManager.ClickPower;
        Debug.Log("GameManager.money: " + GameManager.Money);
        SaveManager.SaveMoney();


        codeParticleSystem.Play();
        var emitParams = new ParticleSystem.EmitParams();
        // emitParams.startColor = Color.red;
        // emitParams.startSize = 0.2f;
        codeParticleSystem.Emit(emitParams, 1);
        codeParticleSystem.Stop();
    }

    void Start() {

    }

    void Update() {
        TotalMoney.text = "$: " + GameManager.Money.ToString("F0");
        ClickPower.text = "Click power \n$: " + GameManager.ClickPower.ToString("F0");
        IddleGain.text = GameManager.IddleGain.ToString("F0") + "$ per second";
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
