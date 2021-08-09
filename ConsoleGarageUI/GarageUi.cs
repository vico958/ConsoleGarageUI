﻿namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ex03.GarageLogic;

    public class GarageUi
    {
        private readonly string r_KeyToExitToMenu = "Q";
        private Garage m_Garage = new Garage();
        private eGarageMenu m_GarageMenu;

        public enum eGarageMenu
        {
            AddNewVehicle = 1,
            PrintVehicleLicenseList,
            ChangeVehicleStausInGarge,
            FillingAirInWheelsToMaximum,
            RefulVehicle,
            ChargeVehicle,
            FullInformationOfVehicleInGarage,
            ExitFromGarageProgram,
        }

        public void RunningTheGarageSystem()
        {
            bool isExitFromGarageProgram = false;
            int userChoiseNumberInMenu;

            while(isExitFromGarageProgram == false)
            {
                userChoiseNumberInMenu = gettingUserMenuChoose();
                m_GarageMenu = (eGarageMenu)userChoiseNumberInMenu;
                Console.Clear();
                switch(m_GarageMenu)
                {
                    case eGarageMenu.AddNewVehicle:
                        {
                            addVehicleToGarage();
                            break;
                        }

                    case eGarageMenu.PrintVehicleLicenseList:
                        {
                            gettingAndPrintVehicleLicenseList();
                            break;
                        }

                    case eGarageMenu.ChangeVehicleStausInGarge:
                        {
                            changeVehicleStatusInGarge();
                            break;
                        }

                    case eGarageMenu.FillingAirInWheelsToMaximum:
                        {
                            fillingAirInWheelsToMaximum();
                            break;
                        }

                    case eGarageMenu.RefulVehicle:
                        {
                            refulVehicle();
                            break;
                        }

                    case eGarageMenu.ChargeVehicle:
                        {
                            chargeVehicle();
                            break;
                        }

                    case eGarageMenu.FullInformationOfVehicleInGarage:
                        {
                            fullInformationOfVehicleInGarage();
                            break;
                        }

                    case eGarageMenu.ExitFromGarageProgram:
                        {
                            isExitFromGarageProgram = true;
                            break;
                        }
                }
            }
        }

        private void fullInformationOfVehicleInGarage()
        {
            string licenseNumber, fullInformationOfVehicle;
            bool isFullInformationRecived = false;
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";
            string keyToReturnToMenu = null;

            while((isFullInformationRecived == false) && (keyToReturnToMenu != r_KeyToExitToMenu))
            {
                try
                {
                    licenseNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
                    fullInformationOfVehicle = m_Garage.GettingFullInformationOfVehicleInGarage(licenseNumber);
                    Console.WriteLine(fullInformationOfVehicle);
                    isFullInformationRecived = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    keyToReturnToMenu = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
            }
        }

        private void chargeVehicle()
        {
            string licenseNumber, userInput = null;
            float amountToCharge;
            bool isCharge = false;
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";

            while(isCharge == false && userInput != r_KeyToExitToMenu)
            {
                try
                {
                    licenseNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
                    Console.WriteLine("Please enter the amount of minutes that you want to charge in vehicle");
                    userInput = Console.ReadLine();
                    amountToCharge = UiFuncationHelper.ChekingFloatNumberFromUser(userInput);
                    m_Garage.ChargingVehicle(licenseNumber, amountToCharge);
                    Console.WriteLine("succsed charging vehicle");
                    isCharge = true;
                }
                catch(ValueOutOfRangeException voore)
                {
                    voore.MaxValue = voore.MaxValue * 60f;
                    voore.MinValue = voore.MinValue * 60f;
                    UiFuncationHelper.CatchRangeExPrintToConsole(voore);
                    userInput = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    userInput = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
            }
        }

        private void refulVehicle()
        {
            string licenseNumber, userInput = null;
            float amountToFill;
            bool isRefulVehicleWork = false;
            FuelEngine.eKindOfFuel kindOfFuelToFill;
            string messageToSendToFuncation = "Please enter type of fuel from the list below";
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";

            while((isRefulVehicleWork == false) && (userInput != r_KeyToExitToMenu))
            {
                try
                {
                    licenseNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
                    Console.WriteLine("Please enter the amount of fuel you want to fill");
                    userInput = Console.ReadLine();
                    amountToFill = UiFuncationHelper.ChekingFloatNumberFromUser(userInput);
                    kindOfFuelToFill = UiFuncationHelper.GettingUserInputForGeneralEnum<FuelEngine.eKindOfFuel>(messageToSendToFuncation);
                    m_Garage.RefuelVehicle(licenseNumber, kindOfFuelToFill, amountToFill);
                    Console.WriteLine("You succsed to reful the vehicle");
                    isRefulVehicleWork = true;
                }
                catch(ValueOutOfRangeException voore)
                {
                    UiFuncationHelper.CatchRangeExPrintToConsole(voore);
                    userInput = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    userInput = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
            }
        }

        private void fillingAirInWheelsToMaximum()
        {
            string licenseNumber;
            bool isFilledToMaximum = false;
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";
            string keyToReturnToMenu = null;

            while((isFilledToMaximum == false) && (keyToReturnToMenu != r_KeyToExitToMenu))
            {
                try
                {
                    licenseNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
                    m_Garage.FillingAirWheelsToMax(licenseNumber);
                    isFilledToMaximum = true;
                    Console.WriteLine("Filling air in wheels to maximum succsed");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    keyToReturnToMenu = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
            }
        }

        private void changeVehicleStatusInGarge()
        {
            bool isUpdateStatus = false;
            string keyToReturnToMenu = null;
            string licenceNumber;
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";
            InformationOfVehicleInGarage.eStatusInGarge statusOfVehicleToChangeTo;
            string messageToSendToFunaction = "Please enter status to change the car from the list below : ";

            while((isUpdateStatus == false) && (keyToReturnToMenu != r_KeyToExitToMenu))
            {
                try
                {
                    licenceNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
                    statusOfVehicleToChangeTo = UiFuncationHelper.GettingUserInputForGeneralEnum<InformationOfVehicleInGarage.eStatusInGarge>(messageToSendToFunaction);
                    m_Garage.ChangeStatusOfVehicleInGarage(statusOfVehicleToChangeTo, licenceNumber);
                    isUpdateStatus = true;
                    Console.WriteLine("You succsed to change status of car");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    keyToReturnToMenu = UiFuncationHelper.AskingIfYouWantToExit(r_KeyToExitToMenu);
                }
            }
        }

        private int gettingUserMenuChoose()
        {
            string userChoise;
            int numberInMenu, numberOfMenuOptions;
            bool isCorrectInputInMenu;

            numberOfMenuOptions = Enum.GetNames(typeof(eGarageMenu)).Length;
            printingGarageMenu();
            userChoise = Console.ReadLine();
            isCorrectInputInMenu = UiFuncationHelper.IsCheckIfTheValueEnumIsValid(userChoise, numberOfMenuOptions);
            while(isCorrectInputInMenu == false)
            {
                Console.WriteLine("You didnt enter valid input, please try again");
                printingGarageMenu();
                userChoise = Console.ReadLine();
                numberOfMenuOptions = Enum.GetNames(typeof(eGarageMenu)).Length;
                isCorrectInputInMenu = UiFuncationHelper.IsCheckIfTheValueEnumIsValid(userChoise, numberOfMenuOptions);
            }

            numberInMenu = int.Parse(userChoise);

            return numberInMenu;
        }

        private string gettingNameOfVehicleOwner()
        {
            string fullName;
            bool validFullName;

            Console.WriteLine("Please Enter Your full name : ");
            fullName = Console.ReadLine();
            validFullName = UiFuncationHelper.IsStringValidName(fullName);
            while(validFullName == false)
            {
                Console.WriteLine("Please try again, you enterd not valid  full name");
                Console.WriteLine("Please Enter Your full name : ");
                fullName = Console.ReadLine();
                validFullName = UiFuncationHelper.IsStringValidName(fullName);
            }

            return fullName;
        }

        private void addVehicleToGarage()
        {
            string fullName, ownerPhoneNumber, licenceNumber;
            string licenseNumberStringToSendToFunactionToPrint = "Please enter license number";
            Vehicle vehicle;

            licenceNumber = UiFuncationHelper.GettingStringToWorkWith(licenseNumberStringToSendToFunactionToPrint);
            if(m_Garage.IsVehicleExsistInDataStruct(licenceNumber) == false)
            {
                vehicle = addInformationVehicle(licenceNumber);
                fullName = gettingNameOfVehicleOwner();
                ownerPhoneNumber = gettingPhoneNumberFromUser();
                m_Garage.InsertVehicleToGarge(fullName, ownerPhoneNumber, vehicle);
                Console.WriteLine("Your vehicle successfully added to garage");
            }
            else
            {
                InformationOfVehicleInGarage.eStatusInGarge statusToChangeTheVehicle = InformationOfVehicleInGarage.eStatusInGarge.InRepair;

                m_Garage.ChangeStatusOfVehicleInGarage(statusToChangeTheVehicle, licenceNumber);
                Console.WriteLine("Vehicle already exsist, Changing status to in reapir");
            }
        }

        private void gettingAndPrintVehicleLicenseList()
        {
            InformationOfVehicleInGarage.eStatusInGarge statusInGargeByUser;
            string userInput;
            List<string> vehicleLicenseListFromGarage = null;
            string messageToSendToFunaction = "Please enter the status from the list below";

            Console.WriteLine("Please enter 1 for see all the list of licence number otherwise enter any key to see list of fileters");
            userInput = Console.ReadLine();
            if(userInput == "1")
            {
                vehicleLicenseListFromGarage = m_Garage.ListOfVehicleLicenseNumbers();
            }
            else
            {
                statusInGargeByUser = UiFuncationHelper.GettingUserInputForGeneralEnum<InformationOfVehicleInGarage.eStatusInGarge>(messageToSendToFunaction);
                vehicleLicenseListFromGarage = m_Garage.ListOfVehicleLicenseNumbersByFiltering(statusInGargeByUser);
            }

            if(vehicleLicenseListFromGarage.Any() == false)
            {
                Console.WriteLine("The list of licence number is empty");
            }
            else
            {
                Console.WriteLine("The list of licence number is : ");
                foreach(string licenseNumber in vehicleLicenseListFromGarage)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private Vehicle addInformationVehicle(string i_LicenceNumber)
        {
            string vehicleModel;
            CreateVehicle.eVehicleType vehicleType;
            Vehicle vehicleToReturn;
            string messageToSendToFuncationVehicleType = "Please enter type of Vehicle from the list below";
            string vehicleModelString = "Please enter your vehicle model name";

            vehicleType = UiFuncationHelper.GettingUserInputForGeneralEnum<CreateVehicle.eVehicleType>(messageToSendToFuncationVehicleType);
            vehicleToReturn = CreateVehicle.MakeVehicle(vehicleType);
            vehicleModel = UiFuncationHelper.GettingStringToWorkWith(vehicleModelString);
            vehicleToReturn.SettingVehicleInformation(i_LicenceNumber, vehicleModel);
            insertAirPressureToWheelOfVehicle(vehicleToReturn);

            insertEnergyLeftInEngine(vehicleType, vehicleToReturn);
            gettingAndSettingUniqueInformationFromUser(vehicleToReturn);

            return vehicleToReturn;
        }

        private void insertAirPressureToWheelOfVehicle(Vehicle i_Vehicle)
        {
            bool isAirPressureInsertGood = false;
            float currentWheelAirPressure;
            string wheelManufacturerNameString = "Please enter your wheel manufacturer name";
            string wheelManufacturerName;

            wheelManufacturerName = UiFuncationHelper.GettingStringToWorkWith(wheelManufacturerNameString);
            while(isAirPressureInsertGood == false)
            {
                try
                {
                    currentWheelAirPressure = gettingAirPressureFromUser();
                    i_Vehicle.SetWheelInformation(currentWheelAirPressure, wheelManufacturerName);
                    isAirPressureInsertGood = true;
                }
                catch(ValueOutOfRangeException voore)
                {
                    UiFuncationHelper.CatchRangeExPrintToConsole(voore);
                }
            }
        }

        private void gettingAndSettingUniqueInformationFromUser(Vehicle i_VehicleToReturn)
        {
            bool isUniqueInformationThrowEx = false;
            List<string> listOfUniqueInformation = new List<string>();
            string stringWhichUniqueInformationToEnter;
            int numberOfUniqueInformation;

            stringWhichUniqueInformationToEnter = i_VehicleToReturn.GettingWithSpecialInformationOfVehicleUiNeedToEnter(out numberOfUniqueInformation);
            Console.WriteLine(stringWhichUniqueInformationToEnter);
            while(isUniqueInformationThrowEx == false)
            {
                try
                {
                    for(int i = 0; i < numberOfUniqueInformation; i++)
                    {
                        listOfUniqueInformation.Add(Console.ReadLine());
                    }

                    i_VehicleToReturn.SetVehicleUniqueInformation(listOfUniqueInformation);
                    isUniqueInformationThrowEx = true;
                }
                catch(ValueOutOfRangeException voore)
                {
                    listOfUniqueInformation.Clear();
                    UiFuncationHelper.CatchRangeExPrintToConsole(voore);
                }
                catch(Exception ex)
                {
                    listOfUniqueInformation.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again");
                    Console.WriteLine(stringWhichUniqueInformationToEnter);
                }
            }
        }

        private void insertEnergyLeftInEngine(CreateVehicle.eVehicleType i_VehicleType, Vehicle i_Vehicle)
        {
            string userInput;
            bool isEnergyIsInRange = false;
            string stringMessageToPrintToConsole = string.Format("Please Enter your energy left in {0} engine : ", i_VehicleType.ToString());
            float capacityOfEnergyLeftInEngine;

            Console.WriteLine(stringMessageToPrintToConsole);
            userInput = Console.ReadLine();
            while(isEnergyIsInRange == false)
            {
                try
                {
                    capacityOfEnergyLeftInEngine = UiFuncationHelper.ChekingFloatNumberFromUser(userInput);
                    i_Vehicle.InsertEngineInformation(capacityOfEnergyLeftInEngine);
                    isEnergyIsInRange = true;
                }
                catch(ValueOutOfRangeException voore)
                {
                    UiFuncationHelper.CatchRangeExPrintToConsole(voore);
                    userInput = Console.ReadLine();
                }
            }
        }

        private float gettingAirPressureFromUser()
        {
            string userInput;
            float airPressure;

            Console.WriteLine("Please Enter Your current wheel air pressure : ");
            userInput = Console.ReadLine();
            airPressure = UiFuncationHelper.ChekingFloatNumberFromUser(userInput);

            return airPressure;
        }

        private string gettingPhoneNumberFromUser()
        {
            string phoneNumber;
            bool isPhoneNumber;

            Console.WriteLine("Please Enter Your Phone Number : ");
            phoneNumber = Console.ReadLine();
            isPhoneNumber = UiFuncationHelper.IsValidNumberPhone(phoneNumber);
            while(isPhoneNumber == false)
            {
                Console.WriteLine("You entered not valid phone number, Please enter again");
                phoneNumber = Console.ReadLine();
                isPhoneNumber = UiFuncationHelper.IsValidNumberPhone(phoneNumber);
            }

            return phoneNumber;
        }

        private void printingGarageMenu()
        {
            string stringToPrint = string.Format(
@"Choose your action in garage.
1 to Add new vehicle.
2 to Show vehicles license number by status.
3 to Change vehicle status in garage.
4 to Inflate vehicle wheels to maximum air pressure.
5 to Refuel vehicle.
6 to Charge electric vehicle.
7 to Show full information of vehicle in garage.
8 to exit from garage program.");
            Console.WriteLine(stringToPrint);
        }
    }
}
