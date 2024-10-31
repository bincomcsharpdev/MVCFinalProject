using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Implementation.Interfaces;

namespace ResumeMangerWebApi.Implementation.Services
{
    public class TaxService(ITaxRepository taxRepository) : ITaxService
    {
        private readonly ITaxRepository _taxRepository = taxRepository;

        public decimal CalculatePAYE(decimal income)
        {
           return _taxRepository.CalculatePAYE(income);
        }
    }
}
