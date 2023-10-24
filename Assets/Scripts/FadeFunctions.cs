using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeFunctions : MonoBehaviour
{
    public void DisableUI() 
    {
        Debug.Log("HUUH");
        gameObject.SetActive(false);
    }

    public void ChangeScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
