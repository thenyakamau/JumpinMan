using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    // Update is called once per frame
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        float pHPostion = playerTransform.position.x;

        transform.position = new Vector3(pHPostion, currentPosition.y, currentPosition.z);
    }
}
