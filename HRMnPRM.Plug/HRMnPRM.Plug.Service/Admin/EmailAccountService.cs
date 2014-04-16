using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;
using HRMnPRM.Plug.Data;
using HRMnPRM.Plug.Domain;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Service.Admin
{
    #region Interface Implement : EmailAccount

    public class EmailAccountService : IEmailAccountService
    {
        #region Global Variable Declaration

        private readonly IRepository<EmailAccount> _iEmailAccountRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public EmailAccountService(IRepository<EmailAccount> iEmailAccountRepository, IUnitOfWork iUnitOfWork)
        {
            this._iEmailAccountRepository = iEmailAccountRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<EmailAccountViewModel> GetAll()
        {
            var emailAccountViewModels = new List<EmailAccountViewModel>();
            try
            {

                List<EmailAccount> emailAccounts = _iEmailAccountRepository.GetAll();

                foreach (EmailAccount emailAccount in emailAccounts)
                {
                    var emailAccountViewModel = emailAccount.ConvertModelToViewModel<EmailAccount, EmailAccountViewModel>();
                    emailAccountViewModels.Add(emailAccountViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emailAccountViewModels.AsQueryable();
        }

        public EmailAccountViewModel GetEmailAccount(string emailAccountName)
        {
            var emailAccountViewModel = new EmailAccountViewModel();

            try
            {
                EmailAccount emailAccount = _iEmailAccountRepository.GetById(emailAccountName);
                emailAccountViewModel = emailAccount.ConvertModelToViewModel<EmailAccount, EmailAccountViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emailAccountViewModel;
        }

        public EmailAccountViewModel GetById(long id)
        {
            var emailAccountViewModel = new EmailAccountViewModel();

            try
            {
                EmailAccount emailAccount = _iEmailAccountRepository.GetById(id);
                emailAccountViewModel = emailAccount.ConvertModelToViewModel<EmailAccount, EmailAccountViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emailAccountViewModel;
        }

        #endregion

        #region Create Method

        public int Create(EmailAccountViewModel emailAccountViewModel)
        {
            int isSave = 0;
            try
            {
                if (emailAccountViewModel != null)
                {
                    EmailAccount emailAccount = emailAccountViewModel.ConvertViewModelToModel<EmailAccountViewModel, EmailAccount>();
                    _iEmailAccountRepository.Insert(emailAccount);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("EmailAccountViewModel", "Request data is null.");
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

        public int Update(EmailAccountViewModel emailAccountViewModel)
        {
            int isSave = 0;
            try
            {
                if (emailAccountViewModel != null)
                {
                    EmailAccount emailAccount = emailAccountViewModel.ConvertViewModelToModel<EmailAccountViewModel, EmailAccount>();
                    _iEmailAccountRepository.Update(emailAccount);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("EmailAccountViewModel", "Request data is null.");
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

        public int Delete(EmailAccountViewModel emailAccountViewModel)
        {
            int isSave = 0;
            try
            {
                if (emailAccountViewModel != null)
                {
                    var viewModel = GetById(emailAccountViewModel.Id);
                    EmailAccount emailAccount = viewModel.ConvertViewModelToModel<EmailAccountViewModel, EmailAccount>();
                    _iEmailAccountRepository.Delete(emailAccount);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("EmailAccountViewModel", "Request data is null.");
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
                var emailAccountViewModel = GetById(id);
                if (emailAccountViewModel != null)
                {
                    EmailAccount emailAccount = emailAccountViewModel.ConvertViewModelToModel<EmailAccountViewModel, EmailAccount>();
                    _iEmailAccountRepository.Delete(emailAccount);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("EmailAccountViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<EmailAccountViewModel> emailAccountViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var emailAccountViewModel in emailAccountViewModels)
                {
                    EmailAccountViewModel viewModel = GetById(emailAccountViewModel.Id);
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

    #region Interface : EmailAccount

    public interface IEmailAccountService : IGeneric<EmailAccountViewModel>
    {
        EmailAccountViewModel GetEmailAccount(string emailAccountName);

        int Delete(List<EmailAccountViewModel> emailAccountViewModels);

    }

    #endregion
}
