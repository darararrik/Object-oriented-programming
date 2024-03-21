using lab1;
using lab1.Enums;
internal class Program
{

    private static void Main(string[] args)
    {
        List<Computer> computers = Computer.Generate100();

        #region Exersice 2
        var FilteredByTypeCpu = computers.Where(comp => comp.TypeCpu == TypeCpu.Ryzen).ToList();
        foreach (var computer in FilteredByTypeCpu)
            Console.WriteLine($"Type: {computer.TypeCpu}, Manufacturer: {computer.NameMnfctr}, RAM: {computer.RamSize}GB, OS: {computer.TypeOs}");
        Console.WriteLine("-------------------------------------------");
        var FilteredByTypeCpuAndManufacturer = computers.Where(comp => comp.TypeCpu == TypeCpu.Ryzen && comp.NameMnfctr == Mnfctrr.MSI).ToList();
        foreach (var computer in FilteredByTypeCpuAndManufacturer)
            Console.WriteLine($"Type: {computer.TypeCpu}, Manufacturer: {computer.NameMnfctr}, RAM: {computer.RamSize}GB, OS: {computer.TypeOs}");
        Console.WriteLine("-------------------------------------------");
        var FilteredByUsersAndRamSize = computers.Where(comp => comp.Users.Count < 4 && comp.RamSize > 8).ToList();
        foreach (var computer in FilteredByUsersAndRamSize)
            Console.WriteLine($"Type: {computer.TypeCpu}, Manufacturer: {computer.NameMnfctr}, RAM: {computer.RamSize}GB, OS: {computer.TypeOs} Users: {computer.Users.Count}");
        Console.WriteLine("-------------------------------------------");
        #endregion

        #region Exersice 3
        var SortedComputerByTypeCpu1 = computers.OrderBy(comp => comp.TypeCpu).ToList();
        foreach (var computer in SortedComputerByTypeCpu1)
            Console.WriteLine($"Type CPU: {computer.TypeCpu}, CPU Frequency: {computer.FrqncyCpu}");
        Console.WriteLine("-------------------------------------------");

        var SortedComputerByTypeCpuAndNameManufacturer = computers.OrderBy(comp=>comp.TypeCpu).ThenBy(comp => comp.NameMnfctr).ToList();
        foreach (var computer in SortedComputerByTypeCpuAndNameManufacturer)
            Console.WriteLine($"Type CPU: {computer.TypeCpu}, Manufacturer: {computer.NameMnfctr}");
        #endregion

        #region Exersice 4
        var selectedData = computers.Select(comp => new
        {
            CPUFrequency = comp.FrqncyCpu,
            RAMSize = comp.RamSize,
            InstalledSoftware = comp.InstalledSoft
        }).ToList();

        // Вывод результатов
        foreach (var data in selectedData)
            Console.WriteLine($"CPU Frequency: {data.CPUFrequency}, RAM Size: {data.RAMSize}, Installed Software: {string.Join(", ", data.InstalledSoftware)}");
        #endregion
        #region Exersice 5
        List<Manufacturer> manufacturers = new List<Manufacturer>
        {
            new Manufacturer( (Mnfctrr)2,120, Country.Russia),
            new Manufacturer( (Mnfctrr)5,34, Country.Kazakhstan),
            new Manufacturer( (Mnfctrr)1,73, Country.USA),
           new Manufacturer(  (Mnfctrr)4,73, Country.USA)


        };

        var innerJoinResult = computers.Join(manufacturers, 
            comp => comp.NameMnfctr,
            manuf => manuf.Name, 
            (comp, manuf) => new
            {
                ComputerName = comp.NameMnfctr,
                ManufacturerName = manuf.Name,
                ManufacturerCountry = manuf.Country
            }).ToList();

        foreach (var result in innerJoinResult)
            Console.WriteLine($"Computer: {result.ComputerName}, Manufacturer: {result.ManufacturerName}, Country: {result.ManufacturerCountry}");

        #endregion
        string originalString = "Пример строки с русскими буквами";

        // Вызываем расширяющий метод для удаления русских букв
        string stringWithoutRussian = originalString.RemoveRussianLetters();

        // Выводим результат на консоль
        Console.WriteLine(stringWithoutRussian);
    }
}
