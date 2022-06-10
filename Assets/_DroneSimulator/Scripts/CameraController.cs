using UnityEngine;


namespace Deftouch
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 2f;

        private Vector3 difference;
        
        #endregion

        #region UnityMethods
        void Start()
        {
            difference = transform.position - target.position;
        }

        void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + difference, Time.deltaTime * speed);
        }
        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
