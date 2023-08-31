using Microsoft.AspNetCore.Mvc.Filters;

namespace CarDealsPlace.Filters
{
    public class PreviousFullPathFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string previousFullPath = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            context.HttpContext.Response.Cookies.Append("PreviousPagePath", previousFullPath);
        }
    }
}
