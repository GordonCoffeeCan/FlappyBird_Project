using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public float upForce = 200;

    private bool isDead = false;
    private Rigidbody2D rb2D;
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isDead == false) {
            if (Input.GetMouseButtonDown(0)) {
                rb2D.velocity = Vector2.zero;
                rb2D.AddForce(new Vector2(0, upForce));

                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        rb2D.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
