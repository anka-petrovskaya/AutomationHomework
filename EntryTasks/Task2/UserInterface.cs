using EntryTasks.Task2.Exceptions;
using EntryTasks.Task2.Objects;
using EntryTasks.Task2.Parsers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntryTasks.Task2
{
    class UserInterface
    {
        private Buket Instance { get; set; }
        public UserInterface(Buket buket)
        {
            Instance = buket;
        }
        public void CreateBuket()
        {
            string userSelection = string.Empty;
            Console.WriteLine("Please input 'Add' to create new bouquet or 'Load' to get it from file");
            userSelection = Console.ReadLine().ToLower();
            try
            {
                switch (userSelection)
                {
                    case "add":
                        AddRoses();
                        AddTulips();
                        AddViolets();
                        SelectFileFormat().WriteToFile(Instance);
                        break;
                    case "load":
                        SelectFileFormat().ReadFromFile(Instance);
                        break;
                    default: throw new InvalidOptionException("option is invalid");
                }
            }
            #region Exceptions

            catch (InvalidOptionException ex)
            {
                Console.WriteLine($"{ex.Message} please try again");
                CreateBuket();
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("Please create a file before working with it.");
                CreateBuket();
            }
            catch (SerializationException)
            {
                Console.WriteLine("Please fix your Binary file before working with it.");
                CreateBuket();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Please fix your .XML file before working with it.");
                CreateBuket();
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("Please fix your .JSON file before working with it.");
                CreateBuket();
            }
            #endregion
        }
        public void AddRoses()
        {
            Console.WriteLine("How many Roses would you like to add?");
            uint count = 0;
            try
            {
                count = Convert.ToUInt32(Console.ReadLine());
                if (count > 1000000)
                {
                    throw new Exception();
                }
                Instance.AddRoses(count);
                Console.WriteLine($"Your {count} Roses are added");
            }
            #region Exceptions
            catch (OverflowException)
            {
                Console.WriteLine("Please input a positive integer from 0 to 1,000,000.");
                AddRoses();
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input an integer.");
                AddRoses();
            }
            catch (InvalidFlowersCountException ex)
            {
                Console.WriteLine(ex.Message);
                AddRoses();
            }
            #endregion
        }
        public void AddTulips()
        {
            Console.WriteLine("How many Tulips would you like to add?");
            uint count = 0;
            try
            {
                count = Convert.ToUInt32(Console.ReadLine());
                if (count > 1000000)
                {
                    throw new Exception();
                }
                Instance.AddTulips(count);
                Console.WriteLine($"Your {count} Tulips are added");
            }
            #region Exceptions
            catch (OverflowException)
            {
                Console.WriteLine("Please input a positive integer from 0 to 1,000,000.");
                AddRoses();
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input an integer.");
                AddRoses();
            }
            catch (InvalidFlowersCountException ex)
            {
                Console.WriteLine(ex.Message);
                AddRoses();
            }
            #endregion
        }
        public void AddViolets()
        {
            Console.WriteLine("How many Violets would you like to add?");
            uint count = 0;
            try
            {
                count = Convert.ToUInt32(Console.ReadLine());
                if (count > 1000000)
                {
                    throw new Exception();
                }
                Instance.AddViolets(count);
                Console.WriteLine($"Your {count} Violets are added");
            }
            #region Exceptions
            catch (OverflowException)
            {
                Console.WriteLine("Please input a positive integer from 0 to 1,000,000.");
                AddRoses();
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input an integer.");
                AddRoses();
            }
            catch (InvalidFlowersCountException ex)
            {
                Console.WriteLine(ex.Message);
                AddRoses();
            }
            #endregion
        }
        private IWorkWithFile SelectFileFormat()
        {
            Console.WriteLine("Please select source: txt, binary, xml, json");
            string selectedFormat = Console.ReadLine().ToLower();
            try
            {
                switch (selectedFormat)
                {
                    case "txt":
                        return new FileParserTxt { };
                    case "binary":
                        return new FileParserBinary { };
                    case "xml":
                        return new FileParserXml { };
                    case "json":
                        return new FileParserJson { };
                    default:
                        throw new InvalidFormatException("Format isn't supported.");
                }
            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine($"{ex.Message}. Please try again.");
                return SelectFileFormat();
            }
        }
        public void ShowBuketPrice()
        {
            Console.WriteLine($"Your price is {Instance.GetPrice()}");
        }
        public void ProgrammEnd()
        {
            Console.WriteLine("To end the programm please click on any button!");
            Console.ReadKey();
        }
    }
}