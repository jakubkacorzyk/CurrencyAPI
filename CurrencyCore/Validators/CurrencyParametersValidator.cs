using CurrencyDAL;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCore.Validators
{
    public class CurrencyParametersValidator : AbstractValidator<CurrencyConverterParams>
    {
        private readonly CurrencyDBContext _dbContext;
        public CurrencyParametersValidator(CurrencyDBContext currencyDBContext)
        {
            _dbContext = currencyDBContext;
            Rules();
        }
        public void Rules()
        {
            RuleFor(x => x.CodeTo)
                .Length(3)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (code, cancellation) =>
                {
                    return await CodeExists(code);
                })
                .WithMessage("CodeTo must exisit!");

            RuleFor(x => x.CodeFrom)
                .Length(3)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (code, cancellation) =>
                {
                    return await CodeExists(code);
                })
                .WithMessage("CodeFrom must exisit!");

            RuleFor(x => x.Value).GreaterThan(0).NotNull();
        }

        private async Task<bool> CodeExists(string code)
        {
            if (await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Code.Equals(code.ToUpper())) == null)
            {
                return false;
            }

            return true;
        }

    }
}
