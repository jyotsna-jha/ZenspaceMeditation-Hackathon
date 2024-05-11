using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUse : MonoBehaviour
{
    public GameObject PlaneObject;
    public float distanceFromCamera = 1f; // Distance from the camera

    private GameObject obj;

    void Start()
    {
        // Create the object in front of the camera
        obj = Instantiate(PlaneObject, transform.position + transform.forward * distanceFromCamera, Quaternion.identity);
        obj.transform.LookAt(transform); // Make the object face the camera

        // Set up the webcam texture on the plane object
        WebCamTexture webCameraTexture = new WebCamTexture();
        obj.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();
    }

    void Update()
    {
        // Move the object along with the camera
        obj.transform.position = transform.position + transform.forward * distanceFromCamera;
        
        // Rotate the object to match the camera's rotation
        obj.transform.rotation = Quaternion.LookRotation(transform.forward, transform.up);
    }
}
