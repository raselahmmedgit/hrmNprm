using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HRMnPRM.Plug.Core
{
    public static class ModelExtension
    {
        public static TViewModel ConvertModelToViewModel<TModel, TViewModel>(this TModel model)
            where TViewModel : BaseViewModel
            where TModel : BaseModel
        {
            Mapper.CreateMap<TModel, TViewModel>();
            var viewModel = Mapper.Map<TModel, TViewModel>(model);
            return viewModel;
        }

        public static TModel ConvertViewModelToModel<TViewModel, TModel>(this TViewModel viewModel)
            where TViewModel : BaseViewModel
            where TModel : BaseModel
        {
            Mapper.CreateMap<TViewModel, TModel>();
            var model = Mapper.Map<TViewModel, TModel>(viewModel);
            return model;
        }

    }
}
