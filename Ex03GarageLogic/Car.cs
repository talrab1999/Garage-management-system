using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public enum eCarColor
    {
        White,
        Black,
        Yellow,
        Red
    }
    public enum eDoorCount
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorCount m_NumOfDoors;

        public Car(string i_ModelName, string i_LicencePlateNun, bool i_IsElectric, float i_MaxAirPressure,
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
                case "car color":
                    dataStr = m_CarColor.ToString();
                    break;
                case "doors count":
                    dataStr = m_NumOfDoors.ToString();
                    break;
            }
            return dataStr;
        }

        public override void SetDetailsForVehicle(string i_VehicleSpec, string i_Data)
        {
            switch (i_VehicleSpec)
            { 
                case "car color":
                    initialCarColor(i_Data);
                    //if(m_CarColor == (eCarColor)i_Data)
                    break;
                case "doors count":
                    initialNumOfDoors(i_Data);
                    break;
               
            }
        }

        private void initialCarColor(string i_Data)
        {
            eCarColor carColor;
            if (!Enum.TryParse(i_Data, true, out carColor) || !Enum.IsDefined(typeof(eCarColor), carColor))
            {
                throw new ArgumentException("Invalid car color! Please enter a valid color: White, Black, Yellow, Red.");
            }
            m_CarColor = carColor;
        }

        private void initialNumOfDoors(string i_Data)
        {
            int numOfDoors;
            if (!int.TryParse(i_Data, out numOfDoors) || numOfDoors < 2 || numOfDoors > 5)
            {
                throw new ArgumentException("Invalid input! Please enter a valid number of doors (between 2 and 5).");
            }
            m_NumOfDoors = (eDoorCount)numOfDoors;
        }

        public override List<string> GetsUnicSpecs()
        {
            List<string> specsList = new List<string>(); //base.GetsSpecs();
            specsList.Add("car color");
            specsList.Add("doors count");
           
            return specsList;
        }
        
    }
}
