using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using HRMnPRM.Plug.Core;
using HRMnPRM.Plug.Data;
using HRMnPRM.Plug.Domain;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Service
{
    #region Interface Implement : User

    public class UserService : IUserService
    {
        #region Global Variable Declaration

        private readonly IRepository<User> _iUserRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public UserService(IRepository<User> iUserRepository, IUnitOfWork iUnitOfWork)
        {
            this._iUserRepository = iUserRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<UserViewModel> GetAll()
        {
            var userViewModels = new List<UserViewModel>();
            try
            {

                List<User> users = _iUserRepository.GetAll();

                foreach (User user in users)
                {
                    var userViewModel = user.ConvertModelToViewModel<User, UserViewModel>();
                    userViewModels.Add(userViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userViewModels.AsQueryable();
        }

        //public IQueryable<UserViewModel> GetLoggedInUsers()
        //{
        //    var userViewModels = new List<UserViewModel>();
        //    try
        //    {
        //        List<User> users = _iUserRepository.GetAll().Where(x => x.IsLoggedIn == true).ToList();

        //        foreach (User user in users)
        //        {
        //            var userViewModel = user.ConvertModelToViewModel<User, UserViewModel>();
        //            userViewModels.Add(userViewModel);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return userViewModels.AsQueryable();
        //}

        public UserViewModel GetUser(string userName)
        {
            var userViewModel = new UserViewModel();

            try
            {
                User user = _iUserRepository.GetById(userName);
                userViewModel = user.ConvertModelToViewModel<User, UserViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userViewModel;
        }

        public UserViewModel GetById(long id)
        {
            var userViewModel = new UserViewModel();

            try
            {
                User user = _iUserRepository.GetById(id);
                userViewModel = user.ConvertModelToViewModel<User, UserViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userViewModel;
        }

        #endregion

        #region Create Method

        public int Create(UserViewModel userViewModel)
        {
            int isSave = 0;
            try
            {
                if (userViewModel != null)
                {
                    User user = userViewModel.ConvertViewModelToModel<UserViewModel, User>();
                    _iUserRepository.Insert(user);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("userViewModel", "Request data is null.");
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

        public int Update(UserViewModel userViewModel)
        {
            int isSave = 0;
            try
            {
                if (userViewModel != null)
                {
                    User user = userViewModel.ConvertViewModelToModel<UserViewModel, User>();
                    _iUserRepository.Update(user);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("userViewModel", "Request data is null.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int AddUserToRole(string userName, List<string> roleNames)
        {
            int isSave = 0;
            try
            {
                //_iUserRepository.AssignRole(userName, roleNames);
                isSave = Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        //public int ChangeUserLogInStatus(UserViewModel userViewModel, bool inout)
        //{
        //    int isSave = 0;
        //    try
        //    {
        //        User user = _iUserRepository.GetById(userViewModel.UserName);
        //        if (user != null)
        //        {
        //            user.IsLoggedIn = inout;
        //            _iUserRepository.Update(user);
        //            isSave = Save();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return isSave;
        //}

        #endregion

        #region Delete Method

        public int Delete(UserViewModel userViewModel)
        {
            int isSave = 0;
            try
            {
                if (userViewModel != null)
                {
                    var viewModel = GetUser(userViewModel.UserName);
                    User user = viewModel.ConvertViewModelToModel<UserViewModel, User>();
                    _iUserRepository.Delete(user);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("userViewModel", "Request data is null.");
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
                var userViewModel = GetById(id);
                if (userViewModel != null)
                {
                    User user = userViewModel.ConvertViewModelToModel<UserViewModel, User>();
                    _iUserRepository.Delete(user);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("userViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<UserViewModel> userViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var userViewModel in userViewModels)
                {
                    UserViewModel viewModel = GetById(userViewModel.Id);
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

        #region Reset Password

        //Reset Password
        public bool ForgetPassword(UserViewModel userViewModel)
        {
            bool isSend = false;
            try
            {
                if (!String.IsNullOrEmpty(userViewModel.Email))
                {
                    SendResetEmail(userViewModel);
                    return isSend = true;
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (MembershipPasswordException ex)
            {
                throw ex;
            }
            return isSend;
        }

        //Send Email Method
        public void SendResetEmail(UserViewModel userViewModel)
        {
            //    string mailBody = GetResetEmailBody(userViewModel.UserName);
            //    const string mailSubject = "Your new password";
            //    const string mailFrom = "rasel@syntechbd.com";
            //    string mailTo = userViewModel.Email;
            //    MailService mailService = new MailService();

            //    MailServiceResult mailResult = mailService.SendEmail(mailTo, mailFrom, mailSubject, mailBody);
        }

        public string HashResetParams(string username)
        {
            byte[] bytesofLink = Encoding.UTF8.GetBytes(username);
            MD5 md5 = new MD5CryptoServiceProvider();
            string hashParams = BitConverter.ToString(md5.ComputeHash(bytesofLink));

            return hashParams;
        }

        private string GetResetEmailBody(string userName)
        {
            string link = "http://www.syntechbd.com/Account/ResetPassword/?username=" + userName + "&reset=" + HashResetParams(userName);

            string mailBody = "<p>Hi " + userName + "," + "</p>";
            mailBody += "<p>You just requested a new password for your my regfire account.</p>";
            mailBody += "---------------------------------------------------------------------------</br>";
            mailBody += "For creating a new password please click on the following link:</br>";
            mailBody += "<a href='" + link + "'>" + link + "</a></br>";
            mailBody += "---------------------------------------------------------------------------</br>";
            mailBody += "<p>Please keep your password safe to prevent unathorized access.</p>";
            mailBody += "---------------------</br>";
            mailBody += "Property Management</br>";
            mailBody += "Our Slogan</br>";
            mailBody += "---------------------</br>";
            mailBody += @"<p>http://www.syntechbd.com/</p>";
            mailBody += @"<p>&copy; " + DateTime.Now.Year + " - Syntech BD | Syntech Ltd. - Bangladesh</p>";

            return mailBody;
        }

        #endregion

    }

    #endregion

    #region Interface : User

    public interface IUserService : IGeneric<UserViewModel>
    {
        //IQueryable<UserViewModel> GetLoggedInUsers();

        UserViewModel GetUser(string userName);

        int Delete(List<UserViewModel> userViewModels);

        //int ChangeUserLogInStatus(UserViewModel userViewModel, bool inout);

        //int AddUserToRole(string userName, List<string> roleNames);

        bool ForgetPassword(UserViewModel userViewModel);

        string HashResetParams(string userName);
    }

    #endregion
}
