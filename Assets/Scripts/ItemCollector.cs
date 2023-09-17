using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int bananaCount = 0;
    [SerializeField] private Text bananaText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Bananas"))
        {
            collectionSoundEffect.Play();
            Destroy(obj);
            bananaCount++;

            bananaText.text = "Bananas: " + bananaCount;
        }
    }
}
