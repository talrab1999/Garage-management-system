using System;

namespace Ex03GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private string m_Incident;
        private float m_MaxValue;
        private float m_MinValue;
        public string InCident
        {
            get { return m_Incident; }
        }
     
        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }
        public ValueOutOfRangeException( string i_Incident, float i_MinRange, float i_MaxRange) 
            : base(string.Format("ERROR, The {0} is out of range. The minimum range is {1} and maximum range is {2}", i_Incident,i_MinRange, i_MaxRange))
        {
        }
    }
}
