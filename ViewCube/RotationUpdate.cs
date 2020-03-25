using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUpdate : MonoBehaviour {

    public Transform LookUpTransform;
    public Transform Target;
    public float Distance;

    private Camera cubeCamera;
    private void Start()
    {
        Distance = (Target.position - gameObject.transform.position).magnitude;
        cubeCamera = gameObject.GetComponent<Camera>();
    }
    private void Update()
    {
        GL.ClearWithSkybox(true, cubeCamera);
    }

    private void LateUpdate()
    {
        gameObject.transform.rotation = LookUpTransform.rotation;
        gameObject.transform.position = (Target.transform.position - gameObject.transform.forward * Distance);
    }
}
