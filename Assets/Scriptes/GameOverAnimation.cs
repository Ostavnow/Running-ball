using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public abstract class GameOverAnimation : MonoBehaviour
{
    [SerializeField]
    protected AnimationClip gameOverAnimation;
    [SerializeField]
    protected ParticleSystem particleSystem;
    protected Animator animation;
    [SerializeField]
    protected GameObject panelGameOver;
    protected AudioManager audioManager;
    private bool isActive = true;
    protected void Start()
    {
        animation = FindObjectOfType<PlayerController>().GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void PlayGameOverAnimation()
    {
        if(isActive)
        {
            isActive = false;
            StartCoroutine(PlayGameOverAnimationCorutine());
        }
    }
    protected abstract IEnumerator PlayGameOverAnimationCorutine();
}