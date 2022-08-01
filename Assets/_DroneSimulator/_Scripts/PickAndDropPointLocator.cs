using UnityEngine;
using Alpha.Events;

namespace Alpha
{
    public class PickAndDropPointLocator : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject lightBeamEffect;
        [SerializeField] private OrderManagementSystem orderManagementSystem;
        private Order currentOrder = null;
        #endregion

        #region UnityMethods
        void Awake()
        {
            if (orderManagementSystem == null)
                orderManagementSystem = GetComponent<OrderManagementSystem>();

            lightBeamEffect.SetActive(false);
        }

        void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_ORDER_ACCEPTED, On_Order_Accepted);
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_PICKED_UP, On_Pacakage_PickedUp);
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }

        void OnDisable()
        {
            EventHandler.UnSubscribe(EventId.EVENT_ON_ORDER_ACCEPTED, On_Order_Accepted);
            EventHandler.UnSubscribe(EventId.EVENT_ON_PACAKAGE_PICKED_UP, On_Pacakage_PickedUp);
            EventHandler.UnSubscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }
        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods
        private void LocatePickupAndDropPoint(Vector3 beamPosition)
        {
            transform.position = beamPosition;
            lightBeamEffect?.SetActive(true);
        }

        private void DisableBeam()
        {
            lightBeamEffect?.SetActive(false);
        }
        #endregion

        #region GameEventListeners
        private void On_Order_Accepted(object args)
        {
            string id = (string)args;
            if(orderManagementSystem!=null)
            {
                currentOrder=orderManagementSystem.GetOrderById(id);
            }

            if(currentOrder!=null)
            {
               if(currentOrder.PickupPoint)
                {
                    LocatePickupAndDropPoint(currentOrder.PickupPoint.position);
                }
            }
        }

        private void On_Pacakage_PickedUp(object args)
        {
            if(currentOrder!=null)
            {
                if(currentOrder.DropPoint!=null)
                {
                    LocatePickupAndDropPoint(currentOrder.DropPoint.position);
                }
            }
        }

        private void On_Pacakage_Delivered(object args)
        {
            DisableBeam();
        }

        #endregion
    }
}
