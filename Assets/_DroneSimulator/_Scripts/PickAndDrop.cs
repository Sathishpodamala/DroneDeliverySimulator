using UnityEngine;
using Alpha.Events;

namespace Alpha
{
    public class PickAndDrop : MonoBehaviour
    {
        #region Variables
        [SerializeField] private DroneInputManager droneInputManager;
        [SerializeField] private ItemPicker itemPicker;

        private bool canPickOrder = false;
        private bool pickedOrder = false;
        #endregion

        #region UnityMethods

        private void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_PICKED_UP, On_Pacakage_PickedUp);
        }

        private void OnDisable()
        {
            EventHandler.UnSubscribe(EventId.EVENT_ON_PACAKAGE_PICKED_UP, On_Pacakage_PickedUp);

        }

        void OnTriggerEnter(Collider other)
        {
            //OnPickPackage(other);
            OnDropPackage(other);
        }

        void OnTriggerStay(Collider other)
        {
            //OnPickPackage(other);
            OnDropPackage(other);
        }


        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods
        private void SetOrderPicked()
        {
            pickedOrder = true;
        }

        private void OnPickPackage(Collider other)
        {
            if (canPickOrder)
            {
                if (other.CompareTag("Player") && droneInputManager.drop)
                {
                    if (other.CompareTag("Item") && other.TryGetComponent<Item>(out Item item))
                    {
                        itemPicker.itemGameObject = other.gameObject;
                        itemPicker.item = item;
                        itemPicker.OnPickPackage();
                        pickedOrder = true;
                    }
                }

            }
        }

        private void OnDropPackage(Collider other)
        {
            if (other.CompareTag("Item") && pickedOrder && droneInputManager.drop)
            {
                EventHandler.BroadCast(EventId.EVENT_ON_PACAKAGE_DELIVERED);
                pickedOrder = false;
            }
        }
        #endregion

        #region GameEventListeners
        private void On_Pacakage_PickedUp(object args)
        {
            Invoke("SetOrderPicked", 5f);
        }
        #endregion
    }
}
