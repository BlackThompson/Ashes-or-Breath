using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Meta.XR;


public class EnvironmentPlacement : MonoBehaviour
{
    private EnvironmentRaycastManager _raycastManager;
    // Assign the right controller anchor found under OVRCamera to this field
    [SerializeField]
    private Transform _rightControllerAnchor;

    private void Awake()
    {
        // This will also add the Environment Depth Manager if not already present in the scene
        _raycastManager = gameObject.AddComponent<EnvironmentRaycastManager>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            // Create a standard Unity ray, originating from your right controller, to later feed into the raycastManager
            var ray = new Ray(_rightControllerAnchor.position, _rightControllerAnchor.forward);
            // Check if ray hits the environment
            if (_raycastManager.Raycast(ray, out var hit))
            {
                // Spawn a cube and set it's position and rotation to the point hit
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.SetPositionAndRotation(hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                cube.transform.localScale *= 0.1f;
                //  If MRUK's world locking is not active, spawn a spatial anchor at the cube's position. Then parent the cube to the spatial anchor.
                if (MRUK.Instance?.IsWorldLockActive != true)
                {
                    cube.AddComponent<OVRSpatialAnchor>();
                }
            }
        }
    }
}
