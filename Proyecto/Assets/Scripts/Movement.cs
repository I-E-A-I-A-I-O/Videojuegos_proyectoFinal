using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator _playerAnimator;
    private bool _sideMoveLock;
    private static readonly int Movement1 = Animator.StringToHash("Move"),
        Forward = Animator.StringToHash("Forward"),
        Weapon = Animator.StringToHash("Weapon"),
        MoveRight = Animator.StringToHash("Move_Right"),
        MoveLeft = Animator.StringToHash("Move_Left");

    private void Start()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playerAnimator.SetBool(Movement1, true);
            _playerAnimator.SetBool(Forward, true);
            _playerAnimator.SetInteger(Weapon, 0);
        }
        else
        {
            _playerAnimator.SetBool(Movement1, false);
            _playerAnimator.SetBool(Forward, false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (_sideMoveLock) return;
            _sideMoveLock = true;
            Invoke(nameof(ChangeSideMoveLock), 0.9f);
            _playerAnimator.SetTrigger(MoveLeft);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_sideMoveLock) return;
            _sideMoveLock = true;
            Invoke(nameof(ChangeSideMoveLock), 0.9f);
            _playerAnimator.SetTrigger(MoveRight);
        }
    }

    private void ChangeSideMoveLock()
    {
        _sideMoveLock = !_sideMoveLock;
    }
}
