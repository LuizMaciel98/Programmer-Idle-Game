// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour {

    public string MISSING_PROJECT_MESSAGE = "You need to select a project before start coding!";

    public Text errorMessage;

    public void triggerMissingSelectedProject() {
        Debug.Log("triggerMissingSelectedProject");
        errorMessage.text = MISSING_PROJECT_MESSAGE;
        errorMessage.gameObject.SetActive(true);
    }

    public void solveMissingSelectedProject() {
        errorMessage.text = "";
        errorMessage.gameObject.SetActive(false);
    }


}
