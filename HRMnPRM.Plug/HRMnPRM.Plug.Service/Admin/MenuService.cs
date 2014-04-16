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
    #region Interface Implement : Menu

    public class MenuService : IMenuService
    {
        #region Global Variable Declaration

        private readonly IRepository<Menu> _iMenuRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructor

        public MenuService(IRepository<Menu> iMenuRepository, IUnitOfWork iUnitOfWork)
        {
            this._iMenuRepository = iMenuRepository;
            this._iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Method

        public IQueryable<MenuViewModel> GetAll()
        {
            var menuViewModels = new List<MenuViewModel>();
            try
            {

                List<Menu> menus = _iMenuRepository.GetAll();

                foreach (Menu menu in menus)
                {
                    var menuViewModel = menu.ConvertModelToViewModel<Menu, MenuViewModel>();
                    menuViewModels.Add(menuViewModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menuViewModels.AsQueryable();
        }

        public MenuViewModel GetMenu(string menuName)
        {
            var menuViewModel = new MenuViewModel();

            try
            {
                Menu menu = _iMenuRepository.GetById(menuName);
                menuViewModel = menu.ConvertModelToViewModel<Menu, MenuViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return menuViewModel;
        }

        public MenuViewModel GetById(long id)
        {
            var menuViewModel = new MenuViewModel();

            try
            {
                Menu menu = _iMenuRepository.GetById(id);
                menuViewModel = menu.ConvertModelToViewModel<Menu, MenuViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return menuViewModel;
        }

        #endregion

        #region Create Method

        public int Create(MenuViewModel menuViewModel)
        {
            int isSave = 0;
            try
            {
                if (menuViewModel != null)
                {
                    Menu menu = menuViewModel.ConvertViewModelToModel<MenuViewModel, Menu>();
                    _iMenuRepository.Insert(menu);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("MenuViewModel", "Request data is null.");
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

        public int Update(MenuViewModel menuViewModel)
        {
            int isSave = 0;
            try
            {
                if (menuViewModel != null)
                {
                    Menu menu = menuViewModel.ConvertViewModelToModel<MenuViewModel, Menu>();
                    _iMenuRepository.Update(menu);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("MenuViewModel", "Request data is null.");
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

        public int Delete(MenuViewModel menuViewModel)
        {
            int isSave = 0;
            try
            {
                if (menuViewModel != null)
                {
                    var viewModel = GetMenu(menuViewModel.MenuName);
                    Menu menu = viewModel.ConvertViewModelToModel<MenuViewModel, Menu>();
                    _iMenuRepository.Delete(menu);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("MenuViewModel", "Request data is null.");
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
                var menuViewModel = GetById(id);
                if (menuViewModel != null)
                {
                    Menu menu = menuViewModel.ConvertViewModelToModel<MenuViewModel, Menu>();
                    _iMenuRepository.Delete(menu);
                    isSave = Save();
                }
                else
                {
                    throw new ArgumentNullException("MenuViewModel", "Request data is null.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSave;
        }

        public int Delete(List<MenuViewModel> menuViewModels)
        {
            int isSave = 0;
            try
            {
                foreach (var menuViewModel in menuViewModels)
                {
                    MenuViewModel viewModel = GetById(menuViewModel.Id);
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

    #region Interface : Menu

    public interface IMenuService : IGeneric<MenuViewModel>
    {
        MenuViewModel GetMenu(string menuName);

        int Delete(List<MenuViewModel> menuViewModels);

    }

    #endregion
}
