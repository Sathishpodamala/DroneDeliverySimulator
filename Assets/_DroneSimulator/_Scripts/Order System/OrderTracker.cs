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
        }

        void OnDisable()
        {
            EventHandler.UnSubscribe(EventId.EVENT_ON_ORDER_ACCEPTED, Event_OnOrder_Accepted);

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
        #endregion
    }
}
