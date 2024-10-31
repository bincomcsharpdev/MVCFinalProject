using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Implementation.Services;

namespace ResumeMangerWebApi.Data.Repository.Repository
{
    public class TaxRepository(Calculator calculate) : ITaxRepository
    {
        private readonly Calculator _calculate = calculate;

        public decimal CalculatePAYE(decimal incom)
        {
            return _calculate.CalculatePAYE(incom);
        }
    }
}
