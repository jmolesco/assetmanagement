using AM.API.DTOs.Suppliers;
using AM.API.Helpers;
using AM.Core.Domain.Suppliers;
using AutoMapper;

namespace AM.API.Services.Suppliers
{
    public interface ISupplierService
    {

        /// <summary>
        /// Add new Supplier
        /// </summary>
        /// <param name="supplier">Supplier</param>
        /// <returns></returns>
        object Add(Supplier supplier);

        /// <summary>
        /// Get all Suppliers
        /// </summary>
        /// <param name="criteria">Search criterias</param>
        /// <param name="appSettings">AppSettings</param>
        /// <returns></returns>
        object GetAll(GetAll criteria, AppSettings appSettings);

        /// <summary>
        /// Get Supplier by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetById(int id);

        /// <summary>
        /// Update Supplier record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="supplier">Supplier</param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        object Update(int id, UpdateSupplier supplier, IMapper mapper);

        object Delete(int id);
    }
}
