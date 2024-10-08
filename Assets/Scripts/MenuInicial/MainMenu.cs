using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AnimationClip fadeOutAnimation;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

    public void Exit()
    {
        print("Saliste");
        Application.Quit ();
    }

    
    IEnumerator ChangeSceneAnim(string sceneName)
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(fadeOutAnimation.length);

        SceneManager.LoadScene(sceneName);

    }
    
}
