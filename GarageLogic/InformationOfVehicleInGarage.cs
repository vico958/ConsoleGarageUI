﻿namespace Ex03.GarageLogic
{
    using System;

    public class InformationOfVehicleInGarage
    {
        private PersonInformation m_PersonInformation;
        private eStatusInGarge m_StatusInGarge;
        private Vehicle m_VehicleInGarageInformation;

        public InformationOfVehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_VehicleInGarageInformation)
        {
            m_PersonInformation = new PersonInformation(i_OwnerName, i_OwnerPhoneNumber);
            m_VehicleInGarageInformation = i_VehicleInGarageInformation;
            this.StatusInGarge = eStatusInGarge.InRepair;
        }

        public enum eStatusInGarge
        {
            InRepair = 1,
            Fixed,
            Paid,
        }

        public string OwnerName
        {
            get
            {
                return this.m_PersonInformation.PersonFullName;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_VehicleInGarageInformation;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_PersonInformation.PersonPhoneNumber;
            }
        }

        public eStatusInGarge StatusInGarge
        {
            get
            {
                return m_StatusInGarge;
            }

            set
            {
                m_StatusInGarge = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle info is :
{0}.
Owner name of vehicle is : {1}.
Status of vehicle in garage is : {2}.", m_VehicleInGarageInformation.ToString(), m_PersonInformation.PersonFullName, Enum.GetName(typeof(eStatusInGarge), m_StatusInGarge));
        }
    }
}
