using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Button _phrase1;
    [SerializeField] private Button _phrase2;
    [SerializeField] private Button _phrase3;
    [SerializeField] private Button _phrase4;

    private Vector3 _targetPosition;
    private float _duration = 2.0f;
    private bool _isMoving = false;

    private void Awake()
    {
        _targetPosition = _camera.transform.position;
    }

    public void FirstPhrase()
    {
        if (_phrase1 != null)
        {
            Destroy(_phrase1.gameObject);
            _phrase2.gameObject.SetActive(true);
        }

        if (!_isMoving)
        {
            _targetPosition = new Vector3(55f, 42.8f, 35f);
            StartCoroutine(MoveCameraCoroutine());
        }
    }

    public void SecondPhrase()
    {
        if (_phrase2 != null)
        {
            Destroy(_phrase2.gameObject);
        }
    }

    public void ThirdPhrase()
    {
        if (_phrase3 != null)
        {
            Destroy(_phrase3.gameObject);
        }
    }

    public void FourPhrase()
    {
        if (_phrase4 != null)
        {
            Destroy(_phrase4.gameObject);
        }
    }

    private IEnumerator MoveCameraCoroutine()
    {
        _isMoving = true;

        Vector3 startPosition = _camera.transform.position;
        float startTime = Time.time;

        while ((Time.time - startTime) < _duration)
        {
            float t = (Time.time - startTime) / _duration;
            _camera.transform.position = Vector3.Lerp(startPosition, _targetPosition, t);
            yield return null;
        }

        _camera.transform.position = _targetPosition;

        _isMoving = false;
    }
}
