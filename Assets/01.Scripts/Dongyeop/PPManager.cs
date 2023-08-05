using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPManager : MonoBehaviour
{
    public static PPManager Instance;

    [Header("Distance")]
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _whatIsEnemy;
    private bool _isBlurred = false;
    
    [Header("Post processing")]
    [SerializeField] private VolumeProfile _volumeProfile;
    private Vignette _vignette;

    [Header("Co")]
    private IEnumerator _blurredCo;
    private float _currentTime;

    private Vector3 _playerTrm;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple PPManager is running");
        Instance = this;
    }

    private void Start()
    {
        foreach (var pp in _volumeProfile.components)
            _vignette = (Vignette)pp;
        
        _blurredCo = BlureedCo(0, 0);
        _vignette.intensity.value = 0;
        _playerTrm = transform.position; // 차후 수정 해야함. 플레이어 포지션으로 
    }

    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(_playerTrm, _distance, _whatIsEnemy);

        if (collider.Length != 0 && !_isBlurred) //어두워지고
        {
            _isBlurred = true;
            StopCoroutine(_blurredCo);
            _blurredCo = BlureedCo(0.5f, 1);
            StartCoroutine(_blurredCo);
        }
        else if (collider.Length == 0 && _isBlurred) //밝아지고 
        {
            _isBlurred = false;
            StopCoroutine(_blurredCo);
            _blurredCo = BlureedCo(0, 1);
            StartCoroutine(_blurredCo);
        }
    }

    private IEnumerator BlureedCo(float value, float duration)
    {
        float startValue = _vignette.intensity.value; 
        _currentTime = 0;

        while (_currentTime < duration)
        {
            yield return null;
            _currentTime += Time.deltaTime;

            _currentTime = Mathf.Clamp(_currentTime, 0, duration);
            float time = _currentTime / duration;

            _vignette.intensity.value = Mathf.Lerp(startValue, value, time);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_playerTrm, _distance);
        Gizmos.color = Color.white;
    }
}
