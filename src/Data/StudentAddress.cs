using System;

namespace Data
{
    public class StudentAddress
    {
        public StudentAddress()
        {
            Address = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            City = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            State = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            Country = "Turkey";
        }
        
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int AddressOfStudentId { get; set; }
        public Student Student { get; set; }
    }
}
