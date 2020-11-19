using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator _playerAnimator;
    private bool _sideMoveLock;
    public int weapon = 1;
    public bool dead;
    private static readonly int Movement1 = Animator.StringToHash("Move"),
        Forward = Animator.StringToHash("Forward"),
        Weapon = Animator.StringToHash("Weapon"),
        MoveRight = Animator.StringToHash("Move_Right"),
        MoveLeft = Animator.StringToHash("Move_Left"),
        DieTrigger = Animator.StringToHash("Die");

    private void Start()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (dead) return;
        if (Input.GetKey(KeyCode.W))
        {
            _playerAnimator.SetBool(Movement1, true);
            _playerAnimator.SetBool(Forward, true);

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

    public void ChangeWeapon()
    {
        if (_playerAnimator == null)
        {
            if (!IsInvoking(nameof(ChangeWeapon))) Invoke(nameof(ChangeWeapon), .2f);
        }
        else
        {
            _playerAnimator.SetInteger(Weapon, weapon);
        }
    }

    public void Die()
    {
        dead = true;
        _playerAnimator.SetBool(Movement1, false);
        _playerAnimator.SetBool(Forward, false);
        _playerAnimator.SetTrigger(DieTrigger);
    }
}
