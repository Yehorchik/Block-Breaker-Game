using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStatus : MonoBehaviour
{
    [Range(0.2f , 10f )] [SerializeField]float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] int YourScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;

     
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = YourScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        YourScore += pointsPerBlock;
        scoreText.text = YourScore.ToString();

    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
