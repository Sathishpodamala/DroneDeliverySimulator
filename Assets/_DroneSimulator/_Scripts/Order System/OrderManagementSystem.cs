using UnityEngine;
using System.Collections.Generic;
using Alpha.Events;

namespace Alpha
{
    public class OrderManagementSystem : MonoBehaviour
    {
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

        void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }
        void OnDisable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_PACAKAGE_DELIVERED, On_Pacakage_Delivered);
        }

        void Start()
        {
            orderGenerator = new OrderGenerator();
            RefreshOrders();

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

        public Order GetOrderById(string id)
        {
            if (ordersDictionary.TryGetValue(id, out Order order))
                return order;
            return null;
        }

        public void RemoveOrderById(string id)
        {
            if (ordersDictionary.ContainsKey(id))
                ordersDictionary.Remove(id);
        }
        #endregion

        #region PrivateMethods
        private void StoreOrdersIntoDictionary()
        {
            foreach (Order order in generatedOrders)
            {
                ordersDictionary.Add(order.OrderID, order);
            }
        }

        private void AddOrderToDictionary(Order order)
        {
            if (!ordersDictionary.ContainsKey(order.OrderID))
                ordersDictionary.Add(order.OrderID, order);
        }
        #endregion

        #region GameEventListeners
        private void On_Pacakage_Delivered(object args)
        {
            //Generate new order
            Order order = orderGenerator.GenerateOrder(sectorsManager.allBuildings, currentlyUsingConfig);
            AddOrderToDictionary(order);
        }
        #endregion
    }
}
