using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _player;
    public GameObject _camera;
    public Vector3 savePoint;
    void Start()
    {
        _player = GameObject.Find("Player");
        savePoint = _player.transform.position;
        _camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        
    }

    public void globalDimensionsUpdate()
    {
        _player.GetComponent<CharacterMovement>().updateDimensions();
        _camera.GetComponent<CameraBrain>().updateDimensions();
    }

    public void updateCamera(float cameraDistance, float cameraAltitude)
    {
        _camera.GetComponent<CameraBrain>().cameraDistance = cameraDistance;
        _camera.GetComponent<CameraBrain>().cameraAltitude = cameraAltitude;
    }
}
