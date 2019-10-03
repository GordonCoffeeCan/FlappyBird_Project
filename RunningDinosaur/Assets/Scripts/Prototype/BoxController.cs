using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public static BoxController instance;

    public Renderer boxGraphics;

    private Animator animator;

    public Texture[] textures;

    private void Awake() {
        instance = this;
        animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Jump");
        }
	}

    public void ChangeColor(int _colorID) {
        boxGraphics.material.mainTexture = textures[_colorID];
    }
}
