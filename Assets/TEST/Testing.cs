using UnityEngine;


namespace Alpha
{
    //[ExecuteInEditMode]
    public class Testing : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OrderConfig config;
        [Space(30)]

        [Range(20f,1500f)]
        public float distance;

        public float calculatedWeight;
        public float curvedWeight;

        public OrderManagementSystem system;
        public GameObject pickup, drop;
        #endregion

        #region UnityMethods


        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                Order order = system.generatedOrders[0];
                pickup.transform.position = order.PickupPoint.position;
                drop.transform.position = order.DropPoint.position;
            }


            //calculatedWeight = Helper.Remap(config.minDistance, config.maxDistance, config.minWeight, config.maxWeight, distance);
            //curvedWeight = Helper.CustomRemapbasedOnCurve(config.weightCurve, config.minDistance, config.maxDistance, config.minWeight, config.maxWeight, distance);
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
