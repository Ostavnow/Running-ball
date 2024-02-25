using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    [SerializeField]
    protected GameOverAnimation gameOverAnimation;
    protected abstract void PlayGameOverAnimation();
}