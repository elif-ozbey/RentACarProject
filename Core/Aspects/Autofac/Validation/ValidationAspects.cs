using Castle.DynamicProxy;
using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspects:MethodIntereptions
    {
        private Type _validatorType;
        public ValidationAspects(Type validatortype)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatortype))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degildir");
            }

            _validatorType = validatortype;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities= invocation.Arguments.Where(x=> x.GetType()== entityType).ToList();
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
