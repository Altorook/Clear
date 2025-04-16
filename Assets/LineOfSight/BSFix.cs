using UnityEngine;

public class BSFix : MonoBehaviour
{
    [SerializeField] Camera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera.orthographicSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
