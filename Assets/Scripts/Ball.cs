using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddleGame;
    [SerializeField] float xVelocity = 2f, yVelocity = 15f;
    [SerializeField] AudioClip[] ballSound;
    [SerializeField] float randomFactor = 0.2f;

    bool clicked = false;
    Vector2 paddleBallVect;

    AudioSource audioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        PaddleBallVector();
        audioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        if (!clicked)
        {
            LockBall();
            LaunchOnClick();
        }
    }

    private void LockBall()
    {
        Vector2 paddlePos = new Vector2(paddleGame.transform.position.x, paddleGame.transform.position.y);
        transform.position = paddlePos + paddleBallVect;
    }

    private void PaddleBallVector()
    {
        paddleBallVect = transform.position - paddleGame.transform.position;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            myRigidBody2D.velocity = new Vector2(Random.Range(-xVelocity, xVelocity), yVelocity);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0.8f, randomFactor), 
            Random.Range(0.5f, randomFactor));

        if (clicked)
        {
            AudioClip clip = ballSound[Random.Range(0, ballSound.Length)];
            audioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
       
    }
}
