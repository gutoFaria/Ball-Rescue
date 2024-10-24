using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private AudioClip _moveClip, _loseClip;

    [SerializeField] private GamePlayManager _gm;
    [SerializeField] private GameObject _explosionPrefab;

    [SerializeField] private float raio;
    private float direction = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 axisRotate;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySound(_moveClip);
            //_rotateSpeed *= -1f;
            //raio *= -1f;
            direction *= -1f;
        }
    }

    void FixedUpdate()
    {
        //transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
        //transform.eulerAngles = new Vector3(0, 0, _rotateSpeed * Time.fixedDeltaTime);

        // transform.position = new Vector3(
        //     raio * Mathf.Cos(Time.timeSinceLevelLoad),
        //     raio * Mathf.Sin(Time.timeSinceLevelLoad),
        //     transform.position.z 
        // );

        transform.RotateAround(target.position, axisRotate * direction, _rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound(_loseClip);
            _gm.GameEnded();
            Destroy(gameObject);
        }
    }
}
