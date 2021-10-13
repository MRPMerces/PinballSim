using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public GameObject ball;

    public GameObject paddle_GO;
    PaddleController paddle;

    public GameObject outOfBounds_GO;

    LightSensor[,] sensors;
    public Sprite sprite;

    LightSensor lightSensor1;
    LightSensor lightSensor2;

    float waitTime = 0f;
    float travelTime;

    bool travelTimer;
    bool timer;

    // Start is called before the first frame update
    void Start() {
        int size = 10;
        float t = size / 5;
        sensors = new LightSensor[size, size];
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {

                GameObject gameObject = new GameObject("Sensor_" + x + "_" + y);
                gameObject.transform.SetParent(transform);
                gameObject.transform.position = new Vector3(transform.position.x + (x / t), 0.1f, transform.position.z + (y / t));
                gameObject.transform.rotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));

                gameObject.AddComponent<SpriteRenderer>();
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

                sensors[x, y] = new LightSensor(gameObject, ball, x, y);

                sensors[x, y].RegisterSensorChanged(OnSensorChanged);
            }
        }

        paddle = paddle_GO.GetComponent<PaddleController>();

        outOfBounds_GO.GetComponent<OutOfBounds>().RegisterOutOfBounds(outOfBoundsTrigger);
    }

    // Update is called once per frame
    void Update() {
        foreach (LightSensor lightSensor in sensors) {
            lightSensor.update();
        }

        if (timer && waitTime < 0) {
            paddle.activate();
            timer = false;
        }

        if (timer) {
            waitTime -= Time.deltaTime;
        }

        if (travelTimer) {
            travelTime += Time.deltaTime;
        }
    }

    Action<LightSensor> cbSensorChanged;
    Action<OutOfBounds> cbOutOfBounds;

    public void RegisterSensorChanged(Action<LightSensor> callbackfunc) {
        cbSensorChanged += callbackfunc;
    }

    public void UnregisterSensorChanged(Action<LightSensor> callbackfunc) {
        cbSensorChanged -= callbackfunc;
    }

    public void RegisterOutOfBounds(Action<OutOfBounds> callbackfunc) {
        cbOutOfBounds += callbackfunc;
    }

    public void UnregisterOutOfBounds(Action<OutOfBounds> callbackfunc) {
        cbOutOfBounds -= callbackfunc;
    }

    // Gets called whenever ANY Sensor changes
    void OnSensorChanged(LightSensor lightSensor) {
        if (lightSensor1 == null) {
            lightSensor1 = lightSensor;
            travelTimer = true;
            return;
        }

        // If we read the same sensor twice we return.
        if (lightSensor1 == lightSensor) {
            return;
        }

        // If the ball is moving upwards, we discard the results.
        if (lightSensor1.y < lightSensor.y) {
            lightSensor1 = null;
            lightSensor2 = null;
            return;
        }

        // The ball have moved horisontally in the matrix. Meening that two sensors with different y cordinate have triggered.
        // From this we can calculate the angle the ball is traveling at... ish.
        if (lightSensor1.x != lightSensor.x) {
            travelTimer = false;

            lightSensor2 = lightSensor;

            calcHit(lightSensor1, lightSensor2);
            return;
        }

        // The ball have only moved verticly in the matrix. Meening that two sensors with the same y cordinate have triggered.
        // From this we can assume that the angle the ball is traveling at is 0... ish.
        else if ((lightSensor1.x == lightSensor.x) && (lightSensor1.y > lightSensor.y)) {
            travelTimer = false;

            lightSensor2 = lightSensor;

            calcHit(lightSensor1, lightSensor2, true);
            return;
        }
    }


    void calcHit(LightSensor sensor1, LightSensor sensor2, bool vertical = false) {
        lightSensor1 = null;
        lightSensor2 = null;

        Vector3 pos1 = sensor1.sensor.transform.position;
        Vector3 pos2 = sensor2.sensor.transform.position;

        if (vertical) {
            timer = true;
            waitTime = travelTime;
            travelTime = 0f;
        }

        /*
         *compare the transform of the matrix + sensor, to the transform of the paddle.
         * Calculate when it will hit, based on the traveltime per transform cordinate. And where it will hit on the paddle, as it slopes.
         * Calculate the angle.
         */
    }

    void outOfBoundsTrigger(OutOfBounds outOfBounds) {
        lightSensor1 = null;
        lightSensor2 = null;
    }
}
