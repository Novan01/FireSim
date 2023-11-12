using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class RenderScale : MonoBehaviour {

    [SerializeField] private float m_RenderScale = 1.5f;              //The render scale. Higher numbers = better quality, but trades performance

    void Start()
    {
        XRSettings.eyeTextureResolutionScale = m_RenderScale;
        //XRSettings.renderScale = m_RenderScale;
    }
}
