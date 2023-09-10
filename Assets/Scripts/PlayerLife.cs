using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbodyItem;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyItem = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.CompareTag("Trap"))
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        animator.SetTrigger("death");
        rigidbodyItem.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
