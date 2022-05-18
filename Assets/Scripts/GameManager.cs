using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameOver;
    public bool startedGame;
    protected int hits;
    public bool hasMissile = false;
    public TextMeshProUGUI hitText;
    public int missileBreak = 1;
    public SpawnManager spawnManager;
    public float maxFireRate;
    public GameObject title;
    public GameObject end;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        startedGame = false;
        hits = 0;
        GameObject[] groundArr = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < groundArr.Length; i++)
        {
            groundArr[i].transform.Translate(
                new Vector3(0, 0,
                groundArr[i].GetComponent<MeshCollider>().bounds.size.z * i)
                );
        }
    }

    public void SetAndStart(int newMissileBreak, float newMaxFireRate)
    {
        missileBreak = newMissileBreak;
        maxFireRate = newMaxFireRate;
        StartGame();
    }

    public void StartGame()
    {
        title.SetActive(false);
        spawnManager.StartSpawn();
        startedGame = true;
    }

    public void EndGame()
    {
        gameOver = true;
        end.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Hit()
    {
        hits++;
        hitText.SetText($"Hits:{hits}");
        if (hits % missileBreak == 0)
            player.hasMissile = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
