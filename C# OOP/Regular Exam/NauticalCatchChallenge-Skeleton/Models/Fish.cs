﻿using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {

        private string name;
        private double points;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name should be determined.");
                }

                name = value;
            }
        }

        public double Points
        {
            get => points;
            private set
            {
                if(value > 10 || value < 1)
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }

                points = Math.Round(value, 1);
            }
        }

        public int TimeToCatch { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
