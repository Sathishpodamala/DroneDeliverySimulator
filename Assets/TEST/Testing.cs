using UnityEngine;


namespace Alpha
{
    [ExecuteInEditMode]
    public class Testing : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OrderConfig config;
        [Space(30)]

        [Range(20f,1500f)]
        public float distance;

        public float calculatedWeight;
        public float curvedWeight;

        #endregion

        #region UnityMethods


        void Update()
        {

            calculatedWeight = Helper.Remap(config.minDistance, config.maxDistance, config.minWeight, config.maxWeight, distance);
            curvedWeight = Helper.CustomRemapbasedOnCurve(config.weightCurve, config.minDistance, config.maxDistance, config.minWeight, config.maxWeight, distance);
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
