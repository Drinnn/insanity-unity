using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    private SpriteRenderer _weaponRenderer;

    [SerializeField] private int playerSortingOrder = 0;

    private void Awake()
    {
        _weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool value)
    {
        int flipModifier = value ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public void RenderBehindHead(bool value)
    {
        if (value)
        {
            _weaponRenderer.sortingOrder = playerSortingOrder - 1;
        }
        else
        {
            _weaponRenderer.sortingOrder = playerSortingOrder + 1;
        }
    }

}
