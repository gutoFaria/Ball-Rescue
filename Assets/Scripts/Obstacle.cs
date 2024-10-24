using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;
    private float currentRotateSpeed;

    [SerializeField] private float _minRotateTime, _maxRotateTime;
    private float rotateTime;
    private float currentRotateTime;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 axisRotate;

    private void Awake()
    {
        currentRotateTime = 0f;
        currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * 0.1f * Random.Range(0, 11);
        rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);
    }

    private void Update()
    {
        currentRotateTime += Time.deltaTime;

        if (currentRotateTime > rotateTime)
        {
            currentRotateTime = 0f;
            currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * Random.Range(0, 11);
            rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);
            currentRotateSpeed *= Random.Range(0,2) == 0 ? 1f : -1f;
        }
    }

    private void FixedUpdate()
    {
        //transform.Rotate(0,0,currentRotateSpeed * Time.fixedDeltaTime);
        transform.RotateAround(target.position, axisRotate, currentRotateSpeed * Time.fixedDeltaTime);
    }
}
