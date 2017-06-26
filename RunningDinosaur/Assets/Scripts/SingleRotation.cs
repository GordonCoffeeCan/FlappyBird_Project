using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRotation : MonoBehaviour {
    public float rotateSpeed = 80;
    private Transform trans;

	// Use this for initialization
	void Start () {
        trans = this.transform;
        rotateSpeed *= Random.Range(1.5f, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
        trans.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
