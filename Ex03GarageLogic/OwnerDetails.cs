namespace Ex03GarageLogic
{
    public enum eCarStatus
    {
        Repair = 2,
        Fixed = 3,
        Paid = 4
    }
    public class OwnerDetails
    {
        private string m_OwnerName = string.Empty;
        private string m_OwnerPhoneNumber = string.Empty;
        private eCarStatus m_VehicleStatus;
        Vehicle m_Vehicle;
        

        public OwnerDetails(string i_OwnerName, string i_OwnerPhoneNumber, eCarStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleStatus = i_VehicleStatus;
            this.m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public eCarStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

    }
}
