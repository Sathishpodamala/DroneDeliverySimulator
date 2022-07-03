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
            generatedOrders = orderGenerator.GenerateBulkOrders(sectorsManager.allBuildings, currentlyUsingConfig, numberOfOrdersToGenerate);

            for (int i = 0; i < generatedOrders.Count; i++)
            {
                debugcolors.Add(Random.ColorHSV());
            }

        }

        List<Color> debugcolors = new List<Color>();
        private void OnDrawGizmos()
        {
            for (int i = 0; i < generatedOrders.Count; i++)
            {
                Gizmos.color = debugcolors[i];
                Gizmos.DrawLine(generatedOrders[i].PickupPoint.position, generatedOrders[i].DropPoint.position);
            
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
