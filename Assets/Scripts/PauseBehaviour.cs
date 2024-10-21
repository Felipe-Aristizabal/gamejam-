using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
}
