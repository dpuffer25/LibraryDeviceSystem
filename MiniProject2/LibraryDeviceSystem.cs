// Dalyno Puffer CIS 340 Mini Project 2 4:30PM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2
{
    class LibraryDeviceSystem
    {
        // Device object array

        private Device[] device;
        private int deviceCount;

        // Main

        static void Main(string[] args)
        {
            // Load LibrarySystem

            LibraryDeviceSystem Load = new LibraryDeviceSystem();
            Load.LoadLibrarySystem();
        }
        
        // Constructor for the Library Device System

        public LibraryDeviceSystem()
        {
            // initalize array and allocate 50 elements
            // Create 5 device objects

            device = new Device[50];
            Device exDevice1 = new Device();
            Device exDevice2 = new Device();
            Device exDevice3 = new Device();
            Device exDevice4 = new Device();
            Device exDevice5 = new Device();

            // tore the objects in the device array
            // deviceCount increments

            device[deviceCount] = exDevice1;
            deviceCount++;
            device[deviceCount] = exDevice2;
            deviceCount++;
            device[deviceCount] = exDevice3;
            deviceCount++;
            device[deviceCount] = exDevice4;
            deviceCount++;
            device[deviceCount] = exDevice5;
            deviceCount++;

            // Specific hardcoded properties
            // SKU, Name, Availability

            exDevice1.SKU = "6757A";
            exDevice1.Name = "Apple 9.7-inch iPad Pro";
            exDevice1.Avail = "Available";
            exDevice2.SKU = "93P51B";
            exDevice2.Name = "Amazon Kindle Fire Kids Edition";
            exDevice2.Avail = "Available";
            exDevice3.SKU = "10NBC";
            exDevice3.Name = "LeapFrog Epic Learning Tablet";
            exDevice3.Avail = "Available";
            exDevice4.SKU = "85U20";
            exDevice4.Name = "Amazon Kindle Fire HD 8";
            exDevice4.Avail = "Checked Out";
            exDevice5.SKU = "91H2D";
            exDevice5.Name = "HP Envy 8 Note";
            exDevice5.Avail = "Available";

        }

        // Library System Main Menu

        private void LoadLibrarySystem()
        {

            // string choice for menu options

            string choice = "";

            // do loop for specific menu options
            
            do
            {
                Console.Clear();
                MainHeader("\t\t\t Library Device Checkout System \n");

                Console.WriteLine("1. List Devices by Title");
                Console.WriteLine("2. Add New Devices");
                Console.WriteLine("3. Edit Device Information");
                Console.WriteLine("4. Search by Device Name");
                Console.WriteLine("5. Check Out Devices");
                Console.WriteLine("6. Check In Devices");
                Console.WriteLine("7. Exit");

                // prompts user to select a option and stores it

                Console.Write("\n\nSelect menu options 1-7: ");
                choice = Console.ReadLine();

                // switch loop based off the choice of the user
                // runs methods based off the user choice

                switch (choice)
                {
                    case "1":
                        DisplayDeviceByTitle();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        AddDevice();
                        break;
                    case "3":
                        EditDeviceInformation();
                        break;
                    case "4":
                        SearchDevice();
                        break;
                    case "5":
                        CheckOutDevice();
                        break;
                    case "6":
                        CheckInDevice();
                        break;                    
                }

                // close console when specfic string is inputed

            } while (choice != "7");

        }

        // Add device method

        private void AddDevice()
        {

            MainHeader("\t\t\t Library Device Checkout System - Add New Device \n");

            // Propmpts user to enter SKU & name
            // Stores input

            Console.Write("SKU: ");
            string sku = Console.ReadLine().ToUpper();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            // Availability set when new device is created

            string avail = "Available";
            Device tmpDevice = new Device(sku, name, avail);

            // device is to the device array

            device[deviceCount] = tmpDevice;
            deviceCount++;

            // Created device is added to the catalog

            Console.WriteLine("\nAdded {0} to Catalog.", tmpDevice.Name);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        // Main Header used for different menu options

        private void MainHeader(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
        }

        // Header used to list #/SKU/Name

        private void SecondHeader()
        {
            Console.WriteLine("\n{0} {1,5} {2,25}", "#", "SKU", "Name");
        }

        // Display Device method

        private void DisplayDeviceByTitle()
        {
            MainHeader("\t\t\t Library Device Checkout System - List \n");

            SecondHeader();

            // for loop used to display all devices in the device array

            for (int i = 0; i < deviceCount; i++)
            {
                String output = String.Format("{0}. {1,5} {2,35} {3,55}", i + 1, device[i].SKU, device[i].Name, device[i].Avail);
                Console.WriteLine(output);
            }
        }

        // Edit Device Information method

        private void EditDeviceInformation()
        {
            Console.Clear();
            DisplayDeviceByTitle();
            bool repeatChoice = false;

            // do loop
            do
            {
                // try statement used to see if it works correctly
                // if not console writes input must be generic 
                // runs do loop again

                try
                {
                    // prompts user to enter device number they want to edit
                    // converts and stores it

                    Console.Write("\nEnter Device number to edit <1-6>: ");
                    int choice = 0;
                    choice = Convert.ToInt32(Console.ReadLine());

                    // if loop runs if choice is less than deviceCount
                    // if not then prompts invalid number
                    
                    if (choice <= deviceCount)
                    {
                        Console.Write("SKU: ");
                        device[choice - 1].SKU = Console.ReadLine().ToUpper();

                        Console.Write("Name: ");
                        device[choice - 1].Name = Console.ReadLine();

                        Console.WriteLine("\nDevice information updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number");
                    }
                    repeatChoice = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInput must be numeric. Try again");
                    repeatChoice = true;
                }

            } while (repeatChoice == true);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

        }

        // Search device method

        private void SearchDevice()
        {
            Console.Clear();
            MainHeader("\t\t\t Library Device Checkout System - Search\n");

            string deviceName = "";

            // prompts user to enter device they are looking for 
            // stores input

            Console.Write("Enter Device to search for: ");
            deviceName = Console.ReadLine().ToUpper();

            Console.WriteLine("\n Listings for '{0}'", deviceName);


            SecondHeader();

            // runs for loop to determine if a device (.Contains) the string of the previously inputed variable
            // if so then the console list the device with the containing character strings

            for (int i = 0; i < deviceCount; i++)
            {
                string lookUp = device[i].Name.ToUpper();
                if (lookUp.Contains(deviceName))
                {
                    Console.WriteLine("{0}. {1,5} {2,35}", i + 1, device[i].SKU, device[i].Name);
                }

            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
            
            
        }
        
        // CheckOut Device method

        private void CheckOutDevice()
        {
            Console.Clear();
            MainHeader("\t\t\t Library Device Checkout System - Check Out Devices");

            Console.WriteLine("\n Available Devices");

            SecondHeader();

            // for loop used to display all the "Available" devices in the deviceCount

            for (int i = 0; i < deviceCount; i++)
            {
                // if available display the devices

                if (device[i].Avail == "Available")
                {
                    Console.WriteLine("{0}. {1,5} {2,35}", i + 1, device[i].SKU, device[i].Name);
                }
            }

            // prompts user to enter device number
            // converts and stores it

            Console.Write("\nEnter device number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            // if statement used to determine if choice is greater than deviceCount
            // else if used to determine if devices is already checked out or not
            // If it is Available, change the availability to checked out

            if (choice > deviceCount)
            {
                Console.WriteLine("Invalid Number.");
            }
            else if (device[choice - 1].Avail == "Checked Out")
            {
                Console.WriteLine("This deivce is already checked out.");
            }
            else if (device[choice - 1].Avail == "Available")
            {
                device[choice - 1].Avail = "Checked Out";
                Console.WriteLine("Device Checked Out.");
            }


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        // CheckInDevice method
        private void CheckInDevice()
        {
            Console.Clear();
            MainHeader("\t\t\t Library Device Checkout System - Check In Devices");

            Console.WriteLine("\n Checked Out Devices");

            SecondHeader();

            // For loop used to display all "Checked Out Devices"
            for (int i = 0; i < deviceCount; i++)
            {
                // if devices is checked out display it
                if (device[i].Avail == "Checked Out")
                {
                    Console.WriteLine("{0}. {1,5} {2,35}", i + 1, device[i].SKU, device[i].Name);
                }
            }

            // prompts user to enter device number
            // converts and stores it
            Console.Write("\nEnter device number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            // if statement used to determine if choice is greater than deviceCount
            // else if used to determine if devices is Available or not
            // If it is Checked Out, change the availability to Available
            if (choice > deviceCount)
            {
                Console.WriteLine("Invalid Number.");
            }
            else if (device[choice - 1].Avail == "Available")
            {
                Console.WriteLine("This deivce is not checked out.");
            }
            else if (device[choice - 1].Avail == "Checked Out")
            {
                device[choice - 1].Avail = "Available";
                Console.WriteLine("Device Checked In.");
            }


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
