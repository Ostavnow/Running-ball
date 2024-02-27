using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    [SerializeField]
    protected GameOverAnimation gameOverAnimation;
    public abstract void PlayGameOverAnimation();
}