using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuAnim : MonoBehaviour {
    
    public GameObject PanelMenu;

    public void ShowHideMenu() {
        Debug.Log("ShowHideMenu");
        if(PanelMenu != null) {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if(animator != null){
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }
}
