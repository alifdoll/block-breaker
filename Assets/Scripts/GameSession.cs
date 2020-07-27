using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlock = 20;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] bool autoPlayEnabled;

    private void Awake()
    {
        int gameStatCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatCount > 1) 
        {
            gameObject.SetActive(false); 
            Destroy(gameObject); 
        }
        else DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        text.text = currentScore.ToString();
    }


    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        text.text = currentScore.ToString();
    }

   public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
    
}
