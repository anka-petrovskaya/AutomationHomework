using EntryTasks.Task2.Objects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EntryTasks.Task2.Parsers
{
    class FileParserBinary : IWorkWithFile
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string binaryFilePath = @"..\..\..\FilesExtensions\File.dat";

        public void WriteToFile(Buket bouquet)
        {
            using (FileStream fs = new FileStream(binaryFilePath, FileMode.Create))
            {
                formatter.Serialize(fs, bouquet);
            }
        }
        public void ReadFromFile(Buket buket)
        {
            using (FileStream fs = new FileStream(binaryFilePath, FileMode.Open))
            {
                var flowers = formatter.Deserialize(fs) as Buket;
                foreach (var flower in flowers)
                {
                    buket.AddFlower(flower.Name);
                }
            }
        }
    }
}