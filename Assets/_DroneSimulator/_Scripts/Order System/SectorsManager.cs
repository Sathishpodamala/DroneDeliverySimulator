using Unity;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Profiling;

namespace Alpha
{
    public class SectorsManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<Sector> allsectors = new List<Sector>();
        public List<Building> allBuildings = new List<Building>();
        #endregion

        #region UnityMethods
        void Awake()
        {
            LoadAllBuildingsIntoList();
        }

        #endregion

        #region PublicMethods
        public void LoadAllBuildingsIntoList()
        {
            Profiler.BeginSample("LoadAllBuildingsIntoList");
            foreach (Sector sector in allsectors)
            {
                foreach (Building building in sector.buildings)
                {
                    allBuildings.Add(building);
                }
            }
            Profiler.EndSample();
        }

        public int GetSectorsCount()
        {
            return allsectors.Count;
        }

        public int GetBuildingsCount()
        {
            return allBuildings.Count;
        }
        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}
