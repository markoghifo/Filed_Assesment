using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.CustomAttributes
{
    public static class ModelStateExtension
    {
        public static string GetErrorMessages(this ModelStateDictionary dictionary)
        {
            List<string> err = dictionary.SelectMany(mbox => mbox.Value.Errors)
                .Select(m => m.ErrorMessage).ToList();
            return string.Join(",", err.ToArray());
        }
    }
}
