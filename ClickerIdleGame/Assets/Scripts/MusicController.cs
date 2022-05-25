using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public Toggle selectedToggle;
    public AudioSource audioSource;

    public void PlayOrStop(){
        if(selectedToggle.isOn){
            audioSource.Play();
        } else {
            audioSource.Stop();
        }
    }

    // void Start() {
    //     selectedToggle = GetComponent<Toggle>();
    //     selectedToggle.onValueChanged.AddListener(delegate {
    //         ToggleValueChangedOccured(selectedToggle);
    //         });
    // }

    // void ToggleValueChangedOccured(Toggle tglValue) {
    //     Debug.Log("your current toggle state is: " + tglValue.isOn);
    // }

}
