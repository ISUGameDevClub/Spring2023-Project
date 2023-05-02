using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHandleAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void OnBeginDrag()
    {
        animator.SetBool("hatflip", true);
        Debug.Log("WOOO!");
    }

    public void OnEndDrag()
    {
        animator.SetBool("hatflip", false);
        Debug.Log("awwww!");
    }
}
