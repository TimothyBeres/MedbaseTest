using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Open.Core;

namespace Open.Sentry1.Extensions
{
    public static class HtmlExtension
    {
        public static IHtmlContent EditingControlsForEnum<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            var selectList = new SelectList(Enum.GetNames(typeof(TResult)));
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"}),
                new HtmlString("<div class=\"col-md-4\">"),
                htmlHelper.DropDownListFor(expression, selectList, new {@class = "form-control"}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditingControlsFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            var htmlStrings = new List<object>
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"}),
                new HtmlString("<div class=\"col-md-10\">"),
                htmlHelper.EditorFor(expression, new {htmlAttributes = new {@class = "form-control"}}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent ViewingControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            var htmlStrings = new List<object>
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"}),
                new HtmlString("<div class=\"col-md-10\" style=\"margin-top:10px\">"),
                htmlHelper.DisplayFor(expression,
                    new {htmlAttributes = new {@class = "form-control"}}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent SortColumnHeaderFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, object sortString,
            Expression<Func<TModel, TResult>> expression)
        {
            var linkName = htmlHelper.DisplayNameFor(expression);
            string action = "Index";
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink(linkName, action, new {SortOrder = sortString}),
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditDetailDeleteFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            string edit = "Edit";
            string details = "Details";
            string delete = "Delete";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Muuda", edit, new {id = index}),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Detailid", details, new {id = index}),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Eemalda", delete, new {id = index}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }
        public static IHtmlContent DetailForMedicine<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            string details = "Details";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Toimeained ravimis", details, new {id = index}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }
        public static IHtmlContent DetailForPerson<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            string details = "Details";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Detailid", details, new {id = index}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }
        public static IHtmlContent EditFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            string edit = "Edit";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Muuda", edit, new {id = index}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }
    }
}