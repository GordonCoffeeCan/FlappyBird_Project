using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField] private float scrollSpeed = 5;
    [SerializeField] private List<Floor> floors = new List<Floor>();

    [SerializeField] private EvolveCapsule evolveCapsule;

    private List<BoxCollider> floorCollisers = new List<BoxCollider>();

    private int currentFloorID = 0;

    private int showCounts = 0;

    private void Awake() {
        instance = this;

        if (evolveCapsule == null) {
            Debug.LogError("No Evolve Capsule Reference");
        }
        
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < floors.Count; i++) {
            floorCollisers.Add(floors[i].GetComponent<BoxCollider>());
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate() {
        for (int i = 0; i < floors.Count; i++) {

            if (floors[i].transform.position.x < -floorCollisers[i].size.x * 2) {
                MakeFloor(i);
            }

            floors[i].transform.Translate(scrollSpeed * Vector3.left * Time.deltaTime);
        }
    }

    private void MakeFloor(int _i) {
        floors[_i].transform.position += new Vector3(floorCollisers[_i].size.x * 4, 0, 0);

        for (int i = 0; i < floors[_i].floorObjects.Length; i++) {
            floors[_i].floorObjects[i].gameObject.SetActive(false);
        }

        showCounts--;
        
        if (showCounts < 0) {
            showCounts = Random.Range(0, 2);

            int _floorID = Random.Range(0, 5);

            if (currentFloorID != _floorID) {
                currentFloorID = _floorID;
                CreateEvolveCapsule(_i);
            } else {
                
            }
        }

        floors[_i].floorObjects[currentFloorID].gameObject.SetActive(true);
    }

    private void CreateEvolveCapsule(int _floorID) {
        EvolveCapsule _clone = Instantiate(evolveCapsule, new Vector3(floors[_floorID].transform.position.x - floorCollisers[_floorID].size.x / 2, 2.5f, 0), Quaternion.identity, floors[_floorID].transform) as EvolveCapsule;
        _clone.SetColor(currentFloorID);
    }
}
