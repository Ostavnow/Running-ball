using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    [SerializeField]
    private AnimationClip gameOverAnimation;
    [SerializeField]
    private ParticleSystem particleSystem;
    private Animator animation;
    [SerializeField]
    private GameObject panelGameOver;
    private void Start()
    {
        animation = FindObjectOfType<PlayerController>().GetComponent<Animator>();
    }
    public void PlayGameOverAnimation()
    {
        StartCoroutine(PlayGameOverAnimationCorutine());
    }
    private IEnumerator PlayGameOverAnimationCorutine()
    {
        animation.Play(gameOverAnimation.name);
        FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().isKinematic = true;
        // particleSystem.Play();
        yield return new WaitForSeconds(0.5f);
        try
        {
            panelGameOver.SetActive(true);
        }
        catch(UnassignedReferenceException e)
        {}
        
    }
}