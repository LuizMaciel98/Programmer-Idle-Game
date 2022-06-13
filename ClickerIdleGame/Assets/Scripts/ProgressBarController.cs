using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {

    private static Slider Slider;

    public float FillSpeed;
    private static BigDouble TargetProgress = 0;

    private void Awake() {
        Slider = gameObject.GetComponent<Slider>();
    }


    // Start is called before the first frame update
    // void Start() {
    //     IncrementProgress(0.75f);
    // }

    // Update is called once per frame
    void Update() {

        // Debug.Log(0.5f);

        if (Slider.value < TargetProgress) {
            // Debug.Log("Slider.value < TargetProgress");
            Slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public static void IncrementProgress() {
        Debug.Log("IncrementProgress");

        if(Slider.value == 100) {
            Slider.value = 0;
        }

        var CodeLinesPrice = GameManager.ProjectCodeLinePrice;
        var CodeLines = GameManager.CodeLines; 
        Debug.Log("CodeLinesPrice: " + CodeLinesPrice);
        Debug.Log("CodeLines: " + CodeLines);

        var newProgress = CodeLinesPrice*CodeLines/100;
        TargetProgress = newProgress*100;
    }

    public static void FinishProject() {
        TargetProgress = 100;
    }
}
