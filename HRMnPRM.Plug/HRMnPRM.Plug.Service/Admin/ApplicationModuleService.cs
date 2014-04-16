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
    #region Interface Implement : ApplicationModule

    public class ApplicationModuleService : IApplicationModuleService
    {
        #region Global Variable Declaration

        private readonly IRepository<ApplicationModule> _iApplicationModuleRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public ApplicationModuleService(IRepository<ApplicationModule> iApplicationModuleRepository, IUnitOfWork iUnitOfWork)
        {
            this._iApplicationModuleRepository = iApplicationModuleRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<ApplicationModuleViewModel> GetAll()
        {
            var applicationModuleViewModels = new List<ApplicationModuleViewModel>();
            try
            {

                List<ApplicationModule> applicationModules = _iApplicationModuleRepository.GetAll();

                foreach (ApplicationModule applicationModule in applicationModules)
                {
                    var applicationModuleViewModel = applicationModule.ConvertModelToViewModel<ApplicationModule, ApplicationModuleViewModel>();
                    applicationModuleViewModels.Add(applicationModuleViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicationModuleViewModels.AsQueryable();
        }

        public ApplicationModuleViewModel GetApplicationModule(string applicationModuleName)
        {
            var applicationModuleViewModel = new ApplicationModuleViewModel();

            try
            {
                ApplicationModule applicationModule = _iApplicationModuleRepository.GetById(applicationModuleName);
                applicationModuleViewModel = applicationModule.ConvertModelToViewModel<ApplicationModule, ApplicationModuleViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationModuleViewModel;
        }

        public ApplicationModuleViewModel GetById(long id)
        {
            var applicationModuleViewModel = new ApplicationModuleViewModel();

            try
            {
                ApplicationModule applicationModule = _iApplicationModuleRepository.GetById(id);
                applicationModuleViewModel = applicationModule.ConvertModelToViewModel<ApplicationModule, ApplicationModuleViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationModuleViewModel;
        }

        #endregion

        #region Create Method

        public int Create(ApplicationModuleViewModel applicationModuleViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationModuleViewModel != null)
                {
                    ApplicationModule applicationModule = applicationModuleViewModel.ConvertViewModelToModel<ApplicationModuleViewModel, ApplicationModule>();
                    _iApplicationModuleRepository.Insert(applicationModule);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationModuleViewModel", "Request data is null.");
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

        public int Update(ApplicationModuleViewModel applicationModuleViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationModuleViewModel != null)
                {
                    ApplicationModule applicationModule = applicationModuleViewModel.ConvertViewModelToModel<ApplicationModuleViewModel, ApplicationModule>();
                    _iApplicationModuleRepository.Update(applicationModule);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationModuleViewModel", "Request data is null.");
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

        public int Delete(ApplicationModuleViewModel applicationModuleViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationModuleViewModel != null)
                {
                    var viewModel = GetById(applicationModuleViewModel.Id);
                    ApplicationModule applicationModule = viewModel.ConvertViewModelToModel<ApplicationModuleViewModel, ApplicationModule>();
                    _iApplicationModuleRepository.Delete(applicationModule);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationModuleViewModel", "Request data is null.");
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
                var applicationModuleViewModel = GetById(id);
                if (applicationModuleViewModel != null)
                {
                    ApplicationModule applicationModule = applicationModuleViewModel.ConvertViewModelToModel<ApplicationModuleViewModel, ApplicationModule>();
                    _iApplicationModuleRepository.Delete(applicationModule);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationModuleViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<ApplicationModuleViewModel> applicationModuleViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var applicationModuleViewModel in applicationModuleViewModels)
                {
                    ApplicationModuleViewModel viewModel = GetById(applicationModuleViewModel.Id);
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

    #region Interface : ApplicationModule

    public interface IApplicationModuleService : IGeneric<ApplicationModuleViewModel>
    {
        ApplicationModuleViewModel GetApplicationModule(string applicationModuleName);

        int Delete(List<ApplicationModuleViewModel> applicationModuleViewModels);

    }

    #endregion
}
