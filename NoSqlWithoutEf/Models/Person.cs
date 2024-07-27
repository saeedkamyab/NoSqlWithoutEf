namespace NoSqlWithoutEf.Models
{
    public class Person: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public string  UserName { get; set; }
        public string Password { get; set; }
        public List<PhoneNumber>PhoneNumbers { get; set; }

    }
}
