using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiseFighter : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, sideWaySpeed = 5f;
    private float activeForwadSpeed, activeStrafeSpeed, activeSideWaySpeed;
    private float forwardAcc = 2.5f, strafeAcc = 2f, sideWayAcc = 2f;

    public float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rolAcc = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("roll"), rolAcc * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwadSpeed = Mathf.Lerp(activeForwadSpeed, Input.GetAxisRaw("forward") * forwardSpeed, forwardAcc * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("strafe") * strafeSpeed, strafeAcc * Time.deltaTime);
        activeSideWaySpeed = Mathf.Lerp(activeSideWaySpeed, Input.GetAxisRaw("sideway")* sideWaySpeed, sideWayAcc * Time.deltaTime);

        activeForwadSpeed = forwardSpeed;

        transform.position += transform.forward * activeForwadSpeed * Time.deltaTime;
        transform.position += transform.right * activeSideWaySpeed * Time.deltaTime;
        transform.position += transform.up * activeStrafeSpeed * Time.deltaTime;
    }
}
