﻿using MediatR;
using ProjectE.Application.Responses;
using ProjectE.Core.Entities;
using ProjectE.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE.Application.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, Response>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        public async Task<Response> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetSkillsByIdAsync(request.Id);

            if (customer is null) return Response.Error("Cliente nao existe");

            customer.SetEntityAsDeleted();
            await _customerRepository.UpdateAsync(customer);

            return Response.Success();
        }
    }
}
