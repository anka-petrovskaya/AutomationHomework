using EntryTasks.Task2.Objects;

namespace EntryTasks.Task2
{
    public interface IWorkWithFile
    {
        void WriteToFile(Buket flowers);
        void ReadFromFile(Buket flowers);
    }
}