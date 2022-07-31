using UnityEngine;


namespace Alpha
{
    public class Item : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;
        private Collider coll;
        #endregion

        #region UnityMethods
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<Collider>();
        }

        
        #endregion

        #region PublicMethods
        public void SetRigidbodyKinematic(bool value)
        {
            coll.isTrigger=value;
            rb.isKinematic = value;
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
