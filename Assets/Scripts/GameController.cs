using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Screen.lockCursor = true;
        }
    }
}