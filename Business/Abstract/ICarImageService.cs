﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile image, CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
