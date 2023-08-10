using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public object Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
