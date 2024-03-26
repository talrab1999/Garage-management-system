namespace Ex03GarageLogic
{
    public class ElectricVehicle: Energy
    {
        private readonly float r_MaxBatteryTime;
        private float m_RemainingBatteryTime;

        public float MaxBatteryTime
        {
            get
            {
                return r_MaxBatteryTime;
            }
        }

        public float RemainingBatteryTime
        {
            get
            {
                return m_RemainingBatteryTime;
            }
            set
            {
                m_RemainingBatteryTime = value;
            }
        }

        public ElectricVehicle(float i_MaxNatteryTime)
        {
            this.r_MaxBatteryTime = i_MaxNatteryTime;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (m_RemainingBatteryTime + i_HoursToCharge > r_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException("Battery time capacity", 0f, r_MaxBatteryTime - m_RemainingBatteryTime);
            }

            m_RemainingBatteryTime += i_HoursToCharge;
        }
    }
}
