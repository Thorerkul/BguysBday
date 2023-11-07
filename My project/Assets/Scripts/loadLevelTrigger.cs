using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevelTrigger : MonoBehaviour
{
    public string levelToLoad;

    public void loadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
