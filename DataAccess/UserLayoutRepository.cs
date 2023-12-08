using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract;
using DomainModel;
using DomainModel.DTO.ViewModels;
using DomainModel.DTO.ViewModels.Layout;
using DomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UserLayoutRepository : BaseRepository<UserLayout, int>, IUserLayoutRepository
    {
        private readonly PersonalContext _context;
        private readonly ISectionUserLayoutRepository _sectionUserRepository;
        public UserLayoutRepository(PersonalContext context, IHttpContextAccessor _accessor, ISectionUserLayoutRepository sectionUserRepository = null) : base(context, _accessor)
        {
            _context = context;
            _sectionUserRepository = sectionUserRepository;
        }

        public async Task<RepositoryResult> AddDefaultLayout(string UserID)
        {
            var returnModel = new RepositoryResult();
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Id == UserID);
                if (user == null)
                {
                    returnModel.Error = "error in get User";
                    returnModel.IsSuccess = false;
                    return returnModel;
                }
                var defaultLayout = await _context.Layouts.FirstOrDefaultAsync(x => x.Default);
                if (defaultLayout == null)
                {
                    returnModel.Error = "error in get Default Layout";
                    returnModel.IsSuccess = false;
                    return returnModel;
                }
                var layout = new UserLayout()
                {
                    UserID = UserID,
                    LayoutID = defaultLayout.ID
                };
                var resAdd = await AddAsync(layout);
                if (!resAdd.Success)
                {
                    returnModel.Error = "error in Add ";
                    returnModel.IsSuccess = false;
                    return returnModel;
                }
                resAdd = await SaveAsync();
                if (!resAdd.Success)
                {
                    returnModel.Error = "error in SaveDatabase";
                    returnModel.IsSuccess = false;
                    return returnModel;
                }
                returnModel.Error = "Success";
                returnModel.IsSuccess = true;
                return returnModel;
            }
            catch (System.Exception ex)
            {
                returnModel.Error = ex.Message;
                returnModel.IsSuccess = false;
                return returnModel;
            }
        }

        public async Task<RepositoryResult> NewUserLayout(string UserID, List<int> Section, int LayoutID, int? userLayoutID, string Name)
        {
            var returnModel = new RepositoryResult();
            try
            {
                var userLayout = new UserLayout();
                bool help = true;
                if (userLayoutID.HasValue && userLayoutID.Value > 0)
                {
                    userLayout = await _context.UserLayouts.FirstOrDefaultAsync(x => x.ID == userLayoutID);
                    if (!string.IsNullOrWhiteSpace(Name)) userLayout.Name = Name;
                    help = false;
                }

                if (help)
                {
                    var newUserLayout = new UserLayout()
                    {
                        LayoutID = LayoutID,
                        UserID = UserID,
                        Name = Name
                    };
                    var resAdd = await AddAsync(newUserLayout);
                    if (!resAdd.Success)
                    {
                        returnModel.Error = "Error : UserLayoutNotAdd ";
                        returnModel.IsSuccess = false;
                        return returnModel;

                    }
                    resAdd = await SaveAsync();
                    if (!resAdd.Success)
                    {
                        returnModel.Error = "Error : DataBase Not save";
                        returnModel.IsSuccess = false;
                        return returnModel;
                    }
                }

                var section = new Sections();

                var listdelete = _context.SectionUserLayouts.Where(x => x.userLayoutID == userLayout.ID);
                if (listdelete != null)
                {
                    foreach (var item in listdelete)
                    {
                        var resDel = await _sectionUserRepository.DeleteAsync(item);
                        if (!resDel.Success)
                        {
                            returnModel.Error = "Error : Delete SectionUser Not working";
                            returnModel.IsSuccess = false;
                            return returnModel;


                        }
                    }
                }

                foreach (var item in Section)
                {
                    section = await _context.Sections.FirstOrDefaultAsync(x => x.ID == item);
                    if (section == null)
                    {
                        returnModel.Error = "Error: Section Not Found";
                        returnModel.IsSuccess = false;
                        return returnModel;
                    }
                    var newUserLayoutSection = new SectionUserLayout()
                    {
                        sectionID = section.ID,
                        userLayoutID = userLayout.ID
                    };
                    var resAdd = await _sectionUserRepository.AddAsync(newUserLayoutSection);
                    if (!resAdd.Success)
                    {
                        returnModel.Error = "Error : Error in Add Section Layout";
                        returnModel.IsSuccess = false;
                        return returnModel;
                    }
                }
                var resSave = await SaveAsync();
                if (!resSave.Success)
                {
                    returnModel.Error = "Error : save Database";
                    returnModel.IsSuccess = false;
                    return returnModel;
                }
                returnModel.Error = "Success";
                returnModel.IsSuccess = true;
                return returnModel;
            }
            catch (System.Exception ex)
            {
                returnModel.Error = ex.Message;
                returnModel.IsSuccess = false;
                return returnModel;
                throw;
            }
        }
    }
}