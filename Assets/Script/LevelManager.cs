using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("GameOverUI")]
    public GameObject GameOverPanal;
    public GameObject RestartLevel;
    public GameObject NextLevel;

    [Header("Current Level")]
    public int currentLevel;

    private void Start()
    {
        instance = this;
        GameOverPanal.SetActive(false);
        RestartLevel.SetActive(false);
        NextLevel.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Restart()
    {
        //Restart same level after rester click
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        


    }
    public void loadLevel()
    {
        StartCoroutine(load());
        //reload same scene with different value
        

    }

    IEnumerator load()
    {
        //load next level every time 
        /*GameManager.instance.maxPassengersLoad = 65;
        GameManager.instance.PassengersCount = 100;
        GameManager.instance.explodeTrainCount = 80;*/
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(currentLevel+1);
    }
}
