using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public Text scoreText;
    public float scrollSpeed = -1.5f;
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    private int score = 0;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver == true && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdDied() {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScored() {
        if (gameOver) {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
