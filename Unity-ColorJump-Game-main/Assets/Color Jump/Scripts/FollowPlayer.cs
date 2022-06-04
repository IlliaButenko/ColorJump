
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject PlayerObj;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    public int yOffset;

    void Update()
    {
        Vector3 targetPosition = PlayerObj.transform.TransformPoint(new Vector3(0, yOffset, -10));

        if(targetPosition.y < transform.position.y) return;

        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}