using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float movementSpeed = 50f;
    
    private Animator _animator;
    private CharacterController _characterController;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X");
        _animator.SetFloat("Speed", vertical);
        if (Input.GetMouseButton(1) == false)
        {
            transform.Rotate(Vector3.up,mouseHorizontal*Time.deltaTime*rotationSpeed);
        }
        _characterController.SimpleMove(transform.forward * Time.deltaTime * movementSpeed * vertical);
    }
}
