using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, OwnerDetails> m_VehicleOwnersDict;

        public GarageManager()
        {
            m_VehicleOwnersDict = new Dictionary<string, OwnerDetails>();
        }

        public Vehicle GetVehicleByLicenseNumber(string licenseNumber)
        { 
           OwnerDetails ownerDetails = m_VehicleOwnersDict[licenseNumber];
           return ownerDetails.Vehicle;
        }

        public void UpdateVehicleStatus(string licenseNumber, eCarStatus newStatus)
        {
            if (m_VehicleOwnersDict.ContainsKey(licenseNumber))
            {
                OwnerDetails ownerDetails = m_VehicleOwnersDict[licenseNumber];
                ownerDetails.VehicleStatus = newStatus;
            }
        }

        public Dictionary<string, OwnerDetails> VehicleOwnersDict
        {
            get
            {
                return m_VehicleOwnersDict;
            }
            set
            {
                m_VehicleOwnersDict = value;
            }
        }

        public List<string> GetLicenseNumbersListBySelestedStatus(int i_SelectedStatus)
        {
            List<string> licencePlateNumberList = new List<string>();
            if(i_SelectedStatus == 1)
            {
                foreach (KeyValuePair<string, OwnerDetails> kvp in m_VehicleOwnersDict)
                { 
                    licencePlateNumberList.Add(kvp.Key);
                }
            }
            else
            {
                eCarStatus carStatus = (eCarStatus)i_SelectedStatus;
                foreach (KeyValuePair<string, OwnerDetails> kvp in m_VehicleOwnersDict)
                {
                    if (kvp.Value.VehicleStatus == carStatus)
                    {
                        licencePlateNumberList.Add(kvp.Key);
                    }
                }
            }

            return licencePlateNumberList;
        } 

        public void AddVehicleOwner(string i_LicensePlateNumber, string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            OwnerDetails ownerDetails = new OwnerDetails(i_OwnerName, i_OwnerPhoneNumber, eCarStatus.Repair, i_Vehicle);

            m_VehicleOwnersDict.Add(i_LicensePlateNumber, ownerDetails);
        }

        public bool IsVehicleInGarage(string i_LicensePlateNumber)
        {
            return m_VehicleOwnersDict.ContainsKey(i_LicensePlateNumber);
        }

    }
    
}
