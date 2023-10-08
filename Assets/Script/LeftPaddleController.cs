using UnityEngine;

public class LeftPaddleController : MonoBehaviour
{
    public PowerUpManager powerUpManager;
    public BallController ballController;

    [Header("Kecepatan Paddle")]
    public float speed;

    [Header("Tombol untuk paddle")]
    public KeyCode paddleAtas;
    public KeyCode paddleBawah;

    private Rigidbody2D rb2D;
    private Transform _transform;

    private float initSpeed;
    private Vector2 initScale;

    public float effectDuration;
    private float timer;
    private bool isActivate;

    private float paddleScale;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        initSpeed = speed;
        initScale = _transform.localScale;

    }

    private void Update()
    {
        MoveObject(GetInput());

        if (isActivate)
        {
            timer += Time.deltaTime;

            powerUpManager.txtLeftExtend.text = timer.ToString("F0");

            if (timer >= effectDuration)
            {
                timer = 0;

                powerUpManager.uiLeftExtend.SetActive(false);
                powerUpManager.txtLeftExtend.gameObject.SetActive(false);

                //Mengembalikan skala paddle;
                ResetPaddle();

                isActivate = false;
            }
        }
    }

    private Vector2 GetInput()
    {
        //Input Key
        if (Input.GetKey(paddleAtas))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(paddleBawah))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rb2D.velocity = movement;
    }

    public void ActivatePUExtend(float scale)
    {
        ResetPaddle();

        Vector2 ball = ballController.rb2D.velocity;

        if (ball.x > 0)
        {
            powerUpManager.uiLeftExtend.SetActive(true);
            powerUpManager.txtLeftExtend.gameObject.SetActive(true);

            paddleScale = scale;
            Vector2 vector2 = _transform.localScale;
            vector2.y *= paddleScale;
            _transform.localScale = vector2;

            isActivate = true;
        }
    }

    public void ResetPaddle()
    {
        powerUpManager.uiLeftExtend.SetActive(false);
        powerUpManager.txtLeftExtend.gameObject.SetActive(false);

        speed = initSpeed;
        _transform.localScale = initScale;

        isActivate = false;
    }
}
