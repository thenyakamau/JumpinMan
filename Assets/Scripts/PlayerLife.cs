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
     private string[] collisionTags = { "Trap", "FallDetector" };

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyItem = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (collisionTags.Contains(obj.tag))
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
