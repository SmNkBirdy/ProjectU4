using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimensionsTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 _wantedDimension;
    [SerializeField] private bool _xAllowed = true;
    [SerializeField] private bool _yAllowed = true;
    [SerializeField] private bool _zAllowed = true;
    [SerializeField] private float cameraDistance = 10f;
    [SerializeField] private float cameraAltitude = 10f;
    [SerializeField] private bool _normalizeX = false;
    [SerializeField] private bool _normalizeZ = false;
    [SerializeField] private float _normalizeSpeed = 2f;
    [SerializeField] private bool _lookAtCamera = false;
    [SerializeField] private GameObject _player;
    private GameObject _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _player = GameObject.Find("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DimensionsManager _DM = _gameManager.GetComponent<DimensionsManager>();
            _DM.DimensionsDirection = _wantedDimension;
            _DM.xDimension = _xAllowed;
            _DM.yDimestion = _yAllowed;
            _DM.zDimestion = _zAllowed;
            _gameManager.GetComponent<GameManager>().globalDimensionsUpdate();
            _gameManager.GetComponent<GameManager>().updateCamera(cameraDistance, cameraAltitude);
            _player.GetComponent<PlayerSight>().LookAtCamera(_lookAtCamera);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_normalizeX)
            {
                if (Mathf.Abs(transform.position.x - other.transform.position.x) < 0.2f)
                {
                    other.GetComponent<CharacterController>().Move(new Vector3(transform.position.x - other.transform.position.x, 0, 0));
                }
                if (transform.position.x != other.transform.position.x)
                {
                    other.GetComponent<CharacterController>().Move(new Vector3(transform.position.x - other.transform.position.x, 0, 0).normalized * _normalizeSpeed * Time.deltaTime);
                }
            }
            if (_normalizeZ)
            {
                if (Mathf.Abs(transform.position.z - other.transform.position.z) < 0.2f)
                {
                    other.GetComponent<CharacterController>().Move(new Vector3(0, 0, transform.position.z - other.transform.position.z));
                }
                if (transform.position.z != other.transform.position.z)
                {
                    other.GetComponent<CharacterController>().Move(new Vector3(0, 0, transform.position.z - other.transform.position.z).normalized * _normalizeSpeed * Time.deltaTime);
                }
            }
        }
    }
}
