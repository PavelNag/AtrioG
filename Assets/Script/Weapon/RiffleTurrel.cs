using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andtech.ProTracer;
using UnityEngine;

public class RiffleTurrel : Weapon
{
    [SerializeField] private List<Burrel> Burrels = new List<Burrel>();
    private int _burrelIndex = 0;
    private AudioSource AudioPlayer;
    
    [SerializeField] private float Speed => 10.0F + (tracerSpeed - 1) * 50.0F;
    [SerializeField] private int tracerSpeed = 3;
    [SerializeField] private float maxQueryDistance;

    [SerializeField] private bool applyStrobeOffset;
    [SerializeField] private bool useGravity;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private SmokeTrail smokeTrailPrefab;

    [SerializeField] private float _fireRate;
    private float _curTimeOut;

    private void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        _curTimeOut += Time.deltaTime;
    }

    public override void Reload()
    {
    }

    protected override void BulletLogicOn(RaycastHit hit)
    {
        if (_curTimeOut > _fireRate)
        {
            _curTimeOut = 0;

            Fire(hit, Burrels[_burrelIndex].Muzzle);
            
        }

    }
    public void Fire(RaycastHit hit, Transform MuzzlePosition)
    {
        _burrelIndex++;
        if (_burrelIndex > 1)
        {
            _burrelIndex = 0;
        }

        // Compute tracer parameters
        float speed = Speed;
        float offset;

        if (applyStrobeOffset)
            offset = UnityEngine.Random.Range(0.0F, CalculateStroboscopicOffset(speed));
        else
            offset = 0.0F;

        // Instantiate the tracer graphics
        Bullet bullet = Instantiate(bulletPrefab, MuzzlePosition.position, MuzzlePosition.rotation);
        SmokeTrail smokeTrail = Instantiate(smokeTrailPrefab, MuzzlePosition.position, MuzzlePosition.rotation);

        PlaySound(Burrels[_burrelIndex].AudioClips, bullet.audioSource);

        // Since start and end point are known, use DrawLine
        bullet.DrawLine(MuzzlePosition.position, hit.point, speed, offset);
        smokeTrail.DrawLine(MuzzlePosition.position, hit.point, speed, offset);


    }
    private float CalculateStroboscopicOffset(float speed) => speed * Time.smoothDeltaTime;

    private void PlaySound(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}

[Serializable]
public class Burrel
{
    public string Name = "Turrel";
    public Transform Muzzle;
    public AudioClip AudioClips;

}
