using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SockManJumpscare : MonoBehaviour
{
    public Image image;
    public AudioSource audioSource;
    public actualfoesmove movement;

    private void Awake()
    {
        image.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SM_Jumpscare());
    }

    IEnumerator SM_Jumpscare()
    {
        image.enabled = true;
        if (audioSource != null)
        {
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f);
        image.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
