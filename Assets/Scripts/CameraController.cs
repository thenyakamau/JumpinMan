using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    private void Update()
    {
        Vector3 position = playerTransform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
