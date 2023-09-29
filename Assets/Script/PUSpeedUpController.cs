using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;

    public Collider2D ball;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePU(gameObject);
        }
    }
}
