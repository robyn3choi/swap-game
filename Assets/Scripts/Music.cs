using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    AudioSource myAudio;

	// Use this for initialization
	void Awake () {
        myAudio = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        myAudio.Play();
    }
}
