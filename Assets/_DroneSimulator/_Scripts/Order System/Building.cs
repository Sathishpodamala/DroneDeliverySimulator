using UnityEngine;


namespace Alpha
{
    public class Building : MonoBehaviour
    {
        #region Variables
        [SerializeField]private Transform pick_DropPoint;
        [SerializeField] private string buildingId;

        #region Getters
        public Transform Pick_DropPoint => pick_DropPoint;
        public string BuildingID => buildingId;
        #endregion

        #endregion

        #region UnityMethods
        #endregion

        #region PublicMethods
        public void SetBuildingId(string id)
        {
            buildingId = id;
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
