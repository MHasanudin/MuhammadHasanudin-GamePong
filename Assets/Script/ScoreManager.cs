using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;

    public int maxScore;

    public BallController ball;
    public GameController gameController;
    
    public void AddRightScore(int increment)
    {
        rightScore += increment;
        ball.BallReset();

        if(rightScore >= maxScore)
        {
            gameController.GameOver();
        }
    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        ball.BallReset();

        if (leftScore >= maxScore)
        {
            gameController.GameOver();
        }
    }
}
