using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIAndParticlesManager : MonoBehaviour {

    public ParticleSystem codeParticleSystem;
    
    public Text TotalMoney;
    // public Text MoneyClickPower;
    public Text MoneyIdleGain;

    public Text TotalCodeLines;
    public Text CodeLinesClickPower;
    public Text CodeLinesIdleGain;

    public Text projectSelected;

    void Update() {
        TotalMoney.text = "$: " + GameManager.Money.ToString("F2");
        // MoneyClickPower.text = "Click power \n$: " + GameManager.MoneyClickPower.ToString("F0");
        MoneyIdleGain.text = GameManager.MoneyIdleGain.ToString("F2") + "$ per second";

        TotalCodeLines.text = "Code Lines: " + GameManager.CodeLines.ToString("F0");
        CodeLinesClickPower.text = "Code Lines\nClick Power:\n" + GameManager.CodeLinesClickPower.ToString("F0");
        CodeLinesIdleGain.text = GameManager.CodeLinesIdleGain.ToString("F0") + " Code Lines\nPer Second";

        handleProjectSelect();
    }

    private void handleProjectSelect() {
        if(GameManager.CurrentProject == null || GameManager.CurrentProject == "") {
            projectSelected.text = "Please Select a project!";
        } else {
            projectSelected.text = "Making Project:\n" + GameManager.CurrentProject;
        }
    }

    public void EmitCodeParticle() {
        var emitParams = new ParticleSystem.EmitParams();
        // // emitParams.startColor = Color.red;
        // // emitParams.startSize = 0.2f;
        codeParticleSystem.Play();
        codeParticleSystem.Emit(emitParams, 1);
        codeParticleSystem.Stop();
    }
}
