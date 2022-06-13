using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using BreakInfinity;

public class ProjectItemButtonController : MonoBehaviour {

    public string ProjectName;

    public double BaseMoneyEarning;
    public double BaseCodeLinePrice;

    public Button ChooseButton;

    public Text moneyEarning;
    public Text codeLinePrice;

    private double MoneyEarning {
        get {
            return BaseMoneyEarning;
        }
    }

    private double CodeLinePrice {
        get {
            return BaseCodeLinePrice;
        }
    }

    void Update() {
        moneyEarning.text = MoneyEarning.ToString("F2");
        codeLinePrice.text = CodeLinePrice.ToString("F0");
    }

    public void ChooseCurrentButton() {
        ProjectManager.SelectedProject = ProjectName;
        ProjectManager.CodeLinePrice = CodeLinePrice;
        ProjectManager.MoneyEarning = MoneyEarning;

        SaveManager.SaveCurrentProject();
    }

}
