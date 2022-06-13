using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class ProjectManager : MonoBehaviour {

    public static string SelectedProject;
    public static BigDouble CodeLinePrice;
    public static BigDouble MoneyEarning;

    void Start() {
        SelectedProject = SaveManager.LoadCurrentProject();
        CodeLinePrice = SaveManager.LoadCurrentProjectCodeLinePrice();
        MoneyEarning = SaveManager.LoadCurrentProjectMoneyEarning();
    }

}
