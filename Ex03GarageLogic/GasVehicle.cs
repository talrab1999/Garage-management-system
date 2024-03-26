using System;

namespace Ex03GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
    public class GasVehicle: Energy
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuel;
        private float m_CurrentFuelQuantity;

        public GasVehicle(eFuelType i_GasType, float i_MaxFuel)
        {
            this.r_FuelType = i_GasType;
            this.r_MaxFuel = i_MaxFuel;
        }

        public float MaxFuel
        {
            get
            {
                return r_MaxFuel;
            }
        }

        public float CurrentFuelQuantity
        {
            get
            {
                return m_CurrentFuelQuantity;
            }
            set
            {
                m_CurrentFuelQuantity = value;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public void FillUpGas(float i_GasLitersToAdd, eFuelType i_GasType)
        {
            if (r_FuelType != i_GasType)
            {
                throw new ArgumentException("Wrong fuel Type");
            }

            if (m_CurrentFuelQuantity + i_GasLitersToAdd > r_MaxFuel)
            {
                throw new ValueOutOfRangeException("liters of fuel to add", 0f, r_MaxFuel - m_CurrentFuelQuantity);
            }

            m_CurrentFuelQuantity += i_GasLitersToAdd;
        }

    }
}
