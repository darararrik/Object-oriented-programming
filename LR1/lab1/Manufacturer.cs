using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static lab1.IManufacturer;
using static lab1.Enums.manufacturer;
namespace lab1
{
    internal class Manufacturer : IManufacturer
    {
        public name_manufacturer Name {  get; set; }
        public int EmployeesCount { get; set; }
        public country Country { get; set; }
        public enum country : byte
        {
            Russia = 0,
            USA = 1,
            Kazakhstan = 2,
            China = 3

        }


        public Manufacturer()
        {
            Random rnd = new Random();
            Name = (name_manufacturer)rnd.Next(0, 6);

            EmployeesCount = rnd.Next(12,100);
            Country = (country)rnd.Next(0, 4);

        }
        public Manufacturer(name_manufacturer Name,int EmployeesCount, country Country)
        {
            this.Name = Name;

            this.EmployeesCount = EmployeesCount;
            this.Country = Country;

        }

    }
}
