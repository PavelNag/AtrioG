using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected abstract void BulletLogicOn(RaycastHit hit);
    protected virtual void BulletLogicOff() { }
    public abstract void Reload();
    public void ShootOn(Transform cam)
    {
        Ray ray = new Ray(cam.position, cam.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            BulletLogicOn(hit);
        }
    }

    public void ShootOff()
    {
        BulletLogicOff();
    }
}
