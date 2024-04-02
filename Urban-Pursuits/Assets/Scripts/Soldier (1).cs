using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Soldier : vp_DamageHandler
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    public GameObject Player;
    public float AttackDistance = 10.0f;
    public float FollowDistance = 20.0f;
    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;
    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;
    public float DamagePoints = 2.0f;
    public AudioClip GunSound = null;

    protected void Awake()
    {
       

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            bool shoot = false;
            bool follow = (dist < FollowDistance);

            if (follow)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - AttackProbability) && dist < AttackDistance)
                {
                    shoot = true;
                }
            }

            if (follow)
            {
                _navMeshAgent.SetDestination(Player.transform.position);
            }

            if (!follow || shoot)
                _navMeshAgent.SetDestination(transform.position);

            _animator.SetBool("Shoot", shoot);
            _animator.SetBool("Run", follow);
        }
    }

    public void ShootEvent()
    {
        
        float random = Random.Range(0.0f, 1.0f);

        // The higher the accuracy is, the more likely the player will be hit
        bool isHit = random > 1.0f - HitAccuracy;

        if (isHit)
        {
            Player.SendMessage("Damage", DamagePoints, SendMessageOptions.DontRequireReceiver);
        }
    }

    public override void Die()
    {
        if (!enabled || !vp_Utility.IsActive(gameObject))
            return;

        

        _navMeshAgent.enabled = false;

        _animator.SetBool("IsFollow", false);
        _animator.SetBool("Attack", false);

        _animator.SetTrigger("Die");

        Destroy(GetComponent<vp_SurfaceIdentifier>());
    }
}
