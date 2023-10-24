using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public void DisableUIImage() 
    {
        gameObject.SetActive(false);
    }

    public void ChangeScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
