using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int money;
    public static int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = PlayerPrefs.GetInt("multiplier", 1);
        money = PlayerPrefs.GetInt("money", 0);
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public static void SaveMoney(){
        PlayerPrefs.SetInt("money", GameManager.money);
        PlayerPrefs.SetInt("multiplier", GameManager.multiplier);
    }
}
