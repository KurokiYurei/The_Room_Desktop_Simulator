using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class FPSController : MonoBehaviour
{
    [Header("Player Stats")]
    CharacterController m_CharacterController;
    public float m_Speed = 10.0f;
    public float m_VerticalSpeed = 0.0f;

    public LayerMask m_ShootLayerMask;

    public Camera m_PlayerCamera;
    float m_Yaw;
    float m_Pitch;
    public float m_YawRotationalSpeed = 360.0f;
    public float m_PitchRotationalSpeed = 180.0f;
    public float m_MinPitch = -80.0f;
    public float m_MaxPitch = 50.0f;
    public Transform m_PitchControllerTransform;
    public bool m_InvertedYaw = false;
    public bool m_InvertedPitch = false;

    [Header("Inputs")]
    private PlayerInput m_playerInput;
    private InputAction m_moveAction;
    private InputAction m_lookAction;
    private InputAction m_lanternAction;
    private InputAction m_interactAction;

    [Header("Debug Inputs")]
    public KeyCode m_DebugLockAngleKeyCode = KeyCode.I;
    public KeyCode m_DebugLockKeyCode = KeyCode.O;

    public bool m_AngleLocked = false;
    public bool m_AimLocked = true;


    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        m_playerInput = GetComponent<PlayerInput>();
        m_moveAction = m_playerInput.actions["Movement"];
        m_lookAction = m_playerInput.actions["Look"];
        m_lanternAction = m_playerInput.actions["Lantern"];
        m_interactAction = m_playerInput.actions["Interact"];

        m_Yaw = transform.rotation.eulerAngles.y;
        m_Pitch = m_PitchControllerTransform.localRotation.eulerAngles.x;

        m_CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {

#if UNITY_EDITOR
        if (Input.GetKeyDown(m_DebugLockAngleKeyCode))
        {
            m_AngleLocked = !m_AngleLocked;
        }

        if (Input.GetKeyDown(m_DebugLockKeyCode))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            m_AimLocked = Cursor.lockState == CursorLockMode.Locked;
        }
#endif

        Camera();
        Movement();
    }

    private void LightLantern()
    {

    }

    private void Camera()
    {
        Vector2 inputCamera = m_lookAction.ReadValue<Vector2>();

        float l_MouseAxisX = inputCamera.x;
        float l_MouseAxisY = inputCamera.y;

#if UNITY_EDITOR
        if (m_AngleLocked)
        {
            l_MouseAxisX = 0.0f;
            l_MouseAxisY = 0.0f;
        }
#endif

        m_Pitch += l_MouseAxisY * m_PitchRotationalSpeed * Time.deltaTime * (m_InvertedPitch ? -1.0f : 1.0f);
        m_Yaw += l_MouseAxisX * m_YawRotationalSpeed * Time.deltaTime * (m_InvertedYaw ? -1.0f : 1.0f);

        m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);

        transform.rotation = Quaternion.Euler(0.0f, m_Yaw, 0.0f);
        m_PitchControllerTransform.localRotation = Quaternion.Euler(m_Pitch, 0.0f, 0.0f);

    }

    private void Movement()
    {
        Vector2 input = m_moveAction.ReadValue<Vector2>();

        float l_YawInRadians = m_Yaw * Mathf.Deg2Rad;
        float l_Yaw90InRadians = (m_Yaw + 90.0f) * Mathf.Deg2Rad;
        Vector3 l_Forward = new Vector3(Mathf.Sin(l_YawInRadians), 0.0f, Mathf.Cos(l_YawInRadians));
        Vector3 l_Right = new Vector3(Mathf.Sin(l_Yaw90InRadians), 0.0f, Mathf.Cos(l_Yaw90InRadians));

        Vector3 l_Movement = Vector3.zero;

        l_Movement = l_Right * input.x;
        l_Movement += l_Forward * input.y;

        l_Movement.Normalize();
        l_Movement = l_Movement * Time.deltaTime * m_Speed;
        m_VerticalSpeed += Physics.gravity.y * Time.deltaTime; //3
        l_Movement.y = m_VerticalSpeed * Time.deltaTime; //3

        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);

        //Return vertical speed to 0 to avoid gravity accumulation
        if ((l_CollisionFlags & CollisionFlags.Below) != 0)
        {
            m_VerticalSpeed = 0.0f;
        }
    }
}
