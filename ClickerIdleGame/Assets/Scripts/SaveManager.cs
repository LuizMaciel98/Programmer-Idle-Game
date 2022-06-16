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
        SaveBigDouble(MONEY, GameManager.Money);
        PlayerPrefs.SetString(OFFLINE_TIME, DateTime.Now.ToBinary().ToString());
    }

    public static void SaveMoneyClickPower() {
        SaveBigDouble(MONEY_CLICKPOWER, GameManager.MoneyClickPower);
    }

    public static void SaveCodeLines() {
        SaveBigDouble(CODE_LINES, GameManager.CodeLines);
        PlayerPrefs.SetString(OFFLINE_TIME, DateTime.Now.ToBinary().ToString());
    }

    public static void SaveCodeLinesClickPower() {
        SaveBigDouble(CODE_CLICK_POWER, GameManager.MoneyClickPower);
    }

    public static void SaveCurrentProject() {
        PlayerPrefs.SetString(CURRENT_PROJECT, GameManager.CurrentProject);
    }

    public static void SaveCurrentProjectCodeLinePrice() {
        SaveBigDouble(CURRENT_PROJECT_CODE_LINE_PRICE, GameManager.ProjectCodeLinePrice);
    }

    public static void SaveCurrentProjectMoneyEarning() {
        SaveBigDouble(CURRENT_PROJECT_MONEY_EARNING, GameManager.ProjectMoneyEarning);
    }

    public static BigDouble LoadMoney() {
        return LoadBigDouble(MONEY, "0");
    }

    public static BigDouble LoadMoneyClickPower() {
        return LoadBigDouble(MONEY_CLICKPOWER, "1");
    }

    public static BigDouble LoadCodeLines() {
        return LoadBigDouble(CODE_LINES, "0");
    }

    public static BigDouble LoadCodeLinesClickPower() {
        return LoadBigDouble(CODE_CLICK_POWER, "1");
    }

    public static String LoadCurrentProject() {
        return PlayerPrefs.GetString(CURRENT_PROJECT, "");
    }

    public static BigDouble LoadCurrentProjectCodeLinePrice() {
        return LoadBigDouble(CURRENT_PROJECT_CODE_LINE_PRICE, "0");
    }

    public static BigDouble LoadCurrentProjectMoneyEarning() {
        return LoadBigDouble(CURRENT_PROJECT_MONEY_EARNING, "0");
    }

    private static void SaveBigDouble(String PrefsName, BigDouble SaveValue) {
        PlayerPrefs.SetString(PrefsName, SaveValue.ToString());
    }

    private static BigDouble LoadBigDouble(String PrefsName, String DefaultValue) {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString(PrefsName, DefaultValue).Replace(".", ","));
    }
}
