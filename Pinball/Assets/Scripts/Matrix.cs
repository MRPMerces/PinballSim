using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddle;
    LightSensor[,] sensors;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        sensors = new LightSensor[5, 5];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject gameObject = new GameObject("Sensor_" + x + "_" + y);
                gameObject.transform.position = new Vector3(transform.position.x + x, 0.1f, transform.position.z + y);
                gameObject.transform.rotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
                gameObject.transform.SetParent(transform);
                gameObject.AddComponent<SpriteRenderer>();
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

                sensors[x, y] = new LightSensor(gameObject, ball, x, y);

 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (LightSensor lightSensor in sensors)
        {
            lightSensor.update();
        }
    }
}
