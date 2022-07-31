using UnityEngine;
using System.Collections.Generic;

namespace Alpha
{
    public class OrderManagementSystem : MonoBehaviour
    {
        public bool debug;

        #region Variables
        [SerializeField] private List<OrderConfig> orderConfigBySector = new List<OrderConfig>();
        [SerializeField] private SectorsManager sectorsManager;
        [SerializeField] private OrderConfig currentlyUsingConfig;

        [Space(20)]
        [Header("ORDERS")]
        public int numberOfOrdersToGenerate = 5;
        [SerializeField] private List<Order> generatedOrders = new List<Order>();

        private Dictionary<string, Order> ordersDictionary = new Dictionary<string, Order>();
        private OrderGenerator orderGenerator;


        public Dictionary<string, Order> Orders => ordersDictionary;
        #endregion

        #region UnityMethods
        void Start()
        {
            orderGenerator = new OrderGenerator();

            RefreshOrders();


            if (debug)
            {
                for (int i = 0; i < generatedOrders.Count; i++)
                {
                    debugcolors.Add(Random.ColorHSV());
                }
            }

        }

        List<Color> debugcolors = new List<Color>();
        private void OnDrawGizmos()
        {
            if (debug)
            {
                for (int i = 0; i < generatedOrders.Count; i++)
                {
                    Gizmos.color = debugcolors[i];
                    Gizmos.DrawLine(generatedOrders[i].PickupPoint.position, generatedOrders[i].DropPoint.position);

                }
            }
        }

        #endregion

        #region PublicMethods
        public void RefreshOrders()
        {
            generatedOrders.Clear();
            ordersDictionary.Clear();
            generatedOrders = orderGenerator.GenerateBulkOrders(sectorsManager.allBuildings, currentlyUsingConfig, numberOfOrdersToGenerate);
            StoreOrdersIntoDictionary();
        }
        #endregion

        #region PrivateMethods
        private void StoreOrdersIntoDictionary()
        {
            foreach (Order order in generatedOrders)
            {
                Debug.Log("Order Id: " + order.OrderID);
                ordersDictionary.Add(order.OrderID, order);
            }
        }
        #endregion

        #region GameEventListeners

        #endregion
    }
}
