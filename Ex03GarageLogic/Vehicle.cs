using System.Collections.Generic;
using System.Linq;
namespace Ex03GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlateNumber;
        private readonly bool m_IsElectric;
        private float m_EnergyPercentage;
        private int m_NumOfWheels;
        List<Wheel> m_WheelsList;
        Energy m_Energy;

        
        public Vehicle(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, float i_MaxAirPressure,
                                    int i_NumOfWheels, float i_MaxBatteryTime, float i_MaxFuelCapacity, eFuelType? i_FuelType)
        {
            this.r_ModelName = i_ModelName;
            this.r_LicensePlateNumber = i_LicenseNumber;
            this.m_IsElectric = i_IsElectric;
            this.m_NumOfWheels = i_NumOfWheels;
            m_WheelsList = new List<Wheel>(m_NumOfWheels);
            foreach(int i in Enumerable.Range(0, m_NumOfWheels))
            {
                Wheel wheel = new Wheel(i_MaxAirPressure);
                m_WheelsList.Add(wheel);
            }

            if(i_IsElectric)
            {
                m_Energy = new ElectricVehicle(i_MaxBatteryTime);
            }
            else
            {
                m_Energy = new GasVehicle((eFuelType)i_FuelType, i_MaxFuelCapacity);
            }

        }

        public abstract void SetDetailsForVehicle(string i_VehicleSpec, string i_Data);
        public abstract string GetDetailsForVehicle(string i_VehicleSpec);
        public abstract List<string> GetsUnicSpecs();

        public bool IsElectric
        {
            get
            {
                return m_IsElectric;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_WheelsList;
            }
        }

        public Wheel Wheel
        {
            get
            {
                return m_WheelsList[0];
            }
        }

        public Energy EnergyType
        {
            get
            {
                if(m_IsElectric)
                {
                    ElectricVehicle electric = m_Energy as ElectricVehicle;
                    return electric;
                }
                else
                {
                    GasVehicle gas = m_Energy as GasVehicle;
                    return gas;
                }
            }
        }

        public virtual void InitialVehicleGeneralDetails(float i_EnergyPercentage,
            string i_ManufacturerWheelsName, float i_CurrentAirPressure, float i_CurrentEnergy)
        {
            this.m_EnergyPercentage = i_EnergyPercentage;
            foreach(int i in Enumerable.Range(0, m_NumOfWheels))
            {
                m_WheelsList[i].InitialWheel(i_ManufacturerWheelsName, i_CurrentAirPressure);
            }

            if(m_IsElectric)
            {
                ElectricVehicle electric = m_Energy as ElectricVehicle;
                electric.RemainingBatteryTime = i_CurrentEnergy;
            }
            else
            {
                GasVehicle gas = m_Energy as GasVehicle;
                gas.CurrentFuelQuantity = i_CurrentEnergy;
            }

        }

        public bool IsValidFuelQuantity(float i_FuelQuantity)
        {
            bool isValidFuelQuantity = false;
            GasVehicle gas = m_Energy as GasVehicle;
            if(gas.MaxFuel >= i_FuelQuantity && i_FuelQuantity >= 0)
            {
                isValidFuelQuantity = true;
            }
            else
            {
                throw new ValueOutOfRangeException("fuel quantity", 0, gas.MaxFuel);
            }

            return isValidFuelQuantity;
        }

        public bool IsValidBatteryTime(float i_BatteryTime)
        {
            bool isValidBatteryTime = false;
            ElectricVehicle electric = m_Energy as ElectricVehicle;
            if(electric.MaxBatteryTime >= i_BatteryTime && i_BatteryTime >= 0)
            {
                isValidBatteryTime = true;
            }
            else
            {
                throw new ValueOutOfRangeException("battery time", 0, electric.MaxBatteryTime);
            }

            return isValidBatteryTime;
        }

        public bool IsValidAirPressureAllWheels(float i_AirPressure)
        {
            bool isValidAirPressure = true;
            foreach(Wheel wheel in m_WheelsList)
            {
                try
                {
                    if(!wheel.IsValidAirPressure(i_AirPressure))
                    {
                        isValidAirPressure = false;
                    }
                }
                catch(ValueOutOfRangeException vex)
                {
                    throw vex;
                }
            }
            return isValidAirPressure;
        }

        public virtual void InflateAllTires(float i_AirToAdd)
        {
            foreach(Wheel wheel in m_WheelsList)
            {
                try
                {
                    wheel.InflateTire(i_AirToAdd);
                }
                catch(ValueOutOfRangeException vex)
                {
                    throw vex;
                }
            }
        }

    }
}
