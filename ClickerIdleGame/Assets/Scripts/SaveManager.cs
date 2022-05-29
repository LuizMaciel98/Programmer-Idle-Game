using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveMoney() {
        PlayerPrefs.SetFloat("money", GameManager.Money);
        PlayerPrefs.SetString("offlineTime", DateTime.Now.ToBinary().ToString());
    }

    public static void SaveClickPower() {
        PlayerPrefs.SetFloat("clickPower", GameManager.ClickPower);
    }

    public static float LoadMoney() {
        return PlayerPrefs.GetFloat("money", 0);
    }

    public static float LoadClickPower() {
        return PlayerPrefs.GetFloat("clickPower", 1);
    }
}
