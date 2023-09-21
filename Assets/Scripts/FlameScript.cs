using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    private float switchingTime = 5f;
    private bool isBurning = false;

    private IEnumerator currentCoroutine;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentCoroutine == null)
        {
            currentCoroutine = SwitchFlame();
            StartCoroutine(currentCoroutine);
        }
    }

    private IEnumerator SwitchFlame()
    {
        yield return new WaitForSeconds(switchingTime);
        isBurning = !isBurning;
        currentCoroutine = null;

        animator.SetBool("isBurning", isBurning);
        if (isBurning)
            gameObject.tag = "Trap";
        else gameObject.tag = "Untagged";
    }
}
