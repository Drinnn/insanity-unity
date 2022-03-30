using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void SetWalkAnimation(bool value)
    {
        _animator.SetBool("Walk", value);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0);
    }
}
