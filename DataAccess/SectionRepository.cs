using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel;
using DomainModel.DTO.ViewModels;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;

namespace DataAccess
{
    public class SectionRepository : BaseRepository<Sections, int>, ISectionRepository
    {
        private readonly PersonalContext _context;
        public SectionRepository(PersonalContext context, IHttpContextAccessor _accessor) : base(context, _accessor)
        {
            this._context = context;
        }

        public async Task<RepositoryResult<List<int>>> AddSections(List<int> defaultSectionsId)
        {
            var returnModel = new RepositoryResult<List<int>>();
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                returnModel.Error = ex.Message;
                returnModel.IsSuccess = false;
                returnModel.Model=new List<int>();
                return returnModel;
                throw;
            }
        }
    }
}