using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Alpha
{
    public class OrdersVisualManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OrderManagementSystem managementSystem;
        [SerializeField] private List<OrderVisual> visuals = new List<OrderVisual>();

        #endregion

        #region UnityMethods
        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            if (managementSystem && managementSystem.Orders.Count >= visuals.Count)
            {
                int i = 0;
                foreach (KeyValuePair<string,Order> pair in managementSystem.Orders)
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

        #endregion
    }
}
