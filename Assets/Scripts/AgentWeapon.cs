using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected WeaponRenderer _weaponRenderer;

    private float desiredAngle;

    private void Awake()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;

        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    protected void AdjustWeaponRendering()
    {
        _weaponRenderer?.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
        _weaponRenderer?.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);
    }

}
