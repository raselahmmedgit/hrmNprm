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
    #region Interface Implement : Profile

    public class ProfileService : IProfileService
    {
        #region Global Variable Declaration

        private readonly IRepository<Profile> _iProfileRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public ProfileService(IRepository<Profile> iProfileRepository, IUnitOfWork iUnitOfWork)
        {
            this._iProfileRepository = iProfileRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<ProfileViewModel> GetAll()
        {
            var profileViewModels = new List<ProfileViewModel>();
            try
            {

                List<Profile> profiles = _iProfileRepository.GetAll();

                foreach (Profile profile in profiles)
                {
                    var profileViewModel = profile.ConvertModelToViewModel<Profile, ProfileViewModel>();
                    profileViewModels.Add(profileViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return profileViewModels.AsQueryable();
        }

        public ProfileViewModel GetProfile(string profileName)
        {
            var profileViewModel = new ProfileViewModel();

            try
            {
                Profile profile = _iProfileRepository.GetById(profileName);
                profileViewModel = profile.ConvertModelToViewModel<Profile, ProfileViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return profileViewModel;
        }

        public ProfileViewModel GetById(long id)
        {
            var profileViewModel = new ProfileViewModel();

            try
            {
                Profile profile = _iProfileRepository.GetById(id);
                profileViewModel = profile.ConvertModelToViewModel<Profile, ProfileViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return profileViewModel;
        }

        #endregion

        #region Create Method

        public int Create(ProfileViewModel profileViewModel)
        {
            int isSave = 0;
            try
            {
                if (profileViewModel != null)
                {
                    Profile profile = profileViewModel.ConvertViewModelToModel<ProfileViewModel, Profile>();
                    _iProfileRepository.Insert(profile);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ProfileViewModel", "Request data is null.");
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

        public int Update(ProfileViewModel profileViewModel)
        {
            int isSave = 0;
            try
            {
                if (profileViewModel != null)
                {
                    Profile profile = profileViewModel.ConvertViewModelToModel<ProfileViewModel, Profile>();
                    _iProfileRepository.Update(profile);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ProfileViewModel", "Request data is null.");
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

        public int Delete(ProfileViewModel profileViewModel)
        {
            int isSave = 0;
            try
            {
                if (profileViewModel != null)
                {
                    var viewModel = GetById(profileViewModel.Id);
                    Profile profile = viewModel.ConvertViewModelToModel<ProfileViewModel, Profile>();
                    _iProfileRepository.Delete(profile);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ProfileViewModel", "Request data is null.");
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
                var profileViewModel = GetById(id);
                if (profileViewModel != null)
                {
                    Profile profile = profileViewModel.ConvertViewModelToModel<ProfileViewModel, Profile>();
                    _iProfileRepository.Delete(profile);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("ProfileViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<ProfileViewModel> profileViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var profileViewModel in profileViewModels)
                {
                    ProfileViewModel viewModel = GetById(profileViewModel.Id);
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

    #region Interface : Profile

    public interface IProfileService : IGeneric<ProfileViewModel>
    {
        ProfileViewModel GetProfile(string profileName);

        int Delete(List<ProfileViewModel> profileViewModels);

    }

    #endregion
}
