using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliController : MonoBehaviour
{
    public void setPitch(float zInput, float xRotation)
    {
        Quaternion rotation = Quaternion.Euler(10 * zInput, xRotation, 0f);
        transform.rotation = rotation;
    }
}
