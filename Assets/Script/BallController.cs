using UnityEngine;

public class BallController : MonoBehaviour
{
    public PowerUpManager powerManager;

    public RightPaddleController rPaddle;
    public LeftPaddleController lPaddle;

    [Header("Kecepatan Bola")]
    public Vector2 speed;

    public Vector2 resetPosition;

    public float effectDuration;

    public Rigidbody2D rb2D;

    private float timer;
    private bool isActivate;
    private bool isRightPaddle;

    private float mag;

    private float initSpeed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = speed;

        initSpeed = lPaddle.speed;
    }

    private void Update()
    {
        if (isActivate)
        {

            timer += Time.deltaTime;
            powerManager.txtLeftSpeed.text = timer.ToString("F0");
            powerManager.txtRightSpeed.text = timer.ToString("F0");

            if (timer >= effectDuration)
            {
                timer = 0;

                //Mengembalikan speed bola
                rb2D.velocity /= mag;

                //Mengembalikan speed paddle;
                if (isRightPaddle)
                {
                    rPaddle.speed = initSpeed;
                    powerManager.uiRightSpeed.SetActive(false);
                    powerManager.txtRightSpeed.gameObject.SetActive(false);
                }
                else
                {
                    lPaddle.speed = initSpeed;
                    powerManager.uiLeftSpeed.SetActive(false);
                    powerManager.txtLeftSpeed.gameObject.SetActive(false);
                }

                isActivate = false;
            }
        }
    }

    public void BallReset()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);

        rb2D.velocity = speed;

        powerManager.uiRightSpeed.SetActive(false);
        powerManager.txtRightSpeed.gameObject.SetActive(false);
        powerManager.uiLeftSpeed.SetActive(false);
        powerManager.txtLeftSpeed.gameObject.SetActive(false);

        lPaddle.ResetPaddle();
        rPaddle.ResetPaddle();
        
        isActivate = false;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        mag = magnitude;
        rb2D.velocity *= mag;

        if(rb2D.velocity.x > 0)
        {
            lPaddle.speed *= mag;
            isRightPaddle = false;
            powerManager.uiLeftSpeed.SetActive(true);
            powerManager.txtLeftSpeed.gameObject.SetActive(true);
        }
        else
        {
            rPaddle.speed *= mag;
            isRightPaddle = true;
            powerManager.uiRightSpeed.SetActive(true);
            powerManager.txtRightSpeed.gameObject.SetActive(true);
        }

        isActivate = true;
    }
}
