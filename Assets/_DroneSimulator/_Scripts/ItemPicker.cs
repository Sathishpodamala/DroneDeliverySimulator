using UnityEngine;


namespace Alpha
{
    public class ItemPicker : MonoBehaviour
    {
        #region Variables
        public Transform itemHolder;

        public GameObject itemGameObject = null;
        public Item item;

        private DroneInputManager inputManager;
        #endregion

        #region UnityMethods
        private void Awake()
        {
            inputManager = FindObjectOfType<DroneInputManager>();
        }
        void Update()
        {
            if (inputManager.drop)
            {
                if (itemGameObject && item)
                {
                    itemGameObject.transform.SetParent(null);
                    item.SetRigidbodyKinematic(false);
                    itemGameObject = null;
                    item = null;
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<Item>(out item) && !itemGameObject && item)
            {

                itemGameObject = collision.gameObject;
                itemGameObject.transform.SetParent(itemHolder);
                itemGameObject.transform.localPosition = Vector3.zero;
                item.SetRigidbodyKinematic(true);

            }
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
