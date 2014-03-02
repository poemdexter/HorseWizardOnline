using UnityEngine;
using System.Collections;

public class AnimTriggerCatch : MonoBehaviour
{
    private PlayerAttack _playerAttack;
    private PlayerAnimation _playerAnimation;
    
    void Start()
    {
        _playerAttack = transform.parent.GetComponent<PlayerAttack>();
        _playerAnimation = transform.parent.GetComponent<PlayerAnimation>();
    }

    public void EmitFireball()
    {
        _playerAttack.EmitFireball();
    }

    public void AttackDone()
    {
        _playerAnimation.AttackDone();
    }

    public void DieDone()
    {
        _playerAnimation.DieDone();
    }
}
