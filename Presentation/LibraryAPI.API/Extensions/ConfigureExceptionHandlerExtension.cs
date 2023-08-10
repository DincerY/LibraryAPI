using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace LibraryAPI.API.Extensions
{
    public static class ConfigureExceptionHandlerExtension
    {
        //public static void ConfigureExceptionHandler(this WebApplication application)
        //{
        //    application.UseExceptionHandler(builder =>
        //    {
        //        builder.Run(async context =>
        //        {
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            if (contextFeature != null)
        //            {
        //                await context.Response.WriteAsync(JsonSerializer.Serialize(new
        //                {
        //                    StatusCode = context.Response.StatusCode,
        //                    Message = contextFeature.Error.Message,
        //                    Title = "Hata Alındı"
        //                }));
        //            }
        //        });
        //    });
        //}

    }
}
