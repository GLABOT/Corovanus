using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsWalking", _playerMovement.isWalking);
        _animator.SetBool("IsHolding", _playerMovement.isHolding);
        _animator.SetBool("IsWashing", _playerMovement.isWashing);
        _animator.SetBool("IsChopping", _playerMovement.isChopping);
        _animator.SetBool("IsSaucing", _playerMovement.isSaucing);
    }
} 