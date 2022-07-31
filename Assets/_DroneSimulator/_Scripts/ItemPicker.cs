using UnityEngine;
using Alpha.Events;

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
                if (itemGameObject!=null && item!=null)
                {
                    Debug.Log("Drop");
                    itemGameObject.transform.SetParent(null);
                    item.SetRigidbodyKinematic(false);
                    itemGameObject = null;
                    item = null;
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (itemGameObject != null && item != null)
                return;

            if (collision.transform.TryGetComponent<Item>(out item))
            {

                itemGameObject = collision.gameObject;
                itemGameObject.transform.SetParent(itemHolder);
                itemGameObject.transform.localPosition = Vector3.zero;
                item.SetRigidbodyKinematic(true);


                EventHandler.BroadCast(EventId.EVENT_ON_PACAKAGE_PICKED_UP);
                Debug.Log("Pickup");

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
