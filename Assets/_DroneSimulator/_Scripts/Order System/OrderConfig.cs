using UnityEngine;


namespace Alpha
{
    [CreateAssetMenu(fileName ="OrderConfigForSector",menuName ="OrderConfig/Create Config")]
    public class OrderConfig : ScriptableObject
    {
        #region Variables
        [Header("Distance")]
        [Range(0f,100000f)]
        public int minDistance;
        [Range(0f, 100000f)]
        public int maxDistance;

        [Space]
        [Header("Weight")]
        [Range(0f, 10000f)]
        public int minWeight;
        [Range(0f, 10000f)]
        public int maxWeight;

        [Space]
        [Header("Price")]
        [Range(0f, 100000f)]
        public int minPrice;
        [Range(0f, 100000f)]
        public int maxPrice;

        [Header("Control Curves")]
        public AnimationCurve weightCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public AnimationCurve priceCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        #endregion

    }
}
