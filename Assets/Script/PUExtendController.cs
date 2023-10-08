using UnityEngine;

public class PUExtendController : MonoBehaviour
{
    public PowerUpManager manager;

    public LeftPaddleController lPaddle;
    public RightPaddleController rPaddle;

    public Collider2D ball;
    public float scale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            lPaddle.GetComponent<LeftPaddleController>().ActivatePUExtend(scale);
            rPaddle.GetComponent<RightPaddleController>().ActivatePUExtend(scale);
            manager.RemovePU(gameObject);
        }
    }
}