using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthSensorController : MonoBehaviour
{

    public static LigthSensorController ligthSensorController;

        
    List<LightSensor> sensors;

    // Start is called before the first frame update
    void Start()
    {
        sensors = new List<LightSensor>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
