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
    #region Interface Implement : ApplicationSetting

    public class ApplicationSettingService : IApplicationSettingService
    {
        #region Global Variable Declaration

        private readonly IRepository<ApplicationSetting> _iApplicationSettingRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public ApplicationSettingService(IRepository<ApplicationSetting> iApplicationSettingRepository, IUnitOfWork iUnitOfWork)
        {
            this._iApplicationSettingRepository = iApplicationSettingRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<ApplicationSettingViewModel> GetAll()
        {
            var applicationSettingViewModels = new List<ApplicationSettingViewModel>();
            try
            {

                List<ApplicationSetting> applicationSettings = _iApplicationSettingRepository.GetAll();

                foreach (ApplicationSetting applicationSetting in applicationSettings)
                {
                    var applicationSettingViewModel = applicationSetting.ConvertModelToViewModel<ApplicationSetting, ApplicationSettingViewModel>();
                    applicationSettingViewModels.Add(applicationSettingViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicationSettingViewModels.AsQueryable();
        }

        public ApplicationSettingViewModel GetApplicationSetting(string applicationSettingName)
        {
            var applicationSettingViewModel = new ApplicationSettingViewModel();

            try
            {
                ApplicationSetting applicationSetting = _iApplicationSettingRepository.GetById(applicationSettingName);
                applicationSettingViewModel = applicationSetting.ConvertModelToViewModel<ApplicationSetting, ApplicationSettingViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationSettingViewModel;
        }

        public ApplicationSettingViewModel GetById(long id)
        {
            var applicationSettingViewModel = new ApplicationSettingViewModel();

            try
            {
                ApplicationSetting applicationSetting = _iApplicationSettingRepository.GetById(id);
                applicationSettingViewModel = applicationSetting.ConvertModelToViewModel<ApplicationSetting, ApplicationSettingViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationSettingViewModel;
        }

        #endregion

        #region Create Method

        public int Create(ApplicationSettingViewModel applicationSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationSettingViewModel != null)
                {
                    ApplicationSetting applicationSetting = applicationSettingViewModel.ConvertViewModelToModel<ApplicationSettingViewModel, ApplicationSetting>();
                    _iApplicationSettingRepository.Insert(applicationSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationSettingViewModel", "Request data is null.");
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

        public int Update(ApplicationSettingViewModel applicationSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationSettingViewModel != null)
                {
                    ApplicationSetting applicationSetting = applicationSettingViewModel.ConvertViewModelToModel<ApplicationSettingViewModel, ApplicationSetting>();
                    _iApplicationSettingRepository.Update(applicationSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationSettingViewModel", "Request data is null.");
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

        public int Delete(ApplicationSettingViewModel applicationSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationSettingViewModel != null)
                {
                    var viewModel = GetById(applicationSettingViewModel.Id);
                    ApplicationSetting applicationSetting = viewModel.ConvertViewModelToModel<ApplicationSettingViewModel, ApplicationSetting>();
                    _iApplicationSettingRepository.Delete(applicationSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationSettingViewModel", "Request data is null.");
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
                var applicationSettingViewModel = GetById(id);
                if (applicationSettingViewModel != null)
                {
                    ApplicationSetting applicationSetting = applicationSettingViewModel.ConvertViewModelToModel<ApplicationSettingViewModel, ApplicationSetting>();
                    _iApplicationSettingRepository.Delete(applicationSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationSettingViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<ApplicationSettingViewModel> applicationSettingViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var applicationSettingViewModel in applicationSettingViewModels)
                {
                    ApplicationSettingViewModel viewModel = GetById(applicationSettingViewModel.Id);
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

    #region Interface : ApplicationSetting

    public interface IApplicationSettingService : IGeneric<ApplicationSettingViewModel>
    {
        ApplicationSettingViewModel GetApplicationSetting(string applicationSettingName);

        int Delete(List<ApplicationSettingViewModel> applicationSettingViewModels);

    }

    #endregion
}
