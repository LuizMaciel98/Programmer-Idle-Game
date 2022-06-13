// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PrincipalMenuController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public Sprite normalButton;
    public Sprite pressedButton;
    public GameObject panel;
    public Button currentButton;

    // public Button button;

    public bool isSelected = false;

    public void OnPointerClick(PointerEventData pointerEventData) {
        currentButton = pointerEventData.selectedObject.GetComponent(typeof(Button)) as Button;

        ChangeIsSelected();
    }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        //Nothing for now
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        //Nothing for now
    }

    private void ChangeIsSelected() {
        isSelected = !isSelected;

        panel.SetActive(isSelected);

        if(isSelected) {
            currentButton.GetComponent<Image>().sprite = pressedButton;
        } else {
            currentButton.GetComponent<Image>().sprite = normalButton;
        }
    }

    public void OpenPage() {
        if(isSelected == true) {
            ChangeIsSelected();
        }
    }
}
