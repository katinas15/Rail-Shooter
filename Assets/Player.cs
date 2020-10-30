using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 4f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float pitchFactor = -5f;
    [SerializeField] float controlPitch = -20f;
    [SerializeField] float yawFactor = 5f;
    [SerializeField] float rollFactor = -20f;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

    }

    void Rotate(){
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitch;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xThrow * rollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void Move(){
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float xClamp = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float yClamp = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xClamp, 
            yClamp, transform.localPosition.z);
    }
}
