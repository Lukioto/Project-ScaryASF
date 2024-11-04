using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class gamemanager : MonoBehaviour
{

    public Image bar;
    public Image health;
    public ItemExplaination itemExplaination;

    public TextMeshProUGUI tacoCraze;
    private float disappearTime;
    private bool noTacoCraze = false;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI objectiveCounter;
    public GameObject player;

    public GameObject[] victorycontions;
    public bool ableToWin;

    public GameObject falsecamra;

    public int objectivesCollected = 0;

    public GameObject sockman;

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
        objectiveCounter.text = " ";
        m_GameState = Gamestate.Start;
        tacoCraze.text = "He can smell the tacos";
        tacoCraze.enabled = false;
    }

    void Start()
    {
        player.SetActive(false);
        ableToWin = false;
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

        if (Input.GetKeyDown(KeyCode.Return) && itemExplaination.image.enabled == true)
        {
            itemExplaination.image.enabled = false;
        }
    }


    void GameStateStart()
    {
        sockman.SetActive(false);
        titleText.text = "Press enter to start";
        if (Input.GetKeyUp(KeyCode.Return) == true)
        {
            OnNewGame();
        }
    }

    void GameStatePlaying()
    {
        bool isGameOver = false;
        sockman.SetActive(true);

        objectiveCounter.text = objectivesCollected + "/5 Tacos";

        if (victory() == true)
        {
            ableToWin = true;
            isGameOver = true;
            StartCoroutine(EnableText());
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
        titleText.text = "";
        m_GameState = Gamestate.Playing;

        playermovement.haslight = false;

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

    IEnumerator EnableText()
    {
        if (noTacoCraze == false)
        {
            tacoCraze.enabled = true;
            noTacoCraze = true;
            yield return new WaitForSeconds(2f);


            tacoCraze.enabled = false;
        }
             
        
        

    }
}
