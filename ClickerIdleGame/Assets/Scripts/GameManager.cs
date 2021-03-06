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

    public static BigDouble ProjectCodeLinePrice {
        get {
            return ProjectManager.CodeLinePrice;
        }
        set {
            ProjectManager.CodeLinePrice = value;
        }
    }

    public static BigDouble ProjectMoneyEarning {
        get {
            return ProjectManager.MoneyEarning;
        }
        set {
            ProjectManager.MoneyEarning = value;
        }
    }

    public static string CurrentProject {
        get {
            return ProjectManager.SelectedProject;
        }
        set {
            ProjectManager.SelectedProject = value;
        }
    }

    public static void UpdateIdleGain() {
        //TODO
    }

    public static bool HasAnyIdleGains(){
        //TODO
        return false;
    }

    public static void IncrementCodeLines() {
        ErrorManager errorMessage = GameObject.Find("Error Manager").GetComponent<ErrorManager>();

        if(HasAnySelectedProject()) {


            errorMessage.solveMissingSelectedProject();
            CodeLines += CodeLinesClickPower;
            SaveManager.SaveCodeLines();

            ProgressBarController.IncrementProgress();
            MakeProject();

            UIAndParticlesManager UIParticleManager = GameObject.Find("UI and Particle Manager").GetComponent<UIAndParticlesManager>();
            UIParticleManager.EmitCodeParticle();
        } else {
            errorMessage.triggerMissingSelectedProject();
        }
    }

    public void Update() {

        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }

    private static void MakeProject() {
        if(CodeLines >= ProjectCodeLinePrice) {
            CodeLines -= ProjectCodeLinePrice;
            Money += ProjectMoneyEarning;

            if(CodeLines > 0) {
                ProgressBarController.IncrementProgress();
            } else {
                ProgressBarController.FinishProject();
            }
        }
    }

    private static bool HasAnySelectedProject() {
        return CurrentProject != null && CurrentProject != "";
    }
}
