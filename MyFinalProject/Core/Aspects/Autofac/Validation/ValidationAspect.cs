using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.AspectInterceptorSelector;

namespace Core.Aspects.Autofac.Validation
{
    //bu bir attribute
    //sen bir MethodInterception 'sın 
    public class ValidationAspect : MethodInterception//bu bir aspect aslında aspect demek metodun başında sonunda hata verdiğinde çalışacak yapı
    {
        private Type _validatorType;
                             
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
       
        protected override void OnBefore(IInvocation invocation)
        {
                             //ProductValidator'ın bir instance'ını oluştur
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

                            //ProductValidator'ın generic çalıştığı tipi bul(Product gibi) _validatorType şuan Product
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

                            //ilgili methdodun parametrelerini bul businessdaki add gibi
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //parametreyi bul ve birden fazla varsa parametre tek tek gez validationTool'u kullanarak validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
