using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera;
    public Vector3 Offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Camera.transform.position = Player.transform.position + Offset;
    }
}
