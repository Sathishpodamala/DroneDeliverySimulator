using UnityEngine;
using Alpha.Events;

namespace Alpha
{
    public class OrderTracker : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OrderManagementSystem managementSystem;
        [SerializeField] private GameObject box;
        [SerializeField] private Order currentOrder;
        #endregion

        #region UnityMethods
        void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_ORDER_ACCEPTED, Event_OnOrder_Accepted);
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }

        void OnDisable()
        {
            EventHandler.UnSubscribe(EventId.EVENT_ON_ORDER_ACCEPTED, Event_OnOrder_Accepted);
            EventHandler.UnSubscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);

        }

        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners
        private void Event_OnOrder_Accepted(object args)
        {
            string id = (string)args;
            Debug.Log("ID: " + id);

            if(managementSystem)
            {
                currentOrder = managementSystem.Orders[id];
                box.transform.position = currentOrder.PickupPoint.position;
            }
        }


        private void On_Pacakage_Delivered(object args)
        {
            managementSystem.RemoveOrderById(currentOrder.OrderID);
            currentOrder= null;
        }

        #endregion
    }
}
