using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToTheScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void FadeOut()
    {
        if (animator)
        {
            animator.SetBool("isFadeOut", true);
        }
    }
    void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToTheScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
