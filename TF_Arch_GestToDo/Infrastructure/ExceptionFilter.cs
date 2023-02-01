using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TF_Arch_GestToDo.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TF_Arch_GestToDo.Infrastructure
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel() { Error = context.Exception.Message };
            
            if (!_hostEnvironment.IsDevelopment())
            {
                errorViewModel.Error = "Une erreur s'est produite, veuillez le signaler à l'admin du site";
            }

            //Comment faire passer l'info
            ViewResult result = new ViewResult() { ViewName = "ShowError" };
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Model = errorViewModel;
                        
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
