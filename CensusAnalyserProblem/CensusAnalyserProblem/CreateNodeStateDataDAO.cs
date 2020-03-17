// --------------------------------------------------------------------------------------------------------------------
// <copyright file=DAOClass.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ---------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserProblem
{
    using System;

    /// <summary>
    /// Class StateCensusData Implements IComparable.<>.
    /// </summary>
    public class StateCensusDataDAO
    {
        /// <summary>
        /// statename.
        /// </summary>
        public string stateName;

        /// <summary>
        /// population.
        /// </summary>
        public int population;

        /// <summary>
        /// area in sq km.
        /// </summary>
        public int areaInSqKm;

        /// <summary>
        /// density per sq km.
        /// </summary>
        public int densityPerSqKm;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusDataDAO"/> class.
        /// </summary>
        public StateCensusDataDAO()
        {
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>StateCensusDataDAO.</returns>
        public static StateCensusDataDAO CreateNode(string element)
        {
            StateCensusDataDAO newnode = null;
            try
            {
                if (element.Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
                {
                    return null;
                }

                newnode = new StateCensusDataDAO();
                string[] arr = element.Split(",");

                newnode.stateName = arr[0];
                newnode.population = Convert.ToInt32(arr[1]);
                if (arr[2] != null)
                {
                    newnode.areaInSqKm = Convert.ToInt32(arr[2]);
                }

                if (arr[3] != null)
                {
                    newnode.densityPerSqKm = Convert.ToInt32(arr[3]);
                }

                return newnode;
            }
            catch (Exception)
            {
                return newnode;
            }
        }
    }

    /// <summary>
    /// Modal class for CSVStateCode file.
    /// </summary>
    public class StateCodeDataDAO
    {
        /// <summary>
        /// The serial no.
        /// </summary>
        public int serialNo;

        /// <summary>
        /// The state name.
        /// </summary>
        public string stateName;

        /// <summary>
        /// The tin.
        /// </summary>
        public int tIN;

        /// <summary>
        /// state code.
        /// </summary>
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCodeDataDAO"/> class.
        /// </summary>
        public StateCodeDataDAO()
        {
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>StateCodeDataDAO.</returns>
        public static StateCodeDataDAO CreateNode(string element)
        {
            StateCodeDataDAO newnode = null;
            try
            {
                if (element.Equals("SrNo,State,Name,TIN,StateCode,"))
                {
                    return null;
                }

                newnode = new StateCodeDataDAO();
                string[] arr = element.Split(",");
                newnode.serialNo = Convert.ToInt32(arr[0]);
                newnode.stateName = arr[1];
                newnode.tIN = Convert.ToInt32(arr[2]);
                newnode.stateCode = arr[3];
                return newnode;
            }
            catch (Exception)
            {
                return newnode;
            }
        }
    }
}
