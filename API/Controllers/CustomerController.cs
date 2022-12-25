﻿using Application.Commands;
using Application.Queries;
using Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        public async Task<List<CustomerModel>> Get()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        [Route("EditCustomer")]
        public async Task<ActionResult> EditCustomer( [FromBody] EditCustomerCommand command)
        {
            try
            {              
               
                    var result = await _mediator.Send(command);
                    return Ok(result);
               
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {              
                string result = await _mediator.Send(new DeleteCustomerCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
