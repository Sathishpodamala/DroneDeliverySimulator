using UnityEngine;
using PathCreation;
namespace Alpha
{
    public class RoadPathFollow : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float speed = 5f;
        private float distanceTravelled;
        #endregion

        #region UnityMethods
        void Start()
        {

        }

        void Update()
        {
            distanceTravelled += Time.deltaTime*speed;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
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