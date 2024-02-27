using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesHole : Obstacles
{
    public override void PlayGameOverAnimation()
    {
        gameOverAnimation.PlayGameOverAnimation();
    }
}
