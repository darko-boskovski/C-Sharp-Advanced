using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Services.Services.Implementations
{
    public static class BicycleGenerator
    {
        static Random random = new Random();
        static T RandomEnumValue<T>()
        {
            var value = Enum.GetValues(typeof(T));
            return (T)value.GetValue(random.Next(value.Length));
        }

        public static List<Bicycle> RandBikeGenerator(List<Bicycle> bikeList, int number)
        {
            List<string> bikeNames = new List<string> {
                "THE CLIMBER",
                "RENEGADE 7.0",
                "HE RAV.ROOkIE",
                "BlACK FOREST",
                "RAVEN", "DIVISION",
                "WHISTLER",
                "S-ELECTRO TRAIL",
                "AVENTURA",
                "VOYAGER "
            };
            int id = (bikeList[bikeList.Count - 1].Id);

            for (int i = 1; i < number; i++)
            {
                Random rnd = new Random();
                Bicycle newbicycle = new Bicycle();
                newbicycle.Id = ++id;
                newbicycle.Brand = RandomEnumValue<Brand>();
                newbicycle.Name = bikeNames[rnd.Next(0, bikeNames.Count - 1)];
                newbicycle.Price = rnd.Next(1, 90000);
                newbicycle.Size = RandomEnumValue<Size>();
                newbicycle.Type = RandomEnumValue<TypeOfBike>();
                bikeList.Add(newbicycle);

            }
            return bikeList;
        }

    }
}
