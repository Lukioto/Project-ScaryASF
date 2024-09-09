using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{

    public Image bar;
    public Image health;

    public GameObject player;

    public GameObject[] victorycontions;

    public GameObject falsecamra;

    public enum Gamestate
    {
        Start,
        Playing,
        GOver
    };

    private Gamestate m_GameState;

    public Gamestate State { get { return m_GameState; } }

    private void Awake()
    {
        m_GameState = Gamestate.Start;
    }

    void Start()
    {
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyUp(KeyCode.Escape))
       {
            Application.Quit();
       }
    switch(m_GameState)
        {
            case Gamestate.Start:
                GameStateStart();
                break;
            case Gamestate.Playing:
                GameStatePlaying();
                break;
            case Gamestate.GOver:
                GameStateOver();
                break;
        }
    }


    void GameStateStart()
    {
        if (Input.GetKeyUp(KeyCode.Return) == true)
        {
            OnNewGame();
            /*
            m_GameState = Gamestate.Playing;

            for (int i = 0; i < victorycontions.Length; i++)
            {
                victorycontions[i].SetActive(true);
            }
            */
        }
    }

    void GameStatePlaying()
    {
        bool isGameOver = false;

        if (victory() == true)
        {
            Debug.Log("victory");
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            m_GameState = Gamestate.GOver;
        }
    }

    void GameStateOver()
    {
        if (Input.GetKeyUp(KeyCode.Return) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    public void OnNewGame()
    {
        m_GameState = Gamestate.Playing;

        for (int i = 0; i < victorycontions.Length; i++)
        {
            victorycontions[i].SetActive(true);
        }

        player.SetActive(true);
        falsecamra.SetActive(false);
    }

    public bool victory()
    {
        int objecteves = 0;

        for (int i = 0; i < victorycontions.Length; i++)
        {
            if (victorycontions[i].activeSelf == true)
            {
                objecteves++;
            }
        }
        return objecteves == 0;
    }

}
