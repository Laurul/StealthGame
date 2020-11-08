using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject levelFinish;
    [SerializeField] int unlock;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //unlock = SceneManager.GetActiveScene().buildIndex + 1;
        levelFinish.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("levelFinished", unlock);
            levelFinish.SetActive(true);
        }
    }
}
