using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlocksController : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 2f;

    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name == "Player")
            StartCoroutine(FallingBlock());
    }

    private IEnumerator FallingBlock()
    {
        yield return new WaitForSeconds(fallDelay);
        rBody.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
