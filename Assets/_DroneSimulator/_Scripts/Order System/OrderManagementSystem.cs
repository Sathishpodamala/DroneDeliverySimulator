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
        public List<Order> generatedOrders = new List<Order>();


        private OrderGenerator orderGenerator;
        #endregion

        #region UnityMethods
        void Start()
        {
            orderGenerator = new OrderGenerator();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                generatedOrders = orderGenerator.GenerateBulkOrders(sectorsManager.allBuildings, currentlyUsingConfig, numberOfOrdersToGenerate);
            }
        }
        private void OnDrawGizmos()
        {
            if (!debug) return;
            foreach (Order order in generatedOrders)
            {

                Gizmos.color = Random.ColorHSV();
                Gizmos.DrawLine(order.PickupPoint.position, order.DropPoint.position);
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
