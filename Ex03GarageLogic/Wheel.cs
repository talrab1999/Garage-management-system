namespace Ex03GarageLogic
{
    public class Wheel
    {
        public readonly float r_MaxAirPressure;
        public float m_CurrentAirPressure { get; set; }
        public string m_ManufacturerName { get; set; }

        public Wheel(float i_MaxAirPressure)
        {
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void InitialWheel(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_ManufacturerName = i_ManufacturerName;
        }
        
        public void InflateTire(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("tire pressure", 0f, r_MaxAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public bool IsValidAirPressure(float i_AirPressure)
        {
            bool isValidAirPressure = false;
            if (i_AirPressure <= r_MaxAirPressure && i_AirPressure >= 0)
            {
                isValidAirPressure = true;
            }
            else
            {
                throw new ValueOutOfRangeException("tire pressure", 0f, r_MaxAirPressure);
            }

            return isValidAirPressure;
        }

    }
}
