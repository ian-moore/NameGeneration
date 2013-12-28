using System;

namespace NameGeneration
{
    public class FullName
    {
        public NameGender Gender { get; set; }
        public String First { get; set; }
        public String Last { get; set; }
        public String Full
        {
            get
            {
                return String.Format("{0} {1}", First, Last);
            }
        }
    }
}
