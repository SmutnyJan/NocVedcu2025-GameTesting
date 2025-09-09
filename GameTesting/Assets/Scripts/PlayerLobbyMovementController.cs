using UnityEngine;

public class PlayerLobbyMovementController : MonoBehaviour
{
    public int MovementSpeed;
    private PlayerLobbyMovement _inputSystem;
    private Rigidbody2D _rigidbody;
    private Vector3 _scale;
    private Animator _animator;

    private void Awake()
    {
        _inputSystem = new PlayerLobbyMovement();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _scale = this.transform.localScale;
    }

    private void OnEnable()
    {
        _inputSystem.PlayerLobby.Enable();
    }

    public void OnReset()
    {
        SceneChanger.Instance.ResetScene();
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = _inputSystem.PlayerLobby.Movement.ReadValue<Vector2>();
        moveDir.x = moveDir.x * -1;
        if (!_animator.GetBool("IsRunning") && (moveDir.x != 0 || moveDir.y != 0))
        {
            _animator.SetBool("IsRunning", true);
        }
        else if(_animator.GetBool("IsRunning") && (moveDir.x == 0 && moveDir.y == 0))
        {
            _animator.SetBool("IsRunning", false);
        }

        if (transform.localScale.x == -_scale.x && moveDir.x > 0)
        {
            transform.localScale = new Vector3(_scale.x, _scale.y, _scale.z);
        }
        else if (transform.localScale.x == _scale.x && moveDir.x < 0)
        {
            transform.localScale = new Vector3(-_scale.x, _scale.y, _scale.z);
        }

        if(moveDir.x > 0)
        {
            moveDir *= 1.75f;
        }

        _rigidbody.linearVelocity = moveDir * MovementSpeed;
    }

    private void OnDisable()
    {
        _inputSystem?.PlayerLobby.Disable();
    }
}
