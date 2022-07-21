using UnityEngine;
using TMPro;
using Alpha.Events;
namespace Alpha
{
    public class OrderVisual : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TextMeshProUGUI weightText;
        [SerializeField] private TextMeshProUGUI priceText;
        private string orderId;
        #endregion

        #region UnityMethods
        #endregion

        #region PublicMethods
        public void Init(float weight,float price,string id)
        {
            if(weightText && priceText)
            {
                weightText.text = weight.ToString("F0");
                priceText.text = price.ToString("F1");
            }

            orderId = id;
        }

        public void OnAccept()
        {
            EventHandler.BroadCast(EventId.EVENT_ON_ORDER_ACCEPTED, orderId);
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
