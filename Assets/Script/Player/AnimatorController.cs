using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void SetAnimatorParameters(float p)
    {
        animator.SetFloat("speed", p);
    }
}
