using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alpha
{
    public class Sector : MonoBehaviour
    {
        #region Variables
        [Header("Sector Properties")]
        [SerializeField] private string sectorName;
        [SerializeField] private int sectorId;
        public List<Building> buildings = new List<Building>();
        #endregion

        #region UnityMethods

        void Awake()
        {
            buildings.Clear();
            buildings = GetComponentsInChildren<Building>().ToList<Building>();
            SetBuildingIds();
        }

        #endregion

        #region PublicMethods
        public void SetBuildingIds()
        {
            if (!Helper.CheckStringIsValid(sectorName))
                return;
            int num = 1;
            StringBuilder id;
            foreach (Building building in buildings)
            {
                id = new StringBuilder(sectorName + "_" + sectorId + ", Building_" + num);
                //string id = sectorName + "_" + sectorId + "_Building" + num;
                building.SetBuildingId(id.ToString());
                num++;
            }
        }
        #endregion

        #region PrivateMethods
        public void CheckSectorNameIsValid()
        {
            string.IsNullOrEmpty(sectorName);
        }
        #endregion

        #region GameEventListeners

        #endregion
    }
}
