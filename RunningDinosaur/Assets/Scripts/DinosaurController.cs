using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurController : MonoBehaviour {

    private Rigidbody rdBody;
    private float upForce = 5.5f;

    private bool jump = false;
    private bool isGround = false;

	// Use this for initialization
	void Start () {
        rdBody = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        jump = Input.GetMouseButtonDown(0);

        if (jump && isGround) {
            rdBody.velocity = Vector2.zero;
            rdBody.AddForce(upForce * Vector2.up, ForceMode.Impulse);
        }

        if (isGround == false) {
            rdBody.velocity = new Vector2(0, rdBody.velocity.y);
        }
    }

    private void OnCollisionStay(Collision _col) {
        if(_col.gameObject.tag == "Ground") {
            isGround = true;
        }

        rdBody.velocity = new Vector2(0, rdBody.velocity.y);
    }

    private void OnCollisionExit(Collision _col) {
        isGround = false;
    }
}
