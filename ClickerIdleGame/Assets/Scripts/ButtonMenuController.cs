// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMenuController : MonoBehaviour {

    public GameObject pagePanel;

    public bool isPageOpen = false;

    // public void OnPointerClick(PointerEventData pointerEventData) {
        // Button currentButton = pointerEventData.selectedObject.GetComponent(typeof(Button)) as Button;

        // OpenPageOfCurrentButton();

        // if(isPageOpen) {
        //     principalMenu.isSelected = false;
        // } else {
        //     principalMenu.isSelected = true;
        //     currentButton.SetActive(isSelected);
        //     // currentButton.GetComponent<Image>().sprite = normalButton;

        //         var buttonObject = FindObjectsOfType<Button>();
        // for(int i = 0; i < buttonObject.Length; i ++){
        //     var button = buttonObject[i];
        //     UpgradeButtonController UpgradeButton = button.GetComponent<UpgradeButtonController>();
        //     if(UpgradeButton != null && UpgradeButton.IsIddleGain && UpgradeButton.TotalPurchased > 0){
        //         Debug.Log(button.name);
        //         Debug.Log(UpgradeButton.TotalPurchased);
        //         Debug.Log(UpgradeButton.UpgradeIncrease);
        //         result += UpgradeButton.TotalPurchased * UpgradeButton.UpgradeIncrease;
        //     }
        // }

        // Debug.Log(currentButton);

        // Debug.Log(currentButton);
    // }

    public void OpenPageOfCurrentButton() {

        if(!isPageOpen) {
            isPageOpen = !isPageOpen;

            pagePanel.SetActive(isPageOpen);

            PrincipalMenuController principalMenu = FindObjectOfType<PrincipalMenuController>();
            principalMenu.OpenPage();

            CloseOtherPages();
            ResetButtonsVariables();
        }
    }

    public void ResetButtonsVariables() {
        ButtonMenuController[] yourObjects = FindObjectsOfType<ButtonMenuController>(true);


        for(int index = 0; index < yourObjects.Length; index++) {
            ButtonMenuController currentButton = yourObjects[index];

            if(currentButton != this){
                currentButton.isPageOpen = false;
            }
        }

        // Debug.Log(yourObjects.Length);
    }

    public void CloseOtherPages() {

        GameObject[] Pages = GameObject.FindGameObjectsWithTag("Pages");

        for(int index = 0; index < Pages.Length; index++) {
            GameObject currentPage = Pages[index];
            
            if(currentPage.name != pagePanel.name){
                // ButtonMenuController UpgradeButton = button.GetComponent<UpgradeButtonController>();
                currentPage.SetActive(false);
            }
        }

    }

}
