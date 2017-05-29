using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurController : MonoBehaviour {

    private Rigidbody2D rdBody;
    private float upForce = 370;

    private bool jump = false;
    private bool isGround = false;

	// Use this for initialization
	void Start () {
        rdBody = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        jump = Input.GetMouseButtonDown(0);

        if (jump && isGround) {
            rdBody.velocity = Vector2.zero;
            rdBody.AddForce(upForce * Vector2.up * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (isGround == false) {
            rdBody.velocity = new Vector2(0, rdBody.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D _col) {
        if(_col.gameObject.tag == "Ground") {
            isGround = true;
        }

        rdBody.velocity = new Vector2(0, rdBody.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D _col) {
        isGround = false;
    }
}
