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
    #region Interface Implement : UserMenuPermission

    public class UserMenuPermissionService : IUserMenuPermissionService
    {
        #region Global Variable Declaration

        private readonly IRepository<UserMenuPermission> _iUserMenuPermissionRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public UserMenuPermissionService(IRepository<UserMenuPermission> iUserMenuPermissionRepository, IUnitOfWork iUnitOfWork)
        {
            this._iUserMenuPermissionRepository = iUserMenuPermissionRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<UserMenuPermissionViewModel> GetAll()
        {
            var userMenuPermissionViewModels = new List<UserMenuPermissionViewModel>();
            try
            {

                List<UserMenuPermission> userMenuPermissions = _iUserMenuPermissionRepository.GetAll();

                foreach (UserMenuPermission userMenuPermission in userMenuPermissions)
                {
                    var userMenuPermissionViewModel = userMenuPermission.ConvertModelToViewModel<UserMenuPermission, UserMenuPermissionViewModel>();
                    userMenuPermissionViewModels.Add(userMenuPermissionViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userMenuPermissionViewModels.AsQueryable();
        }

        public UserMenuPermissionViewModel GetUserMenuPermission(string userMenuPermissionName)
        {
            var userMenuPermissionViewModel = new UserMenuPermissionViewModel();

            try
            {
                UserMenuPermission userMenuPermission = _iUserMenuPermissionRepository.GetById(userMenuPermissionName);
                userMenuPermissionViewModel = userMenuPermission.ConvertModelToViewModel<UserMenuPermission, UserMenuPermissionViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userMenuPermissionViewModel;
        }

        public UserMenuPermissionViewModel GetById(long id)
        {
            var userMenuPermissionViewModel = new UserMenuPermissionViewModel();

            try
            {
                UserMenuPermission userMenuPermission = _iUserMenuPermissionRepository.GetById(id);
                userMenuPermissionViewModel = userMenuPermission.ConvertModelToViewModel<UserMenuPermission, UserMenuPermissionViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userMenuPermissionViewModel;
        }

        #endregion

        #region Create Method

        public int Create(UserMenuPermissionViewModel userMenuPermissionViewModel)
        {
            int isSave = 0;
            try
            {
                if (userMenuPermissionViewModel != null)
                {
                    UserMenuPermission userMenuPermission = userMenuPermissionViewModel.ConvertViewModelToModel<UserMenuPermissionViewModel, UserMenuPermission>();
                    _iUserMenuPermissionRepository.Insert(userMenuPermission);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("UserMenuPermissionViewModel", "Request data is null.");
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

        public int Update(UserMenuPermissionViewModel userMenuPermissionViewModel)
        {
            int isSave = 0;
            try
            {
                if (userMenuPermissionViewModel != null)
                {
                    UserMenuPermission userMenuPermission = userMenuPermissionViewModel.ConvertViewModelToModel<UserMenuPermissionViewModel, UserMenuPermission>();
                    _iUserMenuPermissionRepository.Update(userMenuPermission);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("UserMenuPermissionViewModel", "Request data is null.");
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

        public int Delete(UserMenuPermissionViewModel userMenuPermissionViewModel)
        {
            int isSave = 0;
            try
            {
                if (userMenuPermissionViewModel != null)
                {
                    var viewModel = GetById(userMenuPermissionViewModel.Id);
                    UserMenuPermission userMenuPermission = viewModel.ConvertViewModelToModel<UserMenuPermissionViewModel, UserMenuPermission>();
                    _iUserMenuPermissionRepository.Delete(userMenuPermission);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("UserMenuPermissionViewModel", "Request data is null.");
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
                var userMenuPermissionViewModel = GetById(id);
                if (userMenuPermissionViewModel != null)
                {
                    UserMenuPermission userMenuPermission = userMenuPermissionViewModel.ConvertViewModelToModel<UserMenuPermissionViewModel, UserMenuPermission>();
                    _iUserMenuPermissionRepository.Delete(userMenuPermission);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("UserMenuPermissionViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<UserMenuPermissionViewModel> userMenuPermissionViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var userMenuPermissionViewModel in userMenuPermissionViewModels)
                {
                    UserMenuPermissionViewModel viewModel = GetById(userMenuPermissionViewModel.Id);
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

    #region Interface : UserMenuPermission

    public interface IUserMenuPermissionService : IGeneric<UserMenuPermissionViewModel>
    {
        UserMenuPermissionViewModel GetUserMenuPermission(string userMenuPermissionName);

        int Delete(List<UserMenuPermissionViewModel> userMenuPermissionViewModels);

    }

    #endregion
}
