using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportHazardousMaterial;
        private float m_EngineCapacity;

        public Truck(string i_ModelName, string i_LicencePlateNun, bool i_IsElectric, float i_MaxAirPressure,
            int i_NumOfWheels, float i_MaxBatteryTime, float i_MaxFuelCapacity, eFuelType? i_FuelType)
            : base(i_ModelName, i_LicencePlateNun, i_IsElectric, i_MaxAirPressure, i_NumOfWheels, i_MaxBatteryTime,
                  i_MaxFuelCapacity, i_FuelType)
        {

        }

        public override string GetDetailsForVehicle(string i_VehicleSpec)
        {
            string dataStr = string.Empty;
            switch (i_VehicleSpec)
            {
                case "if the truck transport hazardous material":
                    if(m_IsTransportHazardousMaterial)
                    {
                        dataStr = "YES";
                    }
                    else
                    {
                        dataStr = "NO";
                    }
                    break;
                case "engine capacity":
                    dataStr = m_EngineCapacity.ToString();
                    break;
            }
            return dataStr;
        }

        public override void SetDetailsForVehicle(string i_VehicleSpec, string i_Data)
        {
            switch (i_VehicleSpec)
            {
                case "if the truck transport hazardous material":
                    initialValidIsTransportHazardousMaterial(i_Data);
                    break;
                case "engine capacity":
                    initialEngineCapacity(i_Data);
                    break;
            }
        }

        private void initialValidIsTransportHazardousMaterial(string i_Data)
        {
            int intValue;
            if (!int.TryParse(i_Data, out intValue))
            {
                throw new FormatException("Invalid input! Please enter 0 for 'no' or 1 for 'yes'.");
            }
            else if (intValue != 0 && intValue != 1)
            {
                throw new ArgumentException("Invalid input! Please enter 0 for 'no' or 1 for 'yes'.");
            }

            bool isTransportHazardousMaterial = intValue == 1;
            m_IsTransportHazardousMaterial = isTransportHazardousMaterial;
        }

        private void initialEngineCapacity(string i_Data)
        {
            float engineCapacity;
            if (!float.TryParse(i_Data, out engineCapacity))
            {
                throw new FormatException("Invalid input! Please enter number of the engin capacity.");
            }
            if (engineCapacity < 0)
            {
                throw new ArgumentException("Invalid input! Please enter number of the engin capacity over 0.");
            }
            m_EngineCapacity = engineCapacity;
        }

        public override List<string> GetsUnicSpecs()
        {
            List<string> specsList = new List<string>(); 
            specsList.Add("if the truck transport hazardous material");
            specsList.Add("engine capacity");

            return specsList;
        }

    }
}
