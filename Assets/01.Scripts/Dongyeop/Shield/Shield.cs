using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Shield : MonoBehaviour
{
    [SerializeField] private List<Sprite> _knifeSprite;

    private float _contractibleSpeed;
    private Transform _knife;
    private SpriteRenderer _knifeSpriteRenderer;
    private TrailRenderer _knifeTraileRenderer;
    private Vector3 _knifeDir;
    private TextMeshProUGUI _txt;
    private KeyCode _keyCode;
    private ShieldKeyState _shieldKeyState;

    private IEnumerator _contractibleCo;

    public ParticleSystem particle;

    private void Awake()
    {
        _txt = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        _knife = transform.GetChild(1).transform;
        _knifeSpriteRenderer = _knife.GetChild(0).GetComponent<SpriteRenderer>();
        _knifeTraileRenderer = _knifeSpriteRenderer.GetComponent<TrailRenderer>();
        _contractibleCo = ContractibleCo(0);
        StartCoroutine(_contractibleCo);
        Init(2);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;
        
        InputCheck();
    }

    public void Init(float contractibleSpeed)
    {
        Vector2 pos;
        pos.x = Random.Range(-14.0f, 14.0f);
        pos.y = Random.Range(2f, 7.0f);
        transform.position = pos;

        KnifeSpawn(contractibleSpeed);
        
        _contractibleSpeed = contractibleSpeed;
        _shieldKeyState = (ShieldKeyState)Random.Range(0, 4);
        
        switch (_shieldKeyState)
        {
            case ShieldKeyState.Q:
                _keyCode = KeyCode.Q;
                _txt.text = "Q";
                break;
            case ShieldKeyState.W:
                _keyCode = KeyCode.W;
                _txt.text = "W";
                break;
            case ShieldKeyState.E:
                _keyCode = KeyCode.E;
                _txt.text = "E";
                break;
            case ShieldKeyState.R:
                _keyCode = KeyCode.R;
                _txt.text = "R";
                break;
        }
    }

    private void KnifeSpawn(float contractibleSpeed)
    {
        float x = Random.Range(0.0f, 7.5f);
        float y = 7.5f - x;

        if (Random.Range(0, 2) == 0)
            x *= -1f;
        if (Random.Range(0, 2) == 0)
            y *= -1f;

        _knife.localPosition = new Vector3(x, y, 0);
        _knifeTraileRenderer.Clear();
        
        _knifeDir = transform.position - _knife.position;
        float angle = Mathf.Atan2(_knifeDir.y, _knifeDir.x) * Mathf.Rad2Deg;
        _knife.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        _knifeSpriteRenderer.sprite = _knifeSprite[Random.Range(0, _knifeSprite.Count)];
        
        StopCoroutine(_contractibleCo);
        _contractibleCo = ContractibleCo(contractibleSpeed);
        StartCoroutine(_contractibleCo);
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            Instantiate(particle.gameObject, transform.position, Quaternion.identity);

            GameManager.Instance.Score += Vector3.Distance(transform.position, _knife.position);

            Init(_contractibleSpeed - (_contractibleSpeed / 50));
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
            GameManager.Instance.GameOver();
    }

    private IEnumerator ContractibleCo(float durationTime)
    {
        Vector3 startPos = _knife.position;
        float _currentTime = 0;

        while (_currentTime <= durationTime)
        {
            yield return null;
            _currentTime += Time.deltaTime;

            _currentTime = Mathf.Clamp(_currentTime, 0, durationTime);

            float time = _currentTime / durationTime;
            _knife.position = Vector3.Lerp(startPos, transform.position, time);
            
            if (Vector3.Distance(transform.position, _knife.position) <= 1.25f)
                GameManager.Instance.GameOver();
        }
    }
}
