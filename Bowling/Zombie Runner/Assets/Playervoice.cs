using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playervoice : MonoBehaviour {

    public AudioClip whathappend;
    public AudioClip goodlandingarea;

    private AudioSource audiosource;

	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = whathappend;
        audiosource.Play();
	}

    void OnClearArea() {
        audiosource.clip = goodlandingarea;
        audiosource.Play();
        Invoke("callHeli", goodlandingarea.length + 1f);
    }

    void callHeli()
    {
        SendMessageUpwards("OnMakeCall");
    }

}
