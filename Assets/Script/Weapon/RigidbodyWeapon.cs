using UnityEngine;

public class RigidbodyWeapon : Weapon
{
    [SerializeField] private Transform _barrel;
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _bulletContainer;

    [SerializeField] private float _fireRate;
    [SerializeField] private float _bulletForce = 10f;
   
    [SerializeField] private AudioClip AudioClips;
    private AudioSource AudioPlayer;

    private float _curTimeOut;

    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        _curTimeOut += Time.deltaTime;
    }

    private void SpawnBullet(RaycastHit hit)
    {
        PlaySound(AudioClips, AudioPlayer);
        Vector3 SpawnPoint = _barrel.position;

        Quaternion SpawnRot = _barrel.rotation;

        Transform Bullet = Instantiate(_bulletPrefab, SpawnPoint, SpawnRot, _bulletContainer); ;

        Rigidbody BulReg = Bullet.GetComponent<Rigidbody>();
        BulReg.velocity = Vector3.zero;
        BulReg.AddForce((hit.point - BulReg.transform.position) * _bulletForce, ForceMode.Impulse);
        Debug.DrawRay(_barrel.position, (hit.point - _barrel.position) * 2000f, Color.red);
    }

    public override void Reload() {  }

    protected override void BulletLogicOn(RaycastHit hit)
    {
        if (_curTimeOut > _fireRate)
        {
            _curTimeOut = 0;
            
            SpawnBullet(hit);
        }
    }

    private void PlaySound(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
