using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

    public Text ui;

    public void Increment() {
        GameManager.money += GameManager.multiplier;
    }

    public void Buy(int num) {
        Debug.Log("num: " + num);
        if(num == 1 && GameManager.money >= 25) {
            GameManager.multiplier += 1;
            GameManager.money -= 25;
            GameManager.SaveMoney();
        }

        if(num == 2 && GameManager.money >= 100) {
            GameManager.multiplier += 10;
            GameManager.money -= 100;
            GameManager.SaveMoney();
        }

        if(num == 3 && GameManager.money >= 1500) {
            GameManager.multiplier += 100;
            GameManager.money -= 1500;
            GameManager.SaveMoney();
        }
    }

    void Update() {
        ui.text = "$: " + GameManager.money;
    }
}
