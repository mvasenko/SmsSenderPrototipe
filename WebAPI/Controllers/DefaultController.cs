using System;
using BLL.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected IActionResult CallBusinessLogicAction<T>(Func<T> bllAction)
        {
            try
            {
                var result = bllAction.Invoke();
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return StatusCode((int) ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{AppDomain.CurrentDomain.FriendlyName} : {ex.Message}");
            }
        }
    }
}