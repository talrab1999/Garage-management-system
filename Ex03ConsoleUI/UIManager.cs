using System;
using System.Collections.Generic;
using System.Reflection;
using Ex03GarageLogic;

namespace Ex03ConsoleUI
{

    public class UIManager
    {
        public void RunSystemManager()
        {
            Ex03GarageLogic.GarageManager garageManager = new Ex03GarageLogic.GarageManager();
            Ex03GarageLogic.VehicleFactory factory = new Ex03GarageLogic.VehicleFactory();
            UIConsole console = new UIConsole();
            bool isExit = false;


            while(!isExit)
            {
                Console.Clear();
                int userSelectedOption = console.GetSelectedMenuOptionFromUser();

                switch(userSelectedOption)
                {
                    case 1:
                        addNewCarToTheGarage(garageManager, factory, console);
                        Console.WriteLine("A new vehicle added to the garage!");
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        int statusFilter = console.GetStatusFilterFromUser();
                        List<string> licensePlateNumberList = garageManager.GetLicenseNumbersListBySelestedStatus(statusFilter);
                        console.PrintList(licensePlateNumberList);
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        string licenseNumber = console.GetExistLicensePlateNumberFromUser(garageManager);
                        eCarStatus newStatusToUpdate = console.GetNewStatusFromUser();
                        garageManager.UpdateVehicleStatus(licenseNumber, newStatusToUpdate);
                        Console.WriteLine("The vehicle status was update!");
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        licenseNumber = console.GetExistLicensePlateNumberFromUser(garageManager);
                        Vehicle vehicleToFlate = garageManager.GetVehicleByLicenseNumber(licenseNumber);
                        vehicleToFlate.InflateAllTires(vehicleToFlate.Wheel.MaxAirPressure - vehicleToFlate.Wheel.m_CurrentAirPressure);
                        Console.WriteLine("The air pressure tire is full!");
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;

                    case 5:
                        licenseNumber = console.GetExistLicensePlateNumberFromUser(garageManager);
                        if(garageManager.IsVehicleInGarage(licenseNumber))
                        {
                            Vehicle vehicleTofillUpGas = garageManager.GetVehicleByLicenseNumber(licenseNumber);
                            bool isValidFuelDetail = false;
                            while(!isValidFuelDetail)
                            {
                                if(!vehicleTofillUpGas.IsElectric)
                                {
                                    eFuelType fuelTypeToAdd = console.GetFuelTypeFromUser();
                                    float fuelToAddByLiters = console.GetFuelToAddByLitersFromUser();
                                    GasVehicle gasVehicle = (GasVehicle)vehicleTofillUpGas.EnergyType;
                                    try
                                    {
                                        gasVehicle.FillUpGas(fuelToAddByLiters, fuelTypeToAdd);
                                        isValidFuelDetail = true;
                                        Console.WriteLine("The vehicle filled up successfully");
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error! the vehicle you choose is electric! You will be sent back to the menu.");
                                    isValidFuelDetail = true;
                                }
                            }

                        }
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 6:
                        licenseNumber = console.GetExistLicensePlateNumberFromUser(garageManager);

                        if(garageManager.IsVehicleInGarage(licenseNumber))
                        {
                            Vehicle vehicleToCharge = garageManager.GetVehicleByLicenseNumber(licenseNumber);
                            bool isValidTimeToAdd = false;
                            while(!isValidTimeToAdd)
                            {
                                if(vehicleToCharge.IsElectric)
                                {
                                    ElectricVehicle electricVehicle = (ElectricVehicle)vehicleToCharge.EnergyType;
                                    float batteryTimeToAddByHours = console.GetBatteryTimeToAddFromUser(electricVehicle);

                                    try
                                    {
                                        electricVehicle.ChargeBattery(batteryTimeToAddByHours);
                                        isValidTimeToAdd = true;
                                        Console.WriteLine("The vehicle charged up successfully");

                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Eror! the vehicle you choose is not electric! You will be sent back to the menu.");
                                    isValidTimeToAdd = true;
                                }
                            }

                        }
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 7:
                        licenseNumber = console.GetLicensePlateNumberFromUser();
                        if(garageManager.IsVehicleInGarage(licenseNumber))
                        {
                            Vehicle vehicleSpecs = garageManager.GetVehicleByLicenseNumber(licenseNumber);
                            List<string> vehicleSpecsForUser = vehicleSpecs.GetsUnicSpecs();
                            displayVehicleDataByLicenseNumber(garageManager, licenseNumber, vehicleSpecsForUser);
                        }
                        else
                        {
                            Console.WriteLine("The license number does not exist, you will be sent back to the menu.");
                        }
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadKey(true);
                        break;
                    case 8:
                        isExit = true;
                        break;
                }

            }
        }

        private void addNewCarToTheGarage(GarageManager i_GarageManager, VehicleFactory i_Factory, UIConsole i_Console)
        {
            string licensePlateNumber = i_Console.GetLicensePlateNumberFromUser();
            if(i_GarageManager.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine("Vehicle with license plate number {0} is already in the garage.", licensePlateNumber);
                i_GarageManager.UpdateVehicleStatus(licensePlateNumber, eCarStatus.Repair);

            }
            else
            {
                string ownerName = i_Console.GetOwnerNameFromUser();
                string ownerPhoneNumber = i_Console.GetOwnerPhoneNumberFromUser();
                string vehicleModel = i_Console.GetModelNameFromUser();
                Console.WriteLine("Adding a new vehicle in the garage. Vehicle number: {0}", licensePlateNumber);
                List<string> vehicleTypes = i_Factory.VehicleType;
                int numOfVehicleOnList = i_Console.GetVehicleTypeFromUser(vehicleTypes);
                Vehicle vehicle = i_Factory.AddNewVehicle(licensePlateNumber, vehicleTypes[numOfVehicleOnList - 1], vehicleModel);
                i_GarageManager.AddVehicleOwner(licensePlateNumber, ownerName, ownerPhoneNumber, vehicle);

                Console.WriteLine("Please enter the following details: ");
                List<string> vehicleSpecsForUser = vehicle.GetsUnicSpecs();
                getAndSetCommonInputForVehicleFromUser(vehicle, i_Console);
                getAndSetUnicInputForVehicleFromUser(vehicleSpecsForUser, vehicle);
            }

        }

        private void getAndSetCommonInputForVehicleFromUser(Vehicle i_Vehicle, UIConsole i_Console)
        {
            float energyPercentage = i_Console.GetEnergyPercentageFromUser();
            string manufacturerWheels = i_Console.GetManufacturerWheelsNameFromUser();
            float currentAirPressure = i_Console.GetCurrentAirPressureFromUser(i_Vehicle);
            float currentEnergyQuantity;
            if(i_Vehicle.IsElectric)
            {
                currentEnergyQuantity = i_Console.GetRemainingBatteryTime(i_Vehicle);
            }
            else
            {
                currentEnergyQuantity = i_Console.GetCurrentFuelQuantityFromUser(i_Vehicle);
            }
            i_Vehicle.InitialVehicleGeneralDetails(energyPercentage, manufacturerWheels, currentAirPressure, currentEnergyQuantity);

        }

        private void getAndSetUnicInputForVehicleFromUser(List<string> i_UnicVehicleSpecsForUser, Vehicle i_Vehicle)
        {
            foreach(string unicVehicleSpec in i_UnicVehicleSpecsForUser)
            {
                bool isValidInput = false;
                while(!isValidInput)
                {
                    Console.WriteLine("Enter {0}", unicVehicleSpec);
                    string userInput = Console.ReadLine();
                    try
                    {
                        i_Vehicle.SetDetailsForVehicle(unicVehicleSpec, userInput);
                        isValidInput = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                Console.Clear();
            }
        }

        private void displayVehicleDataByLicenseNumber(GarageManager i_Manager, string i_LicenseNumber, List<string> i_UnicVehicleSpecsForUser)
        {
            if(i_Manager.VehicleOwnersDict.TryGetValue(i_LicenseNumber, out OwnerDetails ownerDetails))
            {
                Vehicle vehicle = ownerDetails.Vehicle;

                Console.WriteLine("License Number: " + i_LicenseNumber);
                Console.WriteLine("Model Name: " + vehicle.ModelName);
                Console.WriteLine("Owner's Name: " + ownerDetails.OwnerName);
                Console.WriteLine("Car Status: " + ownerDetails.VehicleStatus);

                foreach(string unicVehicleSpec in i_UnicVehicleSpecsForUser)
                {
                    string resOfData = string.Empty;
                    resOfData = vehicle.GetDetailsForVehicle(unicVehicleSpec);
                    Console.WriteLine("The {0} : {1}", unicVehicleSpec, resOfData);
                }
                int numOfWheel = 0;
                foreach(Wheel wheel in vehicle.Wheels)
                {
                    numOfWheel++;
                    Console.WriteLine("Wheel {0} Manufacturer: {1} ", numOfWheel, wheel.m_ManufacturerName);
                    Console.WriteLine("Wheel {0} Air Pressure:{1} ", numOfWheel, wheel.m_CurrentAirPressure);
                }

                if(vehicle.EnergyType is GasVehicle gas)
                {
                    Console.WriteLine("Fuel Type: " + gas.FuelType);
                    Console.WriteLine("Fuel quantity: " + gas.CurrentFuelQuantity);
                }
                else if(vehicle.EnergyType is ElectricVehicle electric)
                {
                    Console.WriteLine("Remining battery time: " + electric.RemainingBatteryTime);
                }
            }
            else
            {
                Console.WriteLine("Vehicle with license number " + i_LicenseNumber + " does not exist in the garage.");
            }
        }

    }
}

