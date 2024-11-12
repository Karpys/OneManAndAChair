namespace OMAAC
{
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform[] m_FollowAim = null;
        [SerializeField] private Transform m_PlayerForward = null;
        [SerializeField] private Vector2 m_Sensitivity = Vector2.zero;

        private Vector2 m_CurrentRotation = Vector2.zero;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float horizontalMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * m_Sensitivity.x;
            float verticalMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * m_Sensitivity.y;

            m_CurrentRotation.y += horizontalMouse;
            m_CurrentRotation.x -= verticalMouse;
            m_CurrentRotation.x = Mathf.Clamp(m_CurrentRotation.x, -90f, 90);

            foreach (Transform followAim in m_FollowAim)
            {
                followAim.rotation = Quaternion.Euler(m_CurrentRotation.x, m_CurrentRotation.y, 0);
            }
            
            m_PlayerForward.rotation = Quaternion.Euler(0,m_CurrentRotation.y,0);
        }
    }
}