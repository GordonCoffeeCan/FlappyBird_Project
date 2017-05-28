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
        groundCollider.GetComponent<Rigidbody2D>().velocity = GameManager.instance.scrollSpeed * Vector3.left;
    }
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -groundCollider.size.x) {
            ResetBackgroundPosition();
        }
	}

    private void ResetBackgroundPosition() {
        this.transform.position = new Vector3(groundCollider.size.x, 0, 10);
    }
}
