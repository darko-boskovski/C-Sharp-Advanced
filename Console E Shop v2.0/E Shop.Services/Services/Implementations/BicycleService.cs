using E_Shop.Domain.Core.Entities;
using E_Shop.Domain.Core.Enums;
using E_Shop.Domain.Db;
using E_Shop.Services.Services.Interfaces;
using SEDC.TryBeingFit.Domain.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Shop.Services.Services.Implementations
{

    public class BicycleService<T> : IBicycleService<T> where T : Bicycle
    {
        public static IDb<Bicycle> _bicycleDataBase = new BicycleDb<Bicycle>();


        private IDb<T> _db;

        public BicycleService()
        {
            _db = new BicycleDb<T>();
        }

        public List<T> Seed(List<T> entity)
        {
            return _bicycleDataBase.Insert(entity);
        }

        public List<Bicycle> GetAllProducts()
        {
            return new List<Bicycle>()
            {
                new Bicycle(1,Brand.Ghost,"Ghost Kato 2.9", TypeOfBike.MountainBike,32000, Size.L),
                new Bicycle(2,Brand.Cube,"Cube Aim Pro", TypeOfBike.MountainBike,36000, Size.XL),
                new Bicycle(3,Brand.Trek,"Trek Fx 2", TypeOfBike.CiryBike,28000, Size.M),
                new Bicycle(4,Brand.Specialized,"Allez", TypeOfBike.RoadBike,75000, Size.M),
                new Bicycle(5,Brand.Bianchi,"Bianchi VIA NIRONE 7 105", TypeOfBike.RoadBike,97000, Size.L),
                new Bicycle(6,Brand.Scott,"Scott Speedster 30", TypeOfBike.RoadBike,56000, Size.M),
                new Bicycle(7,Brand.Trek,"Trek Domane AL2", TypeOfBike.RoadBike,55180, Size.L),
                new Bicycle(8,Brand.Bianchi,"Bianchi MAGMA 9.2 ", TypeOfBike.MountainBike,45000, Size.L),
                new Bicycle(9,Brand.Trek,"Trek Precaliber 20", TypeOfBike.KidsBike,15900, Size.S),
                new Bicycle(10,Brand.Giant,"Giant Revolt Advanced", TypeOfBike.Gravel,120000, Size.M),
                new Bicycle(11, Brand.Cube,"CUBE ACCESS WS", TypeOfBike.MountainBike,34500, Size.S)

            };
        }



    }
}
