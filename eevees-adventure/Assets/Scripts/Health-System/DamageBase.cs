using UnityEngine;

public class DamageBase : MonoBehaviour
{
    public int damage = 1;
    public DamageCategories damagesCategory;

    [SerializeField] private Collider _collider;

    private void Awake()
    {
        this._collider = GetComponent<Collider>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // If the damageCategory of the other object does not equal ALL or damagesCategory return null.
        if (other.GetComponent<HealthSystemBase>().damageCategory != this.damagesCategory 
            && this.damagesCategory != DamageCategories.ALL) return;


        switch (other.GetComponent<HealthSystemBase>().damageCategory)
        {
            case DamageCategories.PLAYER:
                other.GetComponent<PlayerHealthController>().AddDamage(this.damage);
                break;

            default:
                other.GetComponent<HealthSystemBase>().AddDamage(this.damage);
                break;
        }
    }
}
