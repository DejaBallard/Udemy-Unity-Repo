using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {
    public AudioClip FirstHeliCall;
    public AudioClip FirstCallReply;

    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnMakeCall()
    {
        audioSource.clip = FirstHeliCall;
        audioSource.Play();
        Invoke("FirstReply", FirstHeliCall.length + 5f);
    }

    void FirstReply()
    {
        audioSource.clip = FirstCallReply;
        audioSource.Play();
        BroadcastMessage("OnDispatch");
    }
}
