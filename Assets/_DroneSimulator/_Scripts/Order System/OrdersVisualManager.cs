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

            if (managementSystem && managementSystem.generatedOrders.Count >= visuals.Count)
            {
                for (int i = 0; i < visuals.Count; i++)
                {
                    Order order = managementSystem.generatedOrders[i];
                    visuals[i].Init(order.Weight, order.Price);
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
