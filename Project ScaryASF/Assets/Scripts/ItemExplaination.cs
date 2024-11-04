using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemExplaination : MonoBehaviour
{
    public Image image;
    private bool in_area = false;

    private void Awake()
    {
        image.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && in_area == true)
        {
            image.enabled = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            in_area = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            in_area = false;
        }
    }
}
