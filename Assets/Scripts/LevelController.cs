using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfEnemies = 0;
    bool timerExpired = false;

    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelTimerExpired()
    {
        timerExpired = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }

    }

    public void AddToEnemies()
    {
        numberOfEnemies++;
    }

    public void SubtractFromEnemies()
    {
        numberOfEnemies--;

        if(numberOfEnemies <= 0 && timerExpired)
        {
            Debug.Log("End Level Now");

            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
