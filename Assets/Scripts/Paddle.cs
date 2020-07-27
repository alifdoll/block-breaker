using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float MAXIMUM = 15f;
    [SerializeField] float MINIMUM = 1f;

    GameSession autoPlay;
    Ball ball;

    void Start()
    {
        autoPlay = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

   
    void Update()
    {
        
        Vector2 paddle = new Vector2(transform.position.x,transform.position.y);
        
        paddle.x = Mathf.Clamp(min: MINIMUM, max: MAXIMUM, value: GetXPos());
        
        transform.position = paddle;

    }

    private float GetXPos()
    {
        if (autoPlay.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
