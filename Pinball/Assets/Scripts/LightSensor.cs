using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor
{

    RaycastHit hit;

    GameObject ball;
    GameObject sensor;

    int x;
    int y;

    float colorTime = 0f;
    bool timer = false;

    public LightSensor(GameObject sensor, GameObject ball, int x, int y)
    {
        this.sensor = sensor;
        this.ball = ball;
        this.x = x;
        this.y = y;
        sensor.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(sensor.transform.position, sensor.transform.TransformDirection(new Vector3(0, 0, -1)), out hit, Mathf.Infinity, layerMask))
        {

            if (hit.collider.gameObject == ball)
            {
                Debug.DrawRay(sensor.transform.position, sensor.transform.TransformDirection(new Vector3(0, 1, 0)) * hit.distance, Color.yellow);
                Debug.Log("Sensor:" + x + "," + y);
                sensor.GetComponent<SpriteRenderer>().color = Color.red;
                timer = true;
            }
        }

        if(colorTime > 2)
        {
            sensor.GetComponent<SpriteRenderer>().color = Color.green;
            colorTime = 0;
        }

        if (timer)
        {
            colorTime += Time.deltaTime;
        }
    }
}