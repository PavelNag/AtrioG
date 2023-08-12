using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon _currentWeapon;
    [SerializeField] private Camera _cam;
    
    private bool _isShoot;
    
    void Update()
    {
        _isShoot = Input.GetButton("Fire1");
        if (_isShoot)
        {
            ShootOn();
        }
        else
        {
            ShootOff();
        }
    }

    private void ShootOn()
    {
        _currentWeapon.ShootOn(_cam.transform);
    }

    private void ShootOff()
    {
        _currentWeapon.ShootOff();
    }
}
