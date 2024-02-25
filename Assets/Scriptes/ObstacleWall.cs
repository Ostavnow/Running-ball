using UnityEngine;

public class ObstacleWall : Obstacles
{
    private void Start()
    {
        FindObjectOfType<PlayerController>().GameOver += PlayGameOverAnimation;
    }
    protected override void PlayGameOverAnimation()
    {
        gameOverAnimation.PlayGameOverAnimation();
    }
}