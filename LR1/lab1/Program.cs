using lab1;
using System;
using System.Linq;
using static lab1.Enums.manufacturer;
internal class Program
{

    private static void Main(string[] args)
    {
        List<Computer> computers = Computer.Generate100();

        #region Exersice 2
        var FilteredByTypeCpu = computers.Where(comp => comp.typeCPU == lab1.Enums.Type_CPU.type_cpu.Ryzen).ToList();
        foreach (var computer in FilteredByTypeCpu)
            Console.WriteLine($"Type: {computer.typeCPU}, Manufacturer: {computer.nameMnfctr}, RAM: {computer.ramSize}GB, OS: {computer.typeOS}");
        Console.WriteLine("-------------------------------------------");
        var FilteredByTypeCpuAndManufacturer = computers.Where(comp => comp.typeCPU == lab1.Enums.Type_CPU.type_cpu.Ryzen && comp.nameMnfctr == lab1.Enums.manufacturer.name_manufacturer.MSI).ToList();
        foreach (var computer in FilteredByTypeCpuAndManufacturer)
            Console.WriteLine($"Type: {computer.typeCPU}, Manufacturer: {computer.nameMnfctr}, RAM: {computer.ramSize}GB, OS: {computer.typeOS}");
        Console.WriteLine("-------------------------------------------");
        var FilteredByUsersAndRamSize = computers.Where(comp => comp.users.Count < 4 && comp.ramSize > 8).ToList();
        foreach (var computer in FilteredByUsersAndRamSize)
            Console.WriteLine($"Type: {computer.typeCPU}, Manufacturer: {computer.nameMnfctr}, RAM: {computer.ramSize}GB, OS: {computer.typeOS} Users: {computer.users.Count}");
        Console.WriteLine("-------------------------------------------");
        #endregion

        #region Exersice 3
        var SortedComputerByTypeCpu1 = computers.OrderBy(comp => comp.typeCPU).ToList();
        foreach (var computer in SortedComputerByTypeCpu1)
            Console.WriteLine($"Type CPU: {computer.typeCPU}, CPU Frequency: {computer.frqncy_cpu}");
        Console.WriteLine("-------------------------------------------");

        var SortedComputerByTypeCpuAndNameManufacturer = computers.OrderBy(comp=>comp.typeCPU).ThenBy(comp => comp.nameMnfctr).ToList();
        foreach (var computer in SortedComputerByTypeCpuAndNameManufacturer)
            Console.WriteLine($"Type CPU: {computer.typeCPU}, Manufacturer: {computer.nameMnfctr}");
        #endregion

        #region Exersice 4
        var selectedData = computers.Select(comp => new
        {
            CPUFrequency = comp.frqncy_cpu,
            RAMSize = comp.ramSize,
            InstalledSoftware = comp.installed_soft
        }).ToList();

        // Вывод результатов
        foreach (var data in selectedData)
            Console.WriteLine($"CPU Frequency: {data.CPUFrequency}, RAM Size: {data.RAMSize}, Installed Software: {string.Join(", ", data.InstalledSoftware)}");
        #endregion
        #region Exersice 5
        List<Manufacturer> manufacturers = new List<Manufacturer>
        {
            new Manufacturer( (name_manufacturer)2,120, Manufacturer.country.Russia),
            new Manufacturer( (name_manufacturer)5,34, Manufacturer.country.Kazakhstan),
            new Manufacturer( (name_manufacturer)1,73, Manufacturer.country.USA),
           new Manufacturer(  (name_manufacturer)4,73, Manufacturer.country.USA)


        };

        var innerJoinResult = computers.Join(manufacturers, 
            comp => comp.nameMnfctr,
            manuf => manuf.Name, 
            (comp, manuf) => new
            {
                ComputerName = comp.nameMnfctr,
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
