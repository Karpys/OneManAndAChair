namespace OMAAC
{
    using UnityEngine;

    public class FollowPosition : MonoBehaviour
    {
        [SerializeField] private Transform m_Transform = null;
        [SerializeField] private Transform m_Target = null;

        private void LateUpdate()
        {
            m_Transform.position = m_Target.position;
        }
    }
}