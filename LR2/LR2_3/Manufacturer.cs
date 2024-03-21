
using lab1.Enums;
namespace lab1
{
    internal class Manufacturer : IManufacturer
    {
        public Mnfctrr Name {  get; set; }
        public int EmployeesCount { get; set; }
        public Country Country { get; set; }



        public Manufacturer()
        {
            Random rnd = new Random();
            Name = (Mnfctrr)rnd.Next(0, 6);

            EmployeesCount = rnd.Next(12,100);
            Country = (Country)rnd.Next(0, 4);

        }
        public Manufacturer(Mnfctrr Name,int EmployeesCount, Country Country)
        {
            this.Name = Name;

            this.EmployeesCount = EmployeesCount;
            this.Country = Country;

        }

    }
}
