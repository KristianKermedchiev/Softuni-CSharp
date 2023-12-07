using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {

        private string firstname;
        private string lastname;
        private string drivingLicenseNumber;
        private double rating;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
        }

        public string FirstName
        {
            get => firstname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName cannot be null or whitespace!");
                }

                firstname = value;
            }
        }

        
        public string LastName
        {
            get => lastname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LastName cannot be null or whitespace!");
                }

                lastname = value;
            }
        }

        public double Rating
        {
            get;
            private set;
        }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Driving license number is required!");
                }

                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get;
            private set;
        }

        public void DecreaseRating()
        {
            this.Rating -= 2.0;

            if (this.Rating < 0.0)
            {
                this.Rating = 0.0;
                this.IsBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;

            if (this.Rating >= 10.0)
            {
                this.Rating = 10.0;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
