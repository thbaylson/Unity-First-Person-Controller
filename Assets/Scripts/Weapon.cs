using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;

    private StarterAssetsInputs starterAssetsInputs;

    const string ANIM_SHOOT = "Shoot";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) { return; }

        muzzleFlash.Play();
        animator.Play(ANIM_SHOOT, 0, 0f);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            hit.transform.GetComponent<EnemyHealth>()?.TakeDamage(damageAmount);
        }

        starterAssetsInputs.ShootInput(false);
    }
}
