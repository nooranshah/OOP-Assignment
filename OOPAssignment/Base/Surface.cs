﻿using OOPAssignment.IBase;
using OOPAssignment.Struct;
using System;
using System.Collections.Generic;

namespace OOPAssignment.Base
{
    public class Surface : ISurface, ICollidableSurface, IBase.IObserver<CarInfo>
    {
        public long Height { get; set; }
        public long Width { get; set; }

        private List<CarInfo> ObservableCars = new();

        public Surface(long width, long height)
        {
            Height = height;
            Width = width;
        }

        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            //Is the car Between X and Y Coordinates...
            return (coordinates.X >= 0 && coordinates.X <= Width) && (coordinates.Y >= 0 && coordinates.Y <= Height);
        }
        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            //checking the car crash if the x or y coordinate exist any can it should be jump to  throw exception
            var IsCar = ObservableCars.Find(x => x.Coordinates.X == coordinates.X && x.Coordinates.X == coordinates.Y);

            return IsCar != null;
        }
        public void Update(CarInfo carInfo)
        {
            var carId = ObservableCars.Find(x => x.CarId == carInfo.CarId);
            Coordinates coordinates = carInfo.Coordinates;
            if (IsCoordinatesInBounds(coordinates))
                throw new Exception("car is out of the line");



            if (IsCoordinatesInBounds(coordinates))
            {
                var car = ObservableCars.Find(x => x.CarId != carInfo.CarId && x.Coordinates.X == carInfo.Coordinates.X && x.Coordinates.Y == carInfo.Coordinates.Y);
                if (car is not null)
                    throw new Exception("car crashed");
                else if (carId is not null)
                    carId = carInfo;
                else
                    //add new car if there is not any car in the coordinates
                    ObservableCars.Add(carInfo);
            }
        }
        public List<CarInfo> GetObservables()
        {
            List<CarInfo> carInfo = new();
            carInfo.AddRange(ObservableCars);
            return carInfo;
        }
    }
}
