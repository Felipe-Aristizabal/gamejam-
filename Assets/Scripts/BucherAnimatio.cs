using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonMover : MonoBehaviour
{
    [SerializeField] private float moveDistance = 50f; 
    [SerializeField] private float duration = 0.3f; 
    [SerializeField] private ButtonMover[] otherButtons;

    private Vector3 originalPosition;
    private bool isMovedDown = false;

    void Start()
    {
        originalPosition = transform.localPosition; 
        
        GetComponent<Button>().onClick.AddListener(ToggleButtonPosition);
    }

    void ToggleButtonPosition()
    {
        if (isMovedDown)
        {
            StartCoroutine(MoveToPosition(originalPosition));
        }
        else
        {
            Vector3 targetPosition = originalPosition - new Vector3(0, moveDistance, 0);
            StartCoroutine(MoveToPosition(targetPosition));
            
            foreach (ButtonMover otherButton in otherButtons)
            {
                if (otherButton.isMovedDown) 
                {
                    otherButton.ResetButtonPosition();
                }
            }
        }
        
        isMovedDown = !isMovedDown;
    }

    public void ResetButtonPosition()
    {
        if (isMovedDown)
        {
            StartCoroutine(MoveToPosition(originalPosition));
            isMovedDown = false;
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition; 
    }
}