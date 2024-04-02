using UnityEngine;

public class vp_DamageHandler : MonoBehaviour
{
    // This method is intended to be overridden by inheriting classes
    // to handle what happens when the GameObject receives damage.
    public virtual void Damage(float damageAmount)
    {
        // Placeholder implementation
        Debug.Log("Received damage: " + damageAmount);
    }

    // This method is intended to be overridden by inheriting classes
    // to handle what happens when the GameObject dies.
    public virtual void Die()
    {
        // Placeholder implementation
        Debug.Log("Object has died.");
    }
}
