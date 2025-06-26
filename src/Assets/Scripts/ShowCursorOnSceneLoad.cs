using UnityEngine;

public class ShowCursorOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}