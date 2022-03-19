using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Script uses Update test for distance due to dynamic value change
    // It can use coroutine and Destroy(gameObject, time), but then it won't change dynamically
    private float speed;
    private float distanceCovered;
    private float distanceNeeded;
    private bool destroyed = false;

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        distanceCovered += Time.deltaTime * speed;

        if (distanceCovered >= distanceNeeded && !destroyed)
        {
            destroyed = true;
            MainManager.Instance.RemoveCubeFromScene(this);
        }
    }

    public void SetSpeedDistanceValues(float newSpeed, float newDistance)
    {
        speed = newSpeed;
        distanceNeeded = newDistance;
    }
}
