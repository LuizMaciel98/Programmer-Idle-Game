using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;

public class OfflineManager : MonoBehaviour {

    public GameObject OfflinePopUp;

    public Text AwayTimeText;
    public Text GainInfoText;

    void Start() {
        Debug.Log("OfflineManager.Start");
        if(HasAnyIdleGains() && HasOfflineTime()){
            OpenOffline();
            LoadOfflineProduction();
        }
    }

    private void OpenOffline(){
        Debug.Log("OpenOffline");
        OfflinePopUp.gameObject.SetActive(true);
    }

    public void CloseOffline(){
        OfflinePopUp.gameObject.SetActive(false);
    }

    private void LoadOfflineProduction() {
        if(HasOfflineTime()) {
            var TempOfflineTime = Convert.ToInt64(PlayerPrefs.GetString("offlineTime"));
            var OldTime = DateTime.FromBinary(TempOfflineTime);
            var CurrentTime = DateTime.Now;

            var Difference = CurrentTime.Subtract(OldTime);
            var RawTime = (float) Difference.TotalSeconds;

            TimeSpan Timer = TimeSpan.FromSeconds(RawTime);

            AwayTimeText.text = $"You were away for\n<color=#00FFFF>{Timer:dd\\:hh\\:mm\\:ss}</color>";

            BigDouble MoneyGains = RawTime * GameManager.IddleGain;

            String MoneyGainsText = MoneyGains.ToString("F0");

            GainInfoText.text = $"You earned:\n<color=Yellow>+{MoneyGainsText}</color>";

            GameManager.Money += MoneyGains;
            SaveManager.SaveMoney();
        }
    }

    private bool HasAnyIdleGains(){
        return GameManager.HasAnyIdleGains();
    }

    private bool HasOfflineTime(){
        string OfflineTimeString = PlayerPrefs.GetString("offlineTime");

        return OfflineTimeString != null && OfflineTimeString != "";
    }


}
