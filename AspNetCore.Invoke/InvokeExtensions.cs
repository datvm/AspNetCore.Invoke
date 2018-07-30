using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Invoke
{

    public static class InvokeExtensions
    {

        public static IActionResult InvokeService(this ControllerBase controller, Action serviceAction)
        {
            try
            {
                serviceAction();

                return controller.NoContent();
            }
            catch (ServiceException ex)
            {
                return new ObjectResult(new DefaultExceptionResponse())
                {
                    StatusCode = (int) ex.StatusCode,
                };
            }
        }

        public static ActionResult<T> InvokeService<T>(this ControllerBase controller, Func<T> serviceFunc)
        {
            try
            {
                return serviceFunc();
            }
            catch (ServiceException ex)
            {
                return new ObjectResult(new DefaultExceptionResponse())
                {
                    StatusCode = (int)ex.StatusCode,
                };
            }
        }

        public static async Task<IActionResult> InvokeServiceAsync(this ControllerBase controller, Func<Task> serviceAction)
        {
            try
            {
                await serviceAction();

                return controller.NoContent();
            }
            catch (ServiceException ex)
            {
                return new ObjectResult(new DefaultExceptionResponse(ex))
                {
                    StatusCode = (int)ex.StatusCode,
                };
            }
        }

        public static async Task<ActionResult<T>> InvokeServiceAsync<T>(this ControllerBase controller, Func<Task<T>> serviceFunc)
        {
            try
            {
                return await serviceFunc();
            }
            catch (ServiceException ex)
            {
                return new ObjectResult(new DefaultExceptionResponse(ex))
                {
                    StatusCode = (int)ex.StatusCode,
                };
            }
        }

    }

}
