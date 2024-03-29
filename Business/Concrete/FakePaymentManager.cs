﻿using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        private ICreditCardService _creditCardService;
        private IRentalService _rentalService;

        public FakePaymentManager(ICreditCardService creditCardService, IRentalService rentalService)
        {
            _creditCardService = creditCardService;
            _rentalService = rentalService;
        }

        [TransactionScopeAspect]
        public IResult GetPayment(CreditCardForUserOperationsDto creditCardForUserOperationsDto, Rental rental)
        {
            var result = BusinessRules.Check(_creditCardService.GetById(creditCardForUserOperationsDto.Id), _rentalService.Add(rental));
            if (result is ErrorResult)
            {
                return result;
            }

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
