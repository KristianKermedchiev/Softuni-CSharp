﻿using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {

        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            this.vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return this.vehicles.FirstOrDefault(x => x.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.vehicles;
        }

        public bool RemoveById(string identifier)
        {
            var vehicle = this.FindById(identifier);

            return vehicles.Remove(vehicle);
        }
    }
}
