using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        float currentRotation = 360 * speed * Time.deltaTime;
        transform.Rotate(0, 0, currentRotation);    
    }
}
