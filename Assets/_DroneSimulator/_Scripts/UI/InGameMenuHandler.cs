using UnityEngine;
using Alpha.Events;

namespace Alpha
{
    public class InGameMenuHandler : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Canvas rootCanvas;
        [SerializeField] private GameObject ordersButton;

        [Header("Runtime Instance Prefabs")]
        [SerializeField] private GameObject ordersManagementPrefab;
        [SerializeField] private GameObject onScreenTouchInputPrefab;


        private GameObject onScreenTouchInputPrefabInstance;
        private GameObject orderManagementPrefabInstance;
        #endregion

        #region UnityMethods

        void OnEnable()
        {
            EventHandler.Subscribe(EventId.EVENT_ON_ORDER_ACCEPTED, On_Order_Accepted);
        }

        void OnDisable()
        {

            EventHandler.UnSubscribe(EventId.EVENT_ON_ORDER_ACCEPTED, On_Order_Accepted);
        }


        void Start()
        {
            onScreenTouchInputPrefabInstance = Instantiate(onScreenTouchInputPrefab, rootCanvas.transform);
        }
        #endregion

        #region PublicMethods
        public void OnClickOrdersButton()
        {
            if (onScreenTouchInputPrefabInstance != null)
                Destroy(onScreenTouchInputPrefabInstance);

            ordersButton.SetActive(false);
            orderManagementPrefabInstance = Instantiate(ordersManagementPrefab, rootCanvas.transform);
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners
        private void On_Order_Accepted(object args)
        {
            if (orderManagementPrefabInstance != null)
                Destroy(orderManagementPrefabInstance);

            onScreenTouchInputPrefabInstance = Instantiate(onScreenTouchInputPrefab, rootCanvas.transform);
        }
        #endregion
    }
}
