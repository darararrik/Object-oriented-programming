using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static lab1.Enums.manufacturer;
using static lab1.Enums.Type_CPU;
using static lab1.Enums.Type_OS;

namespace lab1
{
    internal class Computer : IComputer, IOverclock
    {
        #region variables
        private bool _isOverclocked = false;
        private int _cpuF;
        private int _ramSize;
        private type_OS _typeOS;
        private type_cpu _typeCPU;
        private name_manufacturer _nameMnfctr;
        public List<string> installed_soft { get; set; }
        public List<string> users { get; set; }


        #endregion
        public type_cpu typeCPU
        {
            get => _typeCPU;
            set { _typeCPU = value; }
        }
        public name_manufacturer nameMnfctr
        {
            get => _nameMnfctr;
            set { _nameMnfctr = value; }
        }
      
        public type_OS typeOS
        {
            get => _typeOS;
            set { _typeOS = value; }
        }

        public int frqncy_cpu
        {
            get => _cpuF;
            set { _cpuF = value; }
        }
        public int ramSize
        {
            get => _ramSize;
            set { _ramSize = value; }
        }
        #region constructors
        public Computer()
        {
            Random rnd = new Random();
            _typeCPU = (type_cpu)rnd.Next(0, 2);
            _cpuF = rnd.Next(3, 6);
            int randnomNumber = rnd.Next(1, 5);

            _ramSize = randnomNumber*8;
            _typeOS = (type_OS)rnd.Next(0, 3);


            _nameMnfctr = (name_manufacturer)rnd.Next(0, 6);

            installed_soft = new List<string>();
            users = new List<string>();
            int numberOfUsers = rnd.Next(0, 11);
            for (int i = 0;i < numberOfUsers;i++)
            {
                users.Add($"User {i+1}");
                installed_soft.Add($"Software {i+1}");
            }
        }
        public Computer(type_cpu typeCPU, int cpuF, int ramSize, type_OS type_OS, name_manufacturer name_Manufacturer, List<string> users, List<string> installedSoft)
        {
            _typeCPU = typeCPU;
            _cpuF = cpuF;
            _ramSize = ramSize;
            _typeOS = type_OS;
            _nameMnfctr = name_Manufacturer;
            this.users = users;
            installed_soft = installedSoft;

        }
        #endregion
        public static Computer GenerateComputer() => new Computer();
        public static List<Computer> Generate100()
        {
            List<Computer> computers = new List<Computer>();
            for (int i = 0; i < 100; i++)
            {
                computers.Add(GenerateComputer());
            }
            return computers;
        }


      
       

      

        public string OverclockTheComputer()
        {
            if (_isOverclocked == false)
            {
                if (_typeCPU == type_cpu.Intel)
                {
                    _cpuF += 1;


                }
                else if (_typeCPU == type_cpu.Ryzen)
                {
                    _cpuF += 1;
                }
                _isOverclocked = true;
                return "cpu overcloked";
            }
            else return "cpu byl ";
            

        }

    }
}

