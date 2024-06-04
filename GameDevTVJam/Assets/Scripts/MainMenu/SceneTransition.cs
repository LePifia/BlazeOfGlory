
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    Animator animator;

    [SerializeField] AnimationClip endClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SceneManagement.Instance.OnSceneChange += Instance_OnSceneChange;
    }



    IEnumerator SceneChange()
    {
        animator.SetTrigger("Launch");

        yield return new WaitForSeconds(endClip.length);
    }

    private void Instance_OnSceneChange(object sender, System.EventArgs e)
    {
        StartCoroutine(SceneChange());
    }
}
