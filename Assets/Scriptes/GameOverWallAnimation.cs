using System.Collections;
using UnityEngine;

public class GameOverWallAnimation : GameOverAnimation
{
    protected override IEnumerator PlayGameOverAnimationCorutine()
    {
        Debug.Log("Игрок стукнулся");
        animation.Play(gameOverAnimation.name);
        audioManager.Play("GameOver");
        FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().isKinematic = true;
        // particleSystem.Play();
        yield return new WaitForSeconds(0.5f);
        panelGameOver.SetActive(true);
    }
}