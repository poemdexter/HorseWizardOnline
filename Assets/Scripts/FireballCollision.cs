using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}