using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// every 15 seconds, spawn new ones
// if ever more than x on screen, lose
public class GameManager : MonoBehaviour {

    public List<Vector3> friendPositions;
    List<GameObject> positionFlags;
    SpawnManager spawner;
    public Text scoreText;
    public Text gameOverText;
    int score = 0;
    enum gameState {setup, play,end };

    gameState state = gameState.setup;
	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<SpawnManager>();
        friendPositions = new List<Vector3>();
        positionFlags = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (spawner.balls.Count > 15) {
            gameOver();
        }
        //if (friendPositions.Count >= 3) {
        //    state = gameState.play;
        //}
        //if (state == gameState.play) {
        //    spawner.spawnObjects();
        //}
	}
    void gameOver() {
        gameOverText.gameObject.SetActive(true);
        Debug.Log("game over");
        state = gameState.end;
        spawner.CancelInvoke();
        for (int i = 0; i < spawner.balls.Count; i++) {
            Debug.Log("removing " + i);
            Debug.Log("count " + spawner.balls.Count);

            Destroy(spawner.balls[i]);

        }
        for (int i = 0; i < spawner.balls.Count; i++)
        {
            spawner.balls.Remove(spawner.balls[i]);

        }

    }
    public void decrimentBallCount(GameObject toRemove) {
        spawner.balls.Remove(toRemove);

    }
    public void increaseScore() {
        score++;
        updateCanvas();
    }
    void updateCanvas() {
        scoreText.text = "Score: " + score;
    }
    public void addPosition(Vector3 pos) {
        if (state == gameState.setup) {
            friendPositions.Add(pos);
            Debug.Log("pos: " + pos);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pos;
            cube.transform.localScale = new Vector3(.1f, .1f, .1f);
            positionFlags.Add(cube);
        }
       

        if (friendPositions.Count >=3 && state == gameState.setup) {
            
          Invoke(  "startGame", 1);
            
            state = gameState.play;
        }

    }
    void startGame() {

        for (int i = 0; i < positionFlags.Count; i++)
        {
            Destroy(positionFlags[i]);
        }
        for (int i = 0; i < positionFlags.Count; i++)
        {
            positionFlags.Remove(positionFlags[i]);
        }

        spawner.InvokeRepeating( "spawnObjects", 1, 7);

    }
}
