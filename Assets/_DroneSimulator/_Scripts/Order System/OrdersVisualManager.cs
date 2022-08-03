using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Alpha.Events;

namespace Alpha
{
    public class OrdersVisualManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OrderManagementSystem managementSystem;
        [SerializeField] private List<OrderVisual> visuals = new List<OrderVisual>();

        #endregion

        #region UnityMethods
        void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }

        void OnDisable()
        {
            EventHandler.UnSubscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }


        void Awake()
        {
            if (managementSystem == null)
                managementSystem = FindObjectOfType<OrderManagementSystem>();
        }


        IEnumerator Start()
        {
            yield return new WaitForSeconds(0.2f);

            FillOrdersVisual();
        }

        private void FillOrdersVisual()
        {
            if (managementSystem && managementSystem.Orders.Count >0)
            {
                int i = 0;
                foreach (KeyValuePair<string, Order> pair in managementSystem.Orders)
                {
                    Order order = pair.Value;
                    visuals[i].Init(order.Weight, order.Price, order.OrderID);

                    i++;
                    if (i >= visuals.Count)
                        break;
                }

            }
        }

        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners
        private void On_Pacakage_Delivered(object args)
        {
            //FillOrdersVisual();
        }
        #endregion
    }
}
