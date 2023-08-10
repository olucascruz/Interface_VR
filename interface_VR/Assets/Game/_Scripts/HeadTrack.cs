using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrack : MonoBehaviour
{

    private bool gyroBool;
    private Gyroscope gyro;
    
    private float initialPositionY = 0f;
    private float positionGyroY = 0f;
    private float calibratePositionY = 0f;

    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
 
        gyroBool = SystemInfo.supportsGyroscope;
 
        Debug.Log("gyro bool = " + gyroBool.ToString());
        
        initialPositionY = transform.eulerAngles.y;

        
        if (gyroBool)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.Log("No Gyro Support");
        }

        Invoke("CalibratePositionY", 3f);
    }

    void Update()
    {
        if (gyroBool)
        {
         ApplyRotationGyro();
         ApplyCalibrate();
        }
    }

    void ApplyRotationGyro(){
        transform.rotation = gyro.attitude;
        print(gyro.attitude);
        transform.Rotate(0f, 0f, 180f, Space.Self);
        transform.Rotate(90f, 180f, 0f, Space.World);

        positionGyroY = transform.eulerAngles.y;

    }

    void CalibratePositionY(){
        calibratePositionY = positionGyroY - initialPositionY;
    }

    void ApplyCalibrate(){
        transform.Rotate(0f, -calibratePositionY, 0f, Space.World);
    }   
}
