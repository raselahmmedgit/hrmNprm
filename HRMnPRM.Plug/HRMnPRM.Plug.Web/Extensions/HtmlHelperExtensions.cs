using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HRMnPRM.Plug.Core;

public static class HtmlHelperExtensions
{
    #region Message Helpers

    public static IHtmlString RenderMessages(this HtmlHelper htmlHelper)
    {
        var messages = String.Empty;
        foreach (var messageType in Enum.GetNames(typeof(MessageType)))
        {
            var message = htmlHelper.ViewContext.ViewData.ContainsKey(messageType)
                            ? htmlHelper.ViewContext.ViewData[messageType]
                            : htmlHelper.ViewContext.TempData.ContainsKey(messageType)
                                ? htmlHelper.ViewContext.TempData[messageType]
                                : null;
            if (message != null)
            {
                messages += "<div class='" + messageType.ToString().ToLower() + "'>" + message + "</div>";
            }
        }

        return MvcHtmlString.Create(messages);
    }

    #endregion

    #region Wrapper Panels

    #region Primitive Controls

    public static IHtmlString EditorCalenderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        Func<TModel, TProperty> deleg = expression.Compile();
        var result = deleg(htmlHelper.ViewData.Model);

        string value = null;

        if (result.ToString() == DateTime.MinValue.ToString())
            value = string.Empty;
        else
            value = string.Format("{0:M/dd/yyyy}", result);

        return htmlHelper.TextBoxFor(expression, new { @class = "datepicker text", Value = value });
    }

    public static IHtmlString RequiredSymbolFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string symbol = "* ")
    {
        ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

        if (modelMetadata.IsRequired)
        {
            return MvcHtmlString.Create(symbol);
        }

        return MvcHtmlString.Create(string.Empty);
    }

    #endregion

    #region Panel Controls

    public static IHtmlString EditorCalenderPanelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        return BuildEditorPanelFor(htmlHelper, expression, htmlHelper.EditorCalenderFor(expression));
    }

    public static IHtmlString EditorPanelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        return BuildEditorPanelFor(htmlHelper, expression, htmlHelper.EditorFor(expression));
    }

    public static IHtmlString EditorDropdownPanelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    {
        return BuildEditorPanelFor(htmlHelper, expression, htmlHelper.DropDownListFor(expression, selectList, optionLabel));
    }

    #endregion

    #region Panel Builders

    static IHtmlString BuildEditorPanelFor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IHtmlString editorForString)
    {
        IHtmlString labelForString = htmlHelper.LabelFor(expression);
        IHtmlString requiredSymbolFor = htmlHelper.RequiredSymbolFor(expression);
        IHtmlString validationMessageForString = htmlHelper.ValidationMessageFor(expression);

        IHtmlString outout = MvcHtmlString.Create(
            labelForString.ToHtmlString() + ":" + requiredSymbolFor.ToHtmlString() + "<br class=\"clear\" />" +
            editorForString.ToHtmlString() + "<br class=\"clear\" />" +
            validationMessageForString.ToHtmlString() + "<br class=\"clear\" />");

        return outout;
    }

    #endregion

    #endregion

    #region Theme

    public static IHtmlString RenderTitle(this HtmlHelper htmlHelper)
    {
        var title = String.Empty;

        var viewDataTitle = htmlHelper.ViewContext.ViewData["Title"] == null ? null : htmlHelper.ViewContext.ViewData["Title"];
        if (viewDataTitle != null)
        {
            var tempTitle = viewDataTitle;
            title += tempTitle;

            htmlHelper.ViewContext.ViewData["Title"] = null;
        }

        return MvcHtmlString.Create(title);
    }

    public static IHtmlString RenderTheme(this HtmlHelper htmlHelper)
    {
        string themePath = String.Empty;
        string themeCookies = String.Empty;

        //string cssPath = @"switcher.css";
        //string cssPath = @"switcher";

        HttpContext httpContext = System.Web.HttpContext.Current;

        if (httpContext.Request.Cookies["CookieTheme"] != null)
        {
            themeCookies += httpContext.Request.Cookies["CookieTheme"].Value.ToString();
        }

        if (!String.IsNullOrEmpty(themeCookies))
        {
            themePath += themeCookies;
        }

        return MvcHtmlString.Create(themePath);
    }

    public static IHtmlString RenderColour(this HtmlHelper htmlHelper)
    {
        string themePath = String.Empty;
        string themeCookies = String.Empty;

        //string cssPath = @"switcher.css";
        //string cssPath = @"switcher";

        HttpContext httpContext = System.Web.HttpContext.Current;

        if (httpContext.Request.Cookies["CookieColour"] != null)
        {
            themeCookies += httpContext.Request.Cookies["CookieColour"].Value.ToString();
        }

        if (!String.IsNullOrEmpty(themeCookies))
        {
            themePath += themeCookies;
        }

        return MvcHtmlString.Create(themePath);
    }

    public static IHtmlString RenderLayout(this HtmlHelper htmlHelper)
    {
        string layoutPath = String.Empty;
        string layoutCookies = String.Empty;

        //string cssPath = @"switcher.css";
        //string cssPath = @"switcher";

        HttpContext httpContext = System.Web.HttpContext.Current;

        if (httpContext.Request.Cookies["CookieLayout"] != null)
        {
            layoutCookies += httpContext.Request.Cookies["CookieLayout"].Value.ToString();
        }

        if (!String.IsNullOrEmpty(layoutCookies))
        {
            layoutPath += layoutCookies;
        }

        return MvcHtmlString.Create(layoutPath);
    }

    public static IHtmlString RenderHeader(this HtmlHelper htmlHelper)
    {
        string headerPath = String.Empty;
        string headerCookies = String.Empty;

        //string cssPath = @"switcher.css";
        //string cssPath = @"switcher";

        HttpContext httpContext = System.Web.HttpContext.Current;

        if (httpContext.Request.Cookies["CookieHeader"] != null)
        {
            headerCookies += httpContext.Request.Cookies["CookieHeader"].Value.ToString();
        }

        if (!String.IsNullOrEmpty(headerCookies))
        {
            headerPath += headerCookies;
        }

        return MvcHtmlString.Create(headerPath);
    }

    public static IHtmlString RenderBackGround(this HtmlHelper htmlHelper)
    {
        string bgPath = String.Empty;
        string bgCookies = String.Empty;

        //string cssPath = @"switcher.css";
        //string cssPath = @"switcher";

        HttpContext httpContext = System.Web.HttpContext.Current;

        if (httpContext.Request.Cookies["CookieBackGround"] != null)
        {
            bgCookies += httpContext.Request.Cookies["CookieBackGround"].Value.ToString();
        }

        if (!String.IsNullOrEmpty(bgCookies))
        {
            bgPath += bgCookies;
        }

        return MvcHtmlString.Create(bgPath);
    }

    #endregion

    #region Breadcrumb

    public static IHtmlString RenderBreadcrumb(this HtmlHelper htmlHelper)
    {
        var title = String.Empty;

        var viewDataTitle = htmlHelper.ViewContext.ViewData["Title"] == null ? null : htmlHelper.ViewContext.ViewData["Title"];
        if (viewDataTitle != null)
        {
            var tempTitle = viewDataTitle;
            title += tempTitle;

            htmlHelper.ViewContext.ViewData["Title"] = null;
        }

        return MvcHtmlString.Create(title);
    }

    #endregion

    #region Menu

    public static IHtmlString RenderMenu(this HtmlHelper htmlHelper)
    {
        var title = String.Empty;

        var viewDataTitle = htmlHelper.ViewContext.ViewData["Title"] == null ? null : htmlHelper.ViewContext.ViewData["Title"];
        if (viewDataTitle != null)
        {
            var tempTitle = viewDataTitle;
            title += tempTitle;

            htmlHelper.ViewContext.ViewData["Title"] = null;
        }

        return MvcHtmlString.Create(title);
    }

    public static IHtmlString RenderSideMenu(this HtmlHelper htmlHelper)
    {
        var title = String.Empty;

        var viewDataTitle = htmlHelper.ViewContext.ViewData["Title"] == null ? null : htmlHelper.ViewContext.ViewData["Title"];
        if (viewDataTitle != null)
        {
            var tempTitle = viewDataTitle;
            title += tempTitle;

            htmlHelper.ViewContext.ViewData["Title"] = null;
        }

        return MvcHtmlString.Create(title);
    }

    #endregion
}