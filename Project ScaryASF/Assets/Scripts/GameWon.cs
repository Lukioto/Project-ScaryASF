using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public gamemanager gameManager;
    public TextMeshProUGUI victoryMessage;
    public GameObject winZone;
    private void Awake()
    {
        victoryMessage.text = " ";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameManager.ableToWin == true)
        {
            StartCoroutine(WinAfterDelay());
        }
    }
    IEnumerator WinAfterDelay()
    {
        victoryMessage.text = "YOU HAVE ESCAPED";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
