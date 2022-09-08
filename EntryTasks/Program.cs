using EntryTasks.Task1;
using EntryTasks.Task2.Objects;
using EntryTasks.Task2;

namespace EntryTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Start(TaskToStart.Calculator); //Replace enum value for different tasks
        }
        static void Start(TaskToStart task)
        {
            if (task == TaskToStart.Calculator)
            {
                Calculator calculator = new Calculator();
                var first = calculator.SetFirstNumber();
                var second = calculator.SetSecondNumber();
                var result = calculator.Calculate(first, second);
                calculator.ShowResult(result);
            }
            if (task == TaskToStart.ArrayRevert)
            {
                var Girls = new string[] { "Hanna", "Katerina", "Olga", "Volga", "Alexandra" };
                Revert revert = new Revert();
                var newGirls = revert.RevertArray(Girls);
                revert.ShowResult(newGirls);
            }
            if (task == TaskToStart.Buket)
            {
                Buket buket = new Buket();
                UserInterface userInterface = new UserInterface(buket);
                userInterface.CreateBuket();
                userInterface.ShowBuketPrice();
                userInterface.ProgrammEnd();
            }
        }
    }
    public enum TaskToStart
    {
        Calculator,
        ArrayRevert,
        Buket,
    }
}