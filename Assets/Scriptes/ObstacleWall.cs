using UnityEngine;

public class ObstacleWall : Obstacles
{
    public override void PlayGameOverAnimation()
    {
        gameOverAnimation.PlayGameOverAnimation();
    }
}