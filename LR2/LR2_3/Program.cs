using lab1;
using lab1.Enums;
internal class Program
{

    private static void Main(string[] args)
    {
       Computer computer = new Computer();
        computer.NewUserEvent += HandleNewUserEvent;
        computer.NewUser();
        computer.ReplaceCpuEvent += HandleReplaceCpuEvent;
        computer.ReplaceCpu(TypeCpu.Intel);
        computer.SetupNewSoftEvent += HandleInstallSoftEvent;
        computer.SetupNewSoft();
        computer.ReplaceRamSizeEvent += HandleReplaceRamSizeEvent;
        computer.ReplaceRam(32);
        computer.NewUserEvent -= HandleNewUserEvent;
        computer.ReplaceCpuEvent -= HandleReplaceCpuEvent;
        computer.SetupNewSoftEvent -= HandleInstallSoftEvent;
        computer.ReplaceRamSizeEvent -= HandleReplaceRamSizeEvent;




    }

    static void HandleNewUserEvent(string message) => Console.WriteLine(message);


    static void HandleReplaceCpuEvent(string message) => Console.WriteLine(message);

    static void HandleInstallSoftEvent(string message) => Console.WriteLine(message);


    static void HandleReplaceRamSizeEvent(string message) => Console.WriteLine(message);

}
