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
}
