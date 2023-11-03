using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator.SetBool("IsDead", false);
        animator.SetBool("IsHealed", false);
        animator.SetBool("IsSlouched", false);
        animator.SetBool("Reset", false);
        animator.SetBool("NapTime", false);
    }


    public void LieDown()
    {
        animator.SetBool("NapTime", true);
    }

    public void SlouchYes()
    {
        animator.SetBool("IsSlouched", true);
    }

    public void SlouchNo()
    {
        animator.SetBool("IsSlouched", false);
    }

    public void HealedYes()
    {
        animator.SetBool("IsHealed", true);
    }
    public void HealedNo()
    {
        animator.SetBool("IsHealed", false);
    }

    public void DeadYes()
    {
        animator.SetBool("IsDead", true);
    }

    public void DeadNo()
    {
        animator.SetBool("IsDead", false);
    }

    public void Reset()
    {
        animator.SetBool("Reset", true);
        animator.SetBool("IsDead", false);
        animator.SetBool("IsHealed", false);
        animator.SetBool("IsSlouched", false);

        List <Touch> touches = new();
        touches.AddRange(Input.touches);
    }
}
