using UnityEngine;
using Alpha.Events;

namespace Alpha
{
    public class OrderTracker : MonoBehaviour
    {
        #region Variables
        [SerializeField] private bool debug = true;
        public float radius = 1f;
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

        private void OnDrawGizmos()
        {
            if(debug)
            {
                if(currentOrder!=null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(currentOrder.PickupPoint.position, radius);
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(currentOrder.DropPoint.position, radius);
                }
            }
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
                debug=true;
            }
        }
        #endregion
    }
}
