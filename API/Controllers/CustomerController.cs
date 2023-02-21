using Application.Commands;
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
       
        /// <summary>
        /// لیست مشتریان را برمیگرداند
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<CustomerModel>> Get()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }

        /// <summary>
        /// ایجاد یک مشتری جدید
        /// </summary>
        /// <param name="command">اطلاعات مشتری جدید</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// ویرایش یک مشتری
        /// </summary>
        /// <param name="command">اطلاعات ویرایش شده مشتری</param>
        /// <returns></returns>
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

        /// <summary>
        /// حذف یک مشتری
        /// </summary>
        /// <param name="id">شناسه مشتری</param>
        /// <returns></returns>
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
