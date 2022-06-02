using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class SaveManager : MonoBehaviour
{
    public static void SaveMoney() {
        PlayerPrefs.SetString("money", GameManager.Money.ToString());
        PlayerPrefs.SetString("offlineTime", DateTime.Now.ToBinary().ToString());
    }

    public static void SaveClickPower() {
        PlayerPrefs.SetString("clickPower", GameManager.ClickPower.ToString());
    }

    public static BigDouble LoadMoney() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString("money", "0"));
    }

    public static BigDouble LoadClickPower() {
        return (BigDouble) Convert.ToDouble(PlayerPrefs.GetString("clickPower", "1"));
    }
}
