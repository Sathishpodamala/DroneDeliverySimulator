using UnityEngine;
using TMPro;

namespace Alpha
{
    public class OrderVisual : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TextMeshProUGUI weightText;
        [SerializeField] private TextMeshProUGUI priceText;
        #endregion

        #region UnityMethods
        #endregion

        #region PublicMethods
        public void Init(float weight,float price)
        {
            if(weightText && priceText)
            {
                weightText.text = weight.ToString("F0");
                priceText.text = price.ToString("F1");
            }
        }

        public void OnAccept()
        {

        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
