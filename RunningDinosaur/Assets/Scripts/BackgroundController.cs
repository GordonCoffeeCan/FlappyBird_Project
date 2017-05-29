using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    private BoxCollider2D groundCollider;

    private void Awake() {
        groundCollider = this.GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -groundCollider.size.x) {
            ResetBackgroundPosition();
        }

        this.transform.Translate(GameManager.instance.scrollSpeed * Vector3.left * Time.deltaTime);
	}

    private void ResetBackgroundPosition() {
        this.transform.position += new Vector3(groundCollider.size.x * 2, 0, 10);
    }
}
