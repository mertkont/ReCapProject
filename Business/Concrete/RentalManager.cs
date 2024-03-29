﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<RentalsDto>> GetRentals()
        {
            return new SuccessDataResult<List<RentalsDto>>(_rentalDal.GetRentals());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //arabanın tek kişi tarafından kiralanabilmesi için kiralayan kişinin araba id'si unique.
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorResult(Messages.BreakTime);
            }

            _rentalDal.Add(rental);
            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.CarDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true, Messages.CarUpdated);
        }
    }
}