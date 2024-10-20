using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public float rotationSpeed = 10f;  
    public float scaleSpeed = 2f;      
    public float scaleAmount = 0.5f;   

    private Vector3 initialScale;
    private float time;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        RotateStar();
        ScaleStar();
    }

    private void RotateStar()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void ScaleStar()
    {
        time += Time.deltaTime * scaleSpeed;
        float scale = Mathf.Sin(time) * scaleAmount + 1; 
        transform.localScale = new Vector3(initialScale.x * scale, initialScale.y * scale, initialScale.z * scale);
    }
}
