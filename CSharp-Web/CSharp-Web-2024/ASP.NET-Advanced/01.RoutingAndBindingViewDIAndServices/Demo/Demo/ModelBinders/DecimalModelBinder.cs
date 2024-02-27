using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Demo.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None 
                && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal result = 0M;
                bool sucess = false;

                try
                {
                    string strValue = valueResult.FirstValue.Trim();
                    strValue = strValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    strValue = strValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    result = Convert.ToDecimal(strValue, CultureInfo.CurrentCulture);
                    sucess = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (sucess) 
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                }
            }

            return Task.CompletedTask;
        }
    }
}
