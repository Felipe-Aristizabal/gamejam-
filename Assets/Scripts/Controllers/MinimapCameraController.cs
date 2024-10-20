using UnityEngine;
using UnityEngine.Assertions;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    
    void OnEnable()
    {
        Debug.Log("Im searching");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "There is no GameObject with the tag 'Player' in the scene.");
        playerTransform = player.transform;
    }
    
    void LateUpdate()
    {
        Assert.IsNotNull(playerTransform, "PlayerTransform is null.");
        Vector3 newPosition = playerTransform.position;
        newPosition.y = transform.position.y; 
        transform.position = newPosition;
    }
}
