using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private float lerpValue;
    [SerializeField] private float vakumYpos;
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            CharMovement();
        }
    }
    private void CharMovement()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, vakumYpos, hit.point.z), lerpValue * Time.deltaTime);
        }
    }
}