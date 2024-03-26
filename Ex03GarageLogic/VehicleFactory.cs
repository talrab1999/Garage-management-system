using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03GarageLogic
{

    public class VehicleFactory
    {
        private static readonly List<string> r_vehicleTypeList = new List<string>()
        {
            "Electric car", "Gas car", "Electric motorcycle" , "Gas motorcycle", "Truck"
        };

        public List<string> VehicleType
        {
            get
            {
                return r_vehicleTypeList;
            }
        }

        public Vehicle AddNewVehicle(string i_LicencePlateNumber, string i_VehicleType, string i_VehicleModel)
        {
            Vehicle resVehicle;
            bool isElectric = false;
            switch(i_VehicleType)
            {
                case "Electric car":
                    isElectric = true;
                    resVehicle = new Car(i_VehicleModel, i_LicencePlateNumber, isElectric, 33, 5, 5.2f, 0, null);
                    break;
                case "Gas car":
                    resVehicle = new Car(i_VehicleModel, i_LicencePlateNumber, isElectric, 33, 5, 0, 46f, eFuelType.Octan95);
                    break;
                case "Electric motorcycle":
                    isElectric = true;
                    resVehicle = new Motorcycle(i_VehicleModel, i_LicencePlateNumber, isElectric, 31, 2, 2.6f, 0, null);
                    break;
                case "Gas motorcycle":
                    resVehicle = new Motorcycle(i_VehicleModel, i_LicencePlateNumber, isElectric, 31, 2, 0, 6.4f, eFuelType.Octan98);
                    break;
                default:
                    resVehicle = new Truck(i_VehicleModel, i_LicencePlateNumber, isElectric, 26, 14, 0, 135f, eFuelType.Soler);
                    break;

            }

            return resVehicle;
        }

    }
}
