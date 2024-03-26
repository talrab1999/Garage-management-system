using System;
using Ex03GarageLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03ConsoleUI
{
    public class UIConsole
    {
        public void PrintMenu()
        {
            Console.WriteLine("WELCOME TO GARAGE MANAGER!!!");
            Console.WriteLine("Select the action you want from the next: ");
            Console.WriteLine("1. Put a new vehicle in the garage.");
            Console.WriteLine("2. View the list of licence numbers of the vehicles in the garage");
            Console.WriteLine("3. Update the vehicle status in the garage.");
            Console.WriteLine("4. Inflating the wheels to maximum air pressure capacity.");
            Console.WriteLine("5. Vehicle refueling.");
            Console.WriteLine("6. Electric vehicle charging.");
            Console.WriteLine("7. Show complete vehicle data by license number.");
            Console.WriteLine("8. Exit");
        }

        public void PrintList<T>(List<T> i_List)
        {
            foreach(T data in i_List)
            {
                Console.WriteLine(data);
            }
        }

        public int GetSelectedMenuOptionFromUser()
        {
            int selectedOption = 0;
            bool isValidInput = false;

            while(!isValidInput)
            {
                PrintMenu();
                Console.WriteLine("Please enter the option number (1-8): ");
                string userInput = Console.ReadLine();
                Console.Clear();
                try
                {
                    selectedOption = int.Parse(userInput);

                    if(selectedOption >= 1 && selectedOption <= 8)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number (1-8).");
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Invalid input. The numbers are between 1 to 8");
                }
            }

            return selectedOption;
        }

        public string GetExistLicensePlateNumberFromUser(GarageManager garageManager)
        {
            string existLicenseNumber;
            do
            {
                Console.WriteLine("Enter existing license number of the vehicle:");
                existLicenseNumber = Console.ReadLine();
            } while(!garageManager.IsVehicleInGarage(existLicenseNumber));

            return existLicenseNumber;

        }

        public int GetStatusFilterFromUser()
        {
            int userSelection = 1;
            bool validSelection = false;

            while(!validSelection)
            {
                Console.WriteLine("Which vehicle would you like to get?");
                Console.WriteLine("1. All Vehicles");
                Console.WriteLine("2. Being repaired vehicles");
                Console.WriteLine("3. Fixed vehicles");
                Console.WriteLine("4. Paid for vehicles");

                string userSelectionStr = Console.ReadLine();
                Console.Clear();

                try
                {
                    userSelection = int.Parse(userSelectionStr);

                    if(userSelection >= 1 && userSelection <= 4)
                    {
                        validSelection = true;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid selection. Please enter a valid option number (1-4).");
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Invalid selection. The options are between 1 to 4.");

                }
            }

            return userSelection;
        }

        public eCarStatus GetNewStatusFromUser()
        {
            int userInput;
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter the new status of the vehicle (1 - Repair, 2 - Fixed, 3 - Paid):");
                    string input = Console.ReadLine();
                    Console.Clear();
                    userInput = int.Parse(input);

                    if(userInput >= 1 && userInput <= 3)
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Invalid input. Please enter number between 1 to 3.");
                }

            }
            eCarStatus carStatus = (eCarStatus)userInput;
            return carStatus + 1;
        }

        public eFuelType GetFuelTypeFromUser()
        {
            Console.WriteLine("Select the fuel type:");
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan95");
            Console.WriteLine("3. Octan96");
            Console.WriteLine("4. Octan98");

            int fuelTypeOption = 0;
            bool validOption = false;

            do
            {
                Console.WriteLine("Enter the number corresponding to the fuel type:");
                string userInput = Console.ReadLine();
                Console.Clear();
                try
                {
                    validOption = int.TryParse(userInput, out fuelTypeOption) && fuelTypeOption >= 1 && fuelTypeOption <= 4;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Enter number Between 1 to 4 according to the fuel type menu.");
                }
            } while(!validOption);
            eFuelType chosenFuelType = (eFuelType)fuelTypeOption;

            return chosenFuelType - 1;
        }

        public float GetFuelToAddByLitersFromUser()
        {
            float amountToFill;

            while(true)
            {
                Console.WriteLine("Enter the amount of fuel to fill:");
                string userInput = Console.ReadLine();
                Console.Clear();
                try
                {
                    amountToFill = float.Parse(userInput);
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return amountToFill;
        }

        public float GetBatteryTimeToAddFromUser(ElectricVehicle i_ElectricVehicle) 
        {
            float minutes = 0;
            float hours = 0;
            bool validInput = false;

            while(!validInput)
            {
                try
                {
                    Console.WriteLine("Enter the number of minutes to add to the battery time:");
                    string userInput = Console.ReadLine();
                    minutes = float.Parse(userInput);
                    validInput = true;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of minutes.");
                }

                hours = minutes / 60;

            }

            return hours;
        }

        public string GetLicensePlateNumberFromUser()
        {
            Console.WriteLine("Enter the license plate number:");
            string licensePlateNumber = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(licensePlateNumber))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty license plate number:");
                licensePlateNumber = Console.ReadLine();
            }

            return licensePlateNumber;
        }

        public string GetOwnerNameFromUser()
        {
            Console.WriteLine("Enter the owner's name: ");
            string ownerName = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(ownerName))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty owner name:");
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        public string GetOwnerPhoneNumberFromUser()
        {
            Console.WriteLine("Enter the owner's phone number: ");
            string ownerPhoneNumber = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(ownerPhoneNumber))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty phone number name:");
                ownerPhoneNumber = Console.ReadLine();
            }

            return ownerPhoneNumber;
        }

        public float GetRemainingBatteryTime(Vehicle i_Vehicle)
        {
            float remainingBatteryTime = 0;
            bool isValid = false;
            while(!isValid)
            {
                Console.WriteLine("Enter the remaining battery time: ");
                string input = Console.ReadLine();
                Console.Clear();
                if(float.TryParse(input, out remainingBatteryTime))
                {
                    try
                    {
                        i_Vehicle.IsValidBatteryTime(remainingBatteryTime);
                        isValid = true;
                    }
                    catch(ValueOutOfRangeException vex)
                    {
                        Console.WriteLine(vex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid battery time! Please enter a numeric value.");
                }
            }
            return remainingBatteryTime;
        }

        public float GetCurrentFuelQuantityFromUser(Vehicle i_Vehicle)
        {
            float currentFuelQuantity = 0;
            bool isValid = false;
            while(!isValid)
            {
                Console.WriteLine("Enter the current fuel quantity: ");
                string input = Console.ReadLine();
                Console.Clear();
                if(float.TryParse(input, out currentFuelQuantity))
                {
                    try
                    {
                        i_Vehicle.IsValidFuelQuantity(currentFuelQuantity);
                        isValid = true;
                    }
                    catch(ValueOutOfRangeException vex)
                    {
                        Console.WriteLine(vex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid fuel quantity! Please enter a numeric value.");
                }
            }

            return currentFuelQuantity;
        }

        public float GetEnergyPercentageFromUser()
        {
            float energyPercentage;
            while(true)
            {
                Console.WriteLine("Enter the energy percentage (numeric value between 0 and 100): ");
                string input = Console.ReadLine();
                Console.Clear();
                if(float.TryParse(input, out energyPercentage) && energyPercentage >= 0 && energyPercentage <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid energy percentage! Please enter a numeric value between 0 and 100.");
                }
            }

            return energyPercentage;
        }

        public string GetManufacturerWheelsNameFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter the manufacturer name for the wheel: ");
            string manufacturerName = Console.ReadLine();
            return manufacturerName;
        }

        public float GetCurrentAirPressureFromUser(Vehicle i_Vehicle)
        {
            float currentAirPressure = 0;
            bool isValidInput = false;

            while(!isValidInput)
            {
                Console.WriteLine("Enter the current air pressure of the wheels: ");
                string input = Console.ReadLine();
                Console.Clear();
                if(float.TryParse(input, out currentAirPressure))
                {
                    try
                    {
                        i_Vehicle.IsValidAirPressureAllWheels(currentAirPressure);
                        isValidInput = true;
                    }
                    catch(ValueOutOfRangeException vex)
                    {
                        Console.WriteLine(vex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid air pressure! Please enter a numeric value.");
                }
            }

            return currentAirPressure;
        }

        public string GetModelNameFromUser()
        {
            Console.WriteLine("Enter the model name:");
            string modeName = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(modeName))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty model name:");
                modeName = Console.ReadLine();
            }

            return modeName;
        }

        public int GetVehicleTypeFromUser(List<string> i_VehicleTypes)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose the number of the vehicle type you want to add from the following options: ");
                int optionNumber = 1;
                foreach(string vehicleType in i_VehicleTypes)
                {
                    Console.WriteLine(optionNumber + ". " + vehicleType);
                    optionNumber++;
                }
            } while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > i_VehicleTypes.Count);

            return choice;
        }
    }


}
