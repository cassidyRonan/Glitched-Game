using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public Slider volumeSlider;

    public void VolumeControl()
    {
        AudioListener.volume = volumeSlider.value;
    }

    // Use this for initialization
    void Start () {
        volumeSlider.value = 1;
        VolumeControl();
        volumeSlider.value = AudioListener.volume;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
