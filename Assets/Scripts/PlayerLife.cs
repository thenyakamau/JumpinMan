using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbodyItem;

    [SerializeField] AudioSource deathSoundEffect;
    [SerializeField] private string[] collisionTags = { "Trap", "FallDetector" };

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyItem = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        CheckCollissionType(obj.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        CheckCollissionType(obj.tag);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        CheckCollissionType(obj.tag);
    }

    private void CheckCollissionType(string collissionTag)
    {
        if (collisionTags.Contains(collissionTag))
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        deathSoundEffect.Play();
        animator.SetTrigger("death");
        rigidbodyItem.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
