using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Text score;
    public string newGameScene;

    // Start is called before the first frame update
    void Start()
    {
       score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        ScoreScript.scoreValue = 0;

        SceneManager.LoadScene(newGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
