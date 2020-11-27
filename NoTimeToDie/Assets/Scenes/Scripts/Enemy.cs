using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SimpleShoot shooter; // SimpleShoot.cs의 shooter객체 생성
    // Start is called before the first frame update
    void Start()
    {
        SetupRegdoll(true); 
        // 시작 시 물리적 관성을 끔으로써 enemy의 부위별 regdoll이 중력의 영향을 받지않아 
        // 땅바닥으로 곤두박질 치지 않는다.
    }

    Vector3 GetTarget()
    {
        return ((Camera.main.transform.position - shooter.barrelLocation.position) / 3) + new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
        // forward를 플레이어를 쳐다보도록 normalized(정규화) 
    }

    void SetupRegdoll(bool value)
    {
        foreach(var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = value;   
            // Rigidbody를 적용했으므로 물리적관성(kinematic)  영향을 설정할 수 있음
            // 각 부위 Regdoll의 kinematic 켜기 : 물리적 관성 끄기
        }
    }

    void Dead(Vector3 hitPoint)
    {
        GetComponent<Animator>().enabled = false;   // enemy가 Dead()됬을 경우 애니메이션 stop
        SetupRegdoll(false);

        foreach(var item in Physics.OverlapSphere(hitPoint, 0.5f))  // 1.조건
        // 주변의 collider 호출하기 (collider를 기준으로 어떤 1.조건 을 주고 서로간의 그 조건에 충족하면 2.event 를 발생시킴)
        {
            // 2.event
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
                rb.AddExplosionForce(1000, hitPoint, 0.5f);
        } 

        this.enabled = false;
    }

    void Shoot()
    {
        shooter.barrelLocation.forward = GetTarget().normalized;
        shooter.shotPower = GetTarget().magnitude;  // magnitude = VectorX.distance = 오브젝트간의 거리 체크
        shooter.Shoot();    // SimpleShoot.cs에서 Shoot() 함수 가져오기
    }
}
