using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class GameManager : MonoBehaviour {

    public static BigDouble Money {
        get {
            return MoneyManager.Money;
        }
        set {
            MoneyManager.Money = value;
        }
    }

    public static BigDouble MoneyClickPower {
        get {
            return MoneyManager.ClickPower;
        }
        set {
            MoneyManager.ClickPower = value;
        }
    }

    public static BigDouble MoneyIdleGain {
        get {
            return MoneyManager.IdleGain;
        }
        // set {
        //     MoneyManager.IdleGain = value;
        // }
    }

    public static BigDouble CodeLines {
        get {
            return CodeLinesManager.CodeLines;
        }
        set {
            CodeLinesManager.CodeLines = value;
        }
    }

    public static BigDouble CodeLinesClickPower {
        get {
            return CodeLinesManager.ClickPower;
        }
        set {
            CodeLinesManager.ClickPower = value;
        }
    }

    public static BigDouble CodeLinesIdleGain {
        get {
            return CodeLinesManager.IdleGain;
        }
        // set {
        //     CodeLinesManager.IdleGain = value;
        // }
    }

    public static void UpdateIdleGain() {
        //TODO
    }

    public static bool HasAnyIdleGains(){
        //TODO
        return false;
    }

    public static void IncrementCodeLines() {

        Debug.Log(CodeLines);
        Debug.Log(CodeLinesClickPower);

        CodeLines += CodeLinesClickPower;
        SaveManager.SaveCodeLines();

        UIAndParticlesManager UIParticleManager = GameObject.Find("UI and Particle Manager").GetComponent<UIAndParticlesManager>();
        UIParticleManager.EmitCodeParticle();
    }

    public void Update() {

        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }
}
