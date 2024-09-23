using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class foemove : MonoBehaviour
{

    public Transform _foe;
    public Camera Camra;

    void Update()
    {
        _foe.rotation = Quaternion.Euler(90f, Camra.transform.rotation.eulerAngles.y + 90f, -90f);
    }
}
