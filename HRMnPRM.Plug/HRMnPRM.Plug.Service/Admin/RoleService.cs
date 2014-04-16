using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;
using HRMnPRM.Plug.Data;
using HRMnPRM.Plug.Domain;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Service
{
    #region Interface Implement : Role

    public class RoleService : IRoleService
    {
        #region Global Variable Declaration

        private readonly IRepository<Role> _iRoleRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public RoleService(IRepository<Role> iRoleRepository, IUnitOfWork iUnitOfWork)
        {
            this._iRoleRepository = iRoleRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<RoleViewModel> GetAll()
        {
            var roleViewModels = new List<RoleViewModel>();
            try
            {

                List<Role> roles = _iRoleRepository.GetAll();

                foreach (Role role in roles)
                {
                    var roleViewModel = role.ConvertModelToViewModel<Role, RoleViewModel>();
                    roleViewModels.Add(roleViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roleViewModels.AsQueryable();
        }

        public RoleViewModel GetRole(string roleName)
        {
            var roleViewModel = new RoleViewModel();

            try
            {
                Role role = _iRoleRepository.GetById(roleName);
                roleViewModel = role.ConvertModelToViewModel<Role, RoleViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return roleViewModel;
        }

        public RoleViewModel GetById(long id)
        {
            var roleViewModel = new RoleViewModel();

            try
            {
                Role role = _iRoleRepository.GetById(id);
                roleViewModel = role.ConvertModelToViewModel<Role, RoleViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return roleViewModel;
        }

        #endregion

        #region Create Method

        public int Create(RoleViewModel roleViewModel)
        {
            int isSave = 0;
            try
            {
                if (roleViewModel != null)
                {
                    Role role = roleViewModel.ConvertViewModelToModel<RoleViewModel, Role>();
                    _iRoleRepository.Insert(role);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("RoleViewModel", "Request data is null.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSave;
        }

        #endregion

        #region Update Method

        public int Update(RoleViewModel roleViewModel)
        {
            int isSave = 0;
            try
            {
                if (roleViewModel != null)
                {
                    Role role = roleViewModel.ConvertViewModelToModel<RoleViewModel, Role>();
                    _iRoleRepository.Update(role);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("RoleViewModel", "Request data is null.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        #endregion

        #region Delete Method

        public int Delete(RoleViewModel roleViewModel)
        {
            int isSave = 0;
            try
            {
                if (roleViewModel != null)
                {
                    var viewModel = GetRole(roleViewModel.RoleName);
                    Role role = viewModel.ConvertViewModelToModel<RoleViewModel, Role>();
                    _iRoleRepository.Delete(role);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("RoleViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(long id)
        {
            int isSave = 0;
            try
            {
                var roleViewModel = GetById(id);
                if (roleViewModel != null)
                {
                    Role role = roleViewModel.ConvertViewModelToModel<RoleViewModel, Role>();
                    _iRoleRepository.Delete(role);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("RoleViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<RoleViewModel> roleViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var roleViewModel in roleViewModels)
                {
                    RoleViewModel viewModel = GetById(roleViewModel.Id);
                    Delete(viewModel);
                }


                isSave = Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        #endregion

        #region Save By Commit

        public int Save()
        {
            return _iUnitOfWork.Commit();
        }

        #endregion

    }

    #endregion

    #region Interface : Role

    public interface IRoleService : IGeneric<RoleViewModel>
    {
        RoleViewModel GetRole(string roleName);

        int Delete(List<RoleViewModel> roleViewModels);

    }

    #endregion
}
