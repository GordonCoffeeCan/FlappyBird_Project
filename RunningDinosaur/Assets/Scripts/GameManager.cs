using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField] private float scrollSpeed = 5;
    [SerializeField] private List<Floor> floors = new List<Floor>();

    private List<BoxCollider> FloorCollisers = new List<BoxCollider>();

    private int _currentFloorID = 0;

    private int showCounts = 0;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < floors.Count; i++) {
            FloorCollisers.Add(floors[i].GetComponent<BoxCollider>());
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate() {
        for (int i = 0; i < floors.Count; i++) {

            if (floors[i].transform.position.x < -FloorCollisers[i].size.x * 2) {
                MakeFloor(i);
            }

            floors[i].transform.Translate(scrollSpeed * Vector3.left * Time.deltaTime);
        }
    }

    private void MakeFloor(int _i) {
        floors[_i].transform.position += new Vector3(FloorCollisers[_i].size.x * 4, 0, 0);

        for (int i = 0; i < floors[_i].floorObjects.Length; i++) {
            floors[_i].floorObjects[i].gameObject.SetActive(false);
        }

        showCounts--;
        
        if (showCounts < 0) {
            showCounts = Random.Range(3, 5);

            int _floorID = Random.Range(0, 5);
            _currentFloorID = _floorID;
        }

        floors[_i].floorObjects[_currentFloorID].gameObject.SetActive(true);

        Debug.Log(showCounts);
    }
}
