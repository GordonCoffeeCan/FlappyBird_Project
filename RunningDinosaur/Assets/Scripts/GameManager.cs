using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField] private float scrollSpeed = 5;

    [SerializeField] private List<Floor> Floors = new List<Floor>();

    private List<BoxCollider> FloorCollisers = new List<BoxCollider>();

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < Floors.Count; i++) {
            FloorCollisers.Add(Floors[i].GetComponent<BoxCollider>());
        }

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate() {
        for (int i = 0; i < Floors.Count; i++) {

            if (Floors[i].transform.position.x < -FloorCollisers[i].size.x * 2) {
                Floors[i].transform.position += new Vector3(FloorCollisers[i].size.x * 4, 0, 0);
            }

            Floors[i].transform.Translate(scrollSpeed * Vector3.left * Time.deltaTime);
        }
    }
}
