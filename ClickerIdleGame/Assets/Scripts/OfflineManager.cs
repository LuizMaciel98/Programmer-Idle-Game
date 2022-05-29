using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineManager : MonoBehaviour {

    public GameObject OfflinePopUp;

    public Text AwayTimeText;
    public Text GainInfoText;

    void Start() {
        LoadOfflineProduction();
    }

    public void LoadOfflineProduction(){
        
        string OfflineTimeString = PlayerPrefs.GetString("offlineTime");

        if(OfflineTimeString != null && OfflineTimeString != "") {
            var TempOfflineTime = Convert.ToInt64(PlayerPrefs.GetString("offlineTime"));
            var OldTime = DateTime.FromBinary(TempOfflineTime);
            var CurrentTime = DateTime.Now;

            var Difference = CurrentTime.Subtract(OldTime);
            var RawTime = (float) Difference.TotalSeconds;

            var OfflineTime = RawTime / 10;



            TimeSpan Timer = TimeSpan.FromSeconds(RawTime);

            AwayTimeText.text = $"You were away for\n<color=#00FFFF>{Timer:dd\\:hh\\:mm\\:ss}</color>";

            float MoneyGains = OfflineTime * GameManager.IddleGain;

            String MoneyGainsText = MoneyGains.ToString("F0");

            GainInfoText.text = $"You earned:\n<color=Yellow>+{MoneyGainsText}</color>";

            GameManager.Money += MoneyGains;
            SaveManager.SaveMoney();
            //BigDouble coinsGains;
        }

    }

    public void CloseOffline(){
        OfflinePopUp.gameObject.SetActive(false);
    }

}
