using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class SaveManager : MonoBehaviour {

    private const string OFFLINE_TIME = "offlineTime";

    private const string MONEY = "money";
    private const string MONEY_CLICKPOWER = "clickPower";
    private const string CODE_LINES = "codeLines";
    private const string CODE_CLICK_POWER = "codeClickPower";

    private const string CURRENT_PROJECT = "currentProject";
    private const string CURRENT_PROJECT_CODE_LINE_PRICE = "currentProjectCodeLinePrice";
    private const string CURRENT_PROJECT_MONEY_EARNING = "currentProjectMoneyEarning";

    public static void SaveMoney() {
        PlayerPrefs.SetString(MONEY, GameManager.Money.ToString());
        PlayerPrefs.SetString(OFFLINE_TIME, DateTime.Now.ToBinary().ToString());
    }

    public static void SaveMoneyClickPower() {
        PlayerPrefs.SetString(MONEY_CLICKPOWER, GameManager.MoneyClickPower.ToString());
    }

    public static void SaveCodeLines() {
        PlayerPrefs.SetString(CODE_LINES, GameManager.CodeLines.ToString());
        PlayerPrefs.SetString(OFFLINE_TIME, DateTime.Now.ToBinary().ToString());
    }

    public static void SaveCodeLinesClickPower() {
        PlayerPrefs.SetString(CODE_CLICK_POWER, GameManager.MoneyClickPower.ToString());
    }

    public static void SaveCurrentProject() {
        PlayerPrefs.SetString(CURRENT_PROJECT, GameManager.CurrentProject);
    }

    public static void SaveCurrentProjectCodeLinePrice() {
        PlayerPrefs.SetString(CURRENT_PROJECT_CODE_LINE_PRICE, GameManager.ProjectCodeLinePrice.ToString());
    }

    public static void SaveCurrentProjectMoneyEarning() {
        PlayerPrefs.SetString(CURRENT_PROJECT_MONEY_EARNING, GameManager.ProjectMoneyEarning.ToString());
    }

    public static BigDouble LoadMoney() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(MONEY, "0"));
    }

    public static BigDouble LoadMoneyClickPower() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(MONEY_CLICKPOWER, "1"));
    }

    public static BigDouble LoadCodeLines() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(CODE_LINES, "0"));
    }

    public static BigDouble LoadCodeLinesClickPower() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(CODE_CLICK_POWER, "1"));
    }

    public static String LoadCurrentProject() {
        return PlayerPrefs.GetString(CURRENT_PROJECT, "");
    }

    public static BigDouble LoadCurrentProjectCodeLinePrice() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(CURRENT_PROJECT_CODE_LINE_PRICE, "0"));
    }

    public static BigDouble LoadCurrentProjectMoneyEarning() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(CURRENT_PROJECT_MONEY_EARNING, "0"));
    }
}
