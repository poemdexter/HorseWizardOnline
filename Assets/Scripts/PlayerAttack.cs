using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Fireball;
    public float FireballSpeed;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _playerAnimation.Attack();
    }

    public void EmitFireball()
    {
        var fb = (GameObject) Instantiate(Fireball, GetFireballPosition(), transform.rotation);
        fb.rigidbody.velocity = transform.forward * FireballSpeed;
    }

    private Vector3 GetFireballPosition()
    {
        return transform.position + (transform.forward*.2f) + (Vector3.up*.4f);
    }
}