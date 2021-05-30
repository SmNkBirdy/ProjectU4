using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;

    [Header("Camera Main Points")]
    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] private Vector3 _watchPosition;
    [SerializeField] private Vector3 _dimensionForward;

    [Header("Focus Objects")]
    public GameObject placeToWatch;
    [SerializeField] private GameObject _player;

    [Header("Settings")]
    public float cameraDistance = 2f;
    public float cameraAltitude = 2f;
    private GameObject _gameManager;

    private void Start()
    {
        _player = GameObject.Find("Player");
        updateDimensions();
    }

    private void Update()
    {
        if (placeToWatch != null)
        {
            _watchPosition = placeToWatch.transform.position;
        }
        else
        {
            _watchPosition = _player.transform.position;
        }
        _cameraPosition = _watchPosition + _dimensionForward * -cameraDistance + Vector3.up * cameraAltitude;

        transform.position = _cameraPosition;
        transform.LookAt(_watchPosition);
    }

    public void updateDimensions()
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        DimensionsManager _DM = _gameManager.GetComponent<DimensionsManager>();
        _dimensionForward = _DM.getForward();
    }
}
