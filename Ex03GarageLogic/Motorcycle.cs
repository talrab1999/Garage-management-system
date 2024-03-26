using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public enum eLicenceType
    {
        A1,
        A2,
        AA,
        B1
    }
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineVolumeCc;

        public Motorcycle(string i_ModelName, string i_LicencePlateNun, bool i_IsElectric, float i_MaxAirPressure,
            int i_NumOfWheels, float i_MaxBatteryTime, float i_MaxFuelCapacity, eFuelType? i_FuelType)
            : base(i_ModelName, i_LicencePlateNun, i_IsElectric, i_MaxAirPressure, i_NumOfWheels, i_MaxBatteryTime,
                  i_MaxFuelCapacity, i_FuelType)
        { }

        public override string GetDetailsForVehicle(string i_VehicleSpec)
        {
            string dataStr = string.Empty;
            switch (i_VehicleSpec)
            {
                case "licence type":
                    dataStr = m_LicenceType.ToString();
                    break;
                case "engine volume in cc":
                    dataStr = m_EngineVolumeCc.ToString();
                    break;
            }
            return dataStr;
        }

        public override void SetDetailsForVehicle(string i_VehicleSpec, string i_Data)
        {
            switch (i_VehicleSpec)
            {
                case "licence type":
                    initialValidLicenceType(i_Data);
                    break;
                case "engine volume in cc":
                    initialValidEngineVolumeCc(i_Data);
                    break;
            }
        }

        private void initialValidLicenceType(string i_Data)
        {
            eLicenceType licenceType;
            if (!Enum.TryParse(i_Data, true, out licenceType) || !Enum.IsDefined(typeof(eLicenceType), licenceType))
            {
                throw new ArgumentException("Invalid licence type! Please enter again: A1 or A2 or AA or B1.");
            }
            m_LicenceType = licenceType;
        }

        private void initialValidEngineVolumeCc(string i_Data)
        {
            int engineVolumeCc;
            if (!int.TryParse(i_Data, out engineVolumeCc))
            {
                throw new FormatException("Invalid input! Please enter number for the engin volume in cc.");
            }
            if (engineVolumeCc < 0)
            {
                throw new ArgumentException("Invalid input! Please enter number for the engin volume in cc over 0.");
            }
            m_EngineVolumeCc = engineVolumeCc;
        }

        public override List<string> GetsUnicSpecs()
        {
            List<string> specsList = new List<string>(); 
            specsList.Add("licence type");
            specsList.Add("engine volume in cc");

            return specsList;
        }

    }
}
