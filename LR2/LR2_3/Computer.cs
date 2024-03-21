using lab1.Enums;

namespace lab1
{
    
    internal class Computer : IComputer, IOverclock
    {
        #region delegates
        public delegate void NewUserHandler(string message);
        public delegate void ReplaceCpuHandler(string message);
        public delegate void SetupNewSoftHandler(string message);
        public delegate void ReplaceRamSizeHandler(string message);

        private NewUserHandler? newUserHandler;
        private ReplaceCpuHandler? replaceCpuHandler;
        private SetupNewSoftHandler? setupNewSoftHandler;
        private ReplaceRamSizeHandler? replaceRamSizeHandler;
        #endregion
        #region Events
        public event NewUserHandler NewUserEvent
        {
            add
            {
                newUserHandler += value;
                Console.WriteLine($"Добавлен обработчик нового пользователя: {value.Method.Name}");
            }
            remove
            {
                newUserHandler -= value;
                Console.WriteLine($"Удален обработчик нового пользователя: {value.Method.Name}");
            }
        }
        public event ReplaceCpuHandler ReplaceCpuEvent
        {
            add
            {
                replaceCpuHandler += value;
                Console.WriteLine($"Добавлен обработчик нового процессора: {value.Method.Name}");
            }
            remove
            {
                replaceCpuHandler -= value;
                Console.WriteLine($"Удален обработчик нового процессора: {value.Method.Name}");
            }
        }
        public event SetupNewSoftHandler SetupNewSoftEvent
        {
            add
            {
                setupNewSoftHandler += value;
                Console.WriteLine($"Добавлен обработчик нового ПО: {value.Method.Name}");
            }
            remove
            {
                setupNewSoftHandler -= value;
                Console.WriteLine($"Удален обработчик нового ПО: {value.Method.Name}");
            }
        }
        public event ReplaceRamSizeHandler ReplaceRamSizeEvent
        {
            add
            {
                replaceRamSizeHandler += value;
                Console.WriteLine($"Добавлен обработчик замены ОЗУ: {value.Method.Name}");
            }
            remove
            {
                replaceRamSizeHandler -= value;
                Console.WriteLine($"Удален обработчик замены ОЗУ: {value.Method.Name}");
            }
        }
        #endregion
        #region variables
        private bool _isOverclocked = false;
        private int _cpuF;
        private int _ramSize;
        private TypeOs _typeOS;
        private TypeCpu _typeCPU;
        private Enums.Mnfctrr _nameMnfctr;
        public List<string> InstalledSoft { get; set; }
        public List<string> Users { get; set; }


        #endregion
        #region GetsSets
        public TypeCpu TypeCpu
        {
            get => _typeCPU;
            set { _typeCPU = value; }
        }
        public Enums.Mnfctrr NameMnfctr
        {
            get => _nameMnfctr;
            set { _nameMnfctr = value; }
        }
      
        public TypeOs TypeOs
        {
            get => _typeOS;
            set { _typeOS = value; }
        }

        public int FrqncyCpu
        {
            get => _cpuF;
            set { _cpuF = value; }
        }
        public int RamSize
        {
            get => _ramSize;
            set { _ramSize = value; }
        }
        #endregion
        #region constructors
        public Computer()
        {
            Random rnd = new Random();
            _typeCPU = (TypeCpu)rnd.Next(0, 2);
            _cpuF = rnd.Next(3, 6);
            int randnomNumber = rnd.Next(1, 5);

            _ramSize = randnomNumber*8;
            _typeOS = (TypeOs)rnd.Next(0, 3);


            _nameMnfctr = (Enums.Mnfctrr)rnd.Next(0, 6);

            InstalledSoft = new List<string>();
            Users = new List<string>();
            int numberOfUsers = rnd.Next(0, 11);
            for (int i = 0;i < numberOfUsers;i++)
            {
                Users.Add($"User {i+1}");
                InstalledSoft.Add($"Software {i+1}");
            }
        }
        public Computer(TypeCpu typeCPU, int cpuF, int ramSize, TypeOs type_OS, Enums.Mnfctrr name_Manufacturer, List<string> users, List<string> installedSoft)
        {
            _typeCPU = typeCPU;
            _cpuF = cpuF;
            _ramSize = ramSize;
            _typeOS = type_OS;
            _nameMnfctr = name_Manufacturer;
            this.Users = users;
            InstalledSoft = installedSoft;

        }
        #endregion
        #region Methods
        public void NewUser()
        {
            Users.Add($"User {Users.Count + 1}");
            newUserHandler?.Invoke("Добавлен новый пользователь.");
        }
        public void ReplaceCpu(TypeCpu newCpu)
        {
            TypeCpu oldCpu = _typeCPU;
            _typeCPU = newCpu;
            replaceCpuHandler?.Invoke($"Процессор был заменен с {oldCpu} на {newCpu}.");
        }
        public void SetupNewSoft()
        {
            InstalledSoft.Add($"Software {InstalledSoft.Count + 1} ");
            setupNewSoftHandler?.Invoke($"Было установлено новое ПО");

        }
        public void ReplaceRam(int newRamSize) 
        { 
            int oldRamSize = _ramSize;
            _ramSize = newRamSize;
            replaceRamSizeHandler?.Invoke($"Опертивная память была заменена с {oldRamSize} на {newRamSize}");
        }
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
                if (_typeCPU == TypeCpu.Intel)
                {
                    _cpuF += 1;


                }
                else if (_typeCPU == TypeCpu.Ryzen)
                {
                    _cpuF += 1;
                }
                _isOverclocked = true;
                return "cpu overcloked";
            }
            else return "cpu byl ";
            

        }
        #endregion

    }
}

