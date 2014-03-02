using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Transform _horse;

    private void Start()
    {
        _anim = transform.GetChild(0).GetComponent<Animator>();
        _horse = transform.GetChild(0).transform;
    }

    public void Attack()
    {
        _anim.SetBool("Attack", true);
    }

    public void StartRun()
    {
        _anim.SetBool("Run", true);
    }

    public void StopRun()
    {
        _anim.SetBool("Run", false);
        _horse.localEulerAngles = Vector3.zero;
        _horse.localPosition = Vector3.zero;
    }

    public void AttackDone()
    {
        _anim.SetBool("Attack", false);
        _horse.localEulerAngles = Vector3.zero;
        _horse.localPosition = Vector3.zero;
    }

    public void Die()
    {
        _anim.SetTrigger("Die");    
    }

    public void DieDone()
    {
    }
}