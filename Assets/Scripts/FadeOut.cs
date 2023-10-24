using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fadeObject;

    private void Update()
    {
        if (SizeManager.Instance.playerLevel >= 2) 
        {
            fadeObject.SetActive(true);
            animator.SetTrigger("Start");
        }
    }
}
