using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public int maxammo = 10;    // 맥시멈 탄 수
    private int currentammo;    // 현재 탄 수
    public TMPro.TextMeshPro text;  // 탄 수 UI

    public AudioSource source;
    public AudioClip fire;      // 발사 사운드
    public AudioClip reload;    // 장전 사운드
    public AudioClip noammo;    // 총알 없을때 사운드

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject line; // 총알 궤적(라인)

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] public Transform barrelLocation;   // Enemy.cs에서 가져갈 수 있도록 public
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] public float shotPower = 100f;   // Enemy.cs에서 상속받길원함
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;
    // 'Tooltip()' : 해당 메뉴에 마우스 hover하면 ()안 내용이 토글됨  

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        Reload();
    }

    void Reload()
    {
        currentammo = maxammo;
        source.PlayOneShot(reload);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (currentammo > 0)
                GetComponent<Animator>().SetTrigger("Fire");
            else
                source.PlayOneShot(noammo);
        }

        // 총의 y축을 기준으로 100도를 기울이면 Reload()
        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < maxammo)
            Reload();

        text.text = currentammo.ToString();
    }

    public void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        currentammo--;
        source.PlayOneShot(fire);

        GameObject tempFlash;
        if (bulletPrefab)
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower, ForceMode.VelocityChange);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100);
        // Hit판정 함수

        if (hasHit)
            hitInfo.collider.SendMessageUpwards("Dead", hitInfo.point, SendMessageOptions.DontRequireReceiver);
        // Hit판정이 발생했을 경우 "Dead" 실행

        if (line)
        {
            GameObject liner = Instantiate(line);
            liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] { barrelLocation.position, barrelLocation.position + barrelLocation.forward * 100 });

            Destroy(liner, 0.5f);
        }

        // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }

}
