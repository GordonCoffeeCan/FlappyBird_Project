using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveCapsule : MonoBehaviour {

    [HideInInspector]
    public int colorID = 0;

    //private Collider colorTrigger;

    private float partentSizeX = 0;

    private void Awake() {
        //colorTrigger = this.GetComponent<Collider>();

        partentSizeX = this.transform.parent.GetComponent<BoxCollider>().size.x;
    }

    private void Update() {
        if(this.transform.position.x < -partentSizeX) {
            Destroy(this.gameObject);
        }
    }

    public void SetColor(int _colorID) {
        Material _mat = this.GetComponent<Renderer>().material;
        colorID = _colorID;
        switch (_colorID) {
            case 0:
                _mat.color = Color.red;
                break;
            case 1:
                _mat.color = Color.green;
                break;
            case 2:
                _mat.color = new Color32(179, 22, 241, 255);
                break;
            case 3:
                _mat.color = Color.yellow;
                break;
            case 4:
                _mat.color = Color.blue;
                break;
        }
    }

    private void OnTriggerEnter(Collider _col) {
        if (_col.tag == "Player") {
            BoxController.instance.ChangeColor(colorID);
            Destroy(this.gameObject);
        }
    }
}
