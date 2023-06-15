using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {                               //IValidator ProductValidator aslında ve IValidation FluentValidationdan gelir
                                    //doğrulamaların olduğu class -- entity ise doğrulanacak class
        public static void Validate(IValidator validator,object entity)
        {
            //buradaki object için doğrulama yapcağım parametrede entity
            var context = new ValidationContext<object>(entity);//doğrulama işlemini gerçekleştirmesi için gerekli olan bilgileri sağlar          
            var result = validator.Validate(context);//doğrulama işlemini gerçekleştirir

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
