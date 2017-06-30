using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateManager : MonoBehaviour {

    private Text frameRateText;
    private float deltaTime;
    private float fps;

    // Use this for initialization
    void Start () {
        frameRateText = GameObject.Find("FrameRateText").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        fps = 1.0f / deltaTime;

        frameRateText.text = fps.ToString();

    }
}
