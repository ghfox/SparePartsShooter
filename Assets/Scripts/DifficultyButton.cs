using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int missileBreak = 1;
    public float maxFireRate = 5.0f;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<Button>().onClick.AddListener(SetDifficulty);
    }

    public void SetDifficulty()
    {
        gameManager.SetAndStart(missileBreak,maxFireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
