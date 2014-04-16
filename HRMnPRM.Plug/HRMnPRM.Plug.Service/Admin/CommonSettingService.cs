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
    #region Interface Implement : CommonSetting

    public class CommonSettingService : ICommonSettingService
    {
        #region Global Variable Declaration

        private readonly IRepository<CommonSetting> _iCommonSettingRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public CommonSettingService(IRepository<CommonSetting> iCommonSettingRepository, IUnitOfWork iUnitOfWork)
        {
            this._iCommonSettingRepository = iCommonSettingRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<CommonSettingViewModel> GetAll()
        {
            var commonSettingViewModels = new List<CommonSettingViewModel>();
            try
            {

                List<CommonSetting> commonSettings = _iCommonSettingRepository.GetAll();

                foreach (CommonSetting commonSetting in commonSettings)
                {
                    var commonSettingViewModel = commonSetting.ConvertModelToViewModel<CommonSetting, CommonSettingViewModel>();
                    commonSettingViewModels.Add(commonSettingViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return commonSettingViewModels.AsQueryable();
        }

        public CommonSettingViewModel GetCommonSetting(string commonSettingName)
        {
            var commonSettingViewModel = new CommonSettingViewModel();

            try
            {
                CommonSetting commonSetting = _iCommonSettingRepository.GetById(commonSettingName);
                commonSettingViewModel = commonSetting.ConvertModelToViewModel<CommonSetting, CommonSettingViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return commonSettingViewModel;
        }

        public CommonSettingViewModel GetById(long id)
        {
            var commonSettingViewModel = new CommonSettingViewModel();

            try
            {
                CommonSetting commonSetting = _iCommonSettingRepository.GetById(id);
                commonSettingViewModel = commonSetting.ConvertModelToViewModel<CommonSetting, CommonSettingViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return commonSettingViewModel;
        }

        #endregion

        #region Create Method

        public int Create(CommonSettingViewModel commonSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (commonSettingViewModel != null)
                {
                    CommonSetting commonSetting = commonSettingViewModel.ConvertViewModelToModel<CommonSettingViewModel, CommonSetting>();
                    _iCommonSettingRepository.Insert(commonSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("CommonSettingViewModel", "Request data is null.");
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

        public int Update(CommonSettingViewModel commonSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (commonSettingViewModel != null)
                {
                    CommonSetting commonSetting = commonSettingViewModel.ConvertViewModelToModel<CommonSettingViewModel, CommonSetting>();
                    _iCommonSettingRepository.Update(commonSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("CommonSettingViewModel", "Request data is null.");
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

        public int Delete(CommonSettingViewModel commonSettingViewModel)
        {
            int isSave = 0;
            try
            {
                if (commonSettingViewModel != null)
                {
                    var viewModel = GetById(commonSettingViewModel.Id);
                    CommonSetting commonSetting = viewModel.ConvertViewModelToModel<CommonSettingViewModel, CommonSetting>();
                    _iCommonSettingRepository.Delete(commonSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("CommonSettingViewModel", "Request data is null.");
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
                var commonSettingViewModel = GetById(id);
                if (commonSettingViewModel != null)
                {
                    CommonSetting commonSetting = commonSettingViewModel.ConvertViewModelToModel<CommonSettingViewModel, CommonSetting>();
                    _iCommonSettingRepository.Delete(commonSetting);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("CommonSettingViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<CommonSettingViewModel> commonSettingViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var commonSettingViewModel in commonSettingViewModels)
                {
                    CommonSettingViewModel viewModel = GetById(commonSettingViewModel.Id);
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

    #region Interface : CommonSetting

    public interface ICommonSettingService : IGeneric<CommonSettingViewModel>
    {
        CommonSettingViewModel GetCommonSetting(string commonSettingName);

        int Delete(List<CommonSettingViewModel> commonSettingViewModels);

    }

    #endregion
}
