using UnityEngine;

public class RaycastWeapon : Weapon
{
    [SerializeField] private Transform _LaserTransform;
    private bool LaserOn = false;

    [SerializeField] private AudioClip LaserSound;
    [SerializeField] private AudioSource AudioPlayer;

    [SerializeField] private float _waitingTime;
    [SerializeField] private float _currentWaitingTime;


    public override void Reload() { }

    private void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
        AudioPlayer.clip = LaserSound;
        _currentWaitingTime = _waitingTime;
    }

    protected override void BulletLogicOn(RaycastHit hit)
    {

        if (!LaserOn)
        {
            AudioPlayer.Play();
            LaserOn = true;
        }

        if (_currentWaitingTime <= 0)
        {
            _LaserTransform.gameObject.SetActive(true);
            Debug.Log("Hitted: " + hit.transform.gameObject.name);
            Debug.DrawRay(transform.position, (hit.point - transform.position) * 2000f, Color.red);
        }
        else
        {
            _currentWaitingTime -= Time.deltaTime;
        }


    }

    protected override void BulletLogicOff()
    {
        LaserOn = false;
        _LaserTransform.gameObject.SetActive(false);
        _currentWaitingTime = _waitingTime;
        AudioPlayer.Stop();
    }
}
