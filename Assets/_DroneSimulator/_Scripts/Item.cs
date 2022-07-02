using UnityEngine;


namespace Alpha
{
    public class Item : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;
        #endregion

        #region UnityMethods
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        
        #endregion

        #region PublicMethods
        public void SetRigidbodyKinematic(bool value)
        {
            Debug.Log(value);
            rb.isKinematic = value;
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
