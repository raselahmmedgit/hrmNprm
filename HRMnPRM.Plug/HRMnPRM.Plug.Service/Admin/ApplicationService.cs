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
    #region Interface Implement : Application

    public class ApplicationService : IApplicationService
    {
        #region Global Variable Declaration

        private readonly IRepository<Application> _iApplicationRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public ApplicationService(IRepository<Application> iApplicationRepository, IUnitOfWork iUnitOfWork)
        {
            this._iApplicationRepository = iApplicationRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<ApplicationViewModel> GetAll()
        {
            var applicationViewModels = new List<ApplicationViewModel>();
            try
            {

                List<Application> applications = _iApplicationRepository.GetAll();

                foreach (Application application in applications)
                {
                    var applicationViewModel = application.ConvertModelToViewModel<Application, ApplicationViewModel>();
                    applicationViewModels.Add(applicationViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return applicationViewModels.AsQueryable();
        }

        public ApplicationViewModel GetApplication(string applicationName)
        {
            var applicationViewModel = new ApplicationViewModel();

            try
            {
                Application application = _iApplicationRepository.GetById(applicationName);
                applicationViewModel = application.ConvertModelToViewModel<Application, ApplicationViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationViewModel;
        }

        public ApplicationViewModel GetById(long id)
        {
            var applicationViewModel = new ApplicationViewModel();

            try
            {
                Application application = _iApplicationRepository.GetById(id);
                applicationViewModel = application.ConvertModelToViewModel<Application, ApplicationViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return applicationViewModel;
        }

        #endregion

        #region Create Method

        public int Create(ApplicationViewModel applicationViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationViewModel != null)
                {
                    Application application = applicationViewModel.ConvertViewModelToModel<ApplicationViewModel, Application>();
                    _iApplicationRepository.Insert(application);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationViewModel", "Request data is null.");
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

        public int Update(ApplicationViewModel applicationViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationViewModel != null)
                {
                    Application application = applicationViewModel.ConvertViewModelToModel<ApplicationViewModel, Application>();
                    _iApplicationRepository.Update(application);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationViewModel", "Request data is null.");
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

        public int Delete(ApplicationViewModel applicationViewModel)
        {
            int isSave = 0;
            try
            {
                if (applicationViewModel != null)
                {
                    var viewModel = GetApplication(applicationViewModel.ApplicationName);
                    Application application = viewModel.ConvertViewModelToModel<ApplicationViewModel, Application>();
                    _iApplicationRepository.Delete(application);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationViewModel", "Request data is null.");
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
                var applicationViewModel = GetById(id);
                if (applicationViewModel != null)
                {
                    Application application = applicationViewModel.ConvertViewModelToModel<ApplicationViewModel, Application>();
                    _iApplicationRepository.Delete(application);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ApplicationViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<ApplicationViewModel> applicationViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var applicationViewModel in applicationViewModels)
                {
                    ApplicationViewModel viewModel = GetById(applicationViewModel.Id);
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

    #region Interface : Application

    public interface IApplicationService : IGeneric<ApplicationViewModel>
    {
        ApplicationViewModel GetApplication(string applicationName);

        int Delete(List<ApplicationViewModel> applicationViewModels);

    }

    #endregion
}
