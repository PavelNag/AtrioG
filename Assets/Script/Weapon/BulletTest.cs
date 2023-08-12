using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class BulletTest : MonoBehaviour
{
    [SerializeField] private float _timeToLife;
    [SerializeField] private LayerMask _layerMask;

    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == _layerMask) return;
        Debug.Log("Hitted: " + other.gameObject.name);
        _poolObject.ReturnToPool();
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeToLife);
        _poolObject.ReturnToPool();
    }
}
