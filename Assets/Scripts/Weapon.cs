using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;

    private StarterAssetsInputs starterAssetsInputs;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (starterAssetsInputs.shoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("We hit " + hit.transform.name);
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                if (enemyHealth)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }
            }
            starterAssetsInputs.ShootInput(false);
        }
    }
}
