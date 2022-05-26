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

}
