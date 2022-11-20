using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

[RequireComponent(typeof(TrackedDeviceGraphicRaycaster))]

public class VRCanvas : MonoBehaviour
{
    private Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }


}
