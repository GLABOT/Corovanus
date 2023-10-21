using System;
using UnityEngine;

    public class Client : MonoBehaviour
    {
        [SerializeField] private Transform _cashDeskTransform;
        [SerializeField] private Transform _waitingTransform; // место в котором он ждет заказа
        [SerializeField] private float _distanceFromCashDesk;
        [SerializeField] private float _speed;
        [SerializeField] private float _waitInLineTime; // время которое чел ждет в очереди
        public static Client instance;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _waitTime;
        private bool _isWaitingInLine;
        private bool _isWaitingForOrder;
        private bool _called = true;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public void CallClient()
        {
            _called = true;
        }

        public void ReceiveOrder()
        {
            _isWaitingInLine = false;
        }

        public void ReadyOrder()
        {
            _isWaitingForOrder = false;
        }
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (!_called) return;
            
            if (_isWaitingInLine)
            {
                _waitTime += Time.deltaTime;
                if (_waitTime * 2f > _waitInLineTime)
                    _animator.SetBool("IsAngry", true);
                if (_waitTime > _waitInLineTime)
                {
                    // умираем проигрываем и тп
                }
            }
                
            if (!_isWaitingForOrder && !_isWaitingInLine)
            {
                if (Vector3.Distance(transform.position, _cashDeskTransform.position) > _distanceFromCashDesk)
                {
                    transform.Translate((_cashDeskTransform.position-transform.position) * (_speed * Time.deltaTime));
                    _animator.SetBool("IsWalking", true);
                }
                else
                {
                    _animator.SetBool("IsWalking", false);
                    _isWaitingInLine = true;
                }
            }
            else if (_isWaitingForOrder && !_isWaitingInLine)
            {
                if (Vector3.Distance(transform.position, _waitingTransform.position) > 0.1f)
                {
                    _rigidbody.MovePosition(_cashDeskTransform.position * (_speed * Time.deltaTime));
                    _animator.SetBool("IsWalking", true);
                }
                else
                    _animator.SetBool("IsWalking", false);
            }
            
        }
    }
    