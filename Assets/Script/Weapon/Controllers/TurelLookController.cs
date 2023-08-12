using UnityEngine;

public class TurelLookController : MonoBehaviour
{
    
    [SerializeField] private Transform _turel;
    [SerializeField] private Transform _aimPoint;
    [SerializeField] private Transform _player;
    [SerializeField] private float _topClamp = 70; 
    [SerializeField] private float _bottomClamp = -30f; 
    [SerializeField] private float _angularSpeed;
    
    [SerializeField] private float _centringSpeed;

    private Vector3 _startRotation; 

    private bool isAiming = false;

    private void Update()
    {
        _startRotation = _player.forward;
        isAiming = Input.GetButton("Fire2");
    }

    private void LateUpdate()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (isAiming)
        {
            Vector3 dir = (_aimPoint.transform.position - _turel.transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(new Vector3(dir.x, dir.y, dir.z));
            _turel.rotation = Quaternion.Lerp(_turel.rotation, rot, 5 * Time.deltaTime);
        }
        else
        {   
            CentreCamRotLerp();
        }
    }
    
    private void CentreCamRotLerp()
    {
        Quaternion dir = Quaternion.Euler(_player.eulerAngles);
        _turel.rotation = Quaternion.Slerp(_turel.rotation,  dir , 1f * Time.deltaTime);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_turel.position, _aimPoint.position - _turel.position);
    }
}
