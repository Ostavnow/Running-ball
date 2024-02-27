using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverHoleAnimation : GameOverAnimation
{
    [SerializeField]
    private float suctionForce;
    private float radius;
    // private void Start()
    // {
    //     radius = GetComponent<SphereCollider>().radius;
    // }
    protected override IEnumerator PlayGameOverAnimationCorutine()
    {
        animation.Play(gameOverAnimation.name);
        audioManager.Play("GameOver");
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        Vector3 endPos = new Vector3(transform.position.x,transform.position.y - 1,transform.position.z);
        yield return new WaitForSeconds(0.3f);
        playerTransform.GetComponent<Rigidbody>().isKinematic = true;
        animation.Play(gameOverAnimation.name);
        while(playerTransform.position.y > endPos.y + 0.3f)
        {
        if(playerTransform.position.y > endPos.y/2)
            playerTransform.position = Vector3.Lerp(playerTransform.position,endPos,Time.deltaTime / 1f);
        else if(playerTransform.position.y > endPos.y)
            playerTransform.position = Vector3.Lerp(playerTransform.position,endPos,Time.deltaTime / 3f);
        yield return null;
        }
        panelGameOver.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            Debug.Log("Притягиваем игрока");
            other.GetComponent<Rigidbody>().AddExplosionForce(-suctionForce,transform.position,3);
        }
    }
}
