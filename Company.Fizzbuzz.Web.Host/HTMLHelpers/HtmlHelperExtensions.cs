using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using Company.Fizzbuzz.Web.Host.Models;

namespace Company.Fizzbuzz.Web.Host.HTMLHelpers
{
    public static class HtmlHelperExtensions
    {
        //// ----------------------------------------------------------------------------------------------------------

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();

            for (var i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString(CultureInfo.InvariantCulture);

                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");

                result.Append(tag);
                result.Append("&nbsp;");
            }

            return MvcHtmlString.Create(result.ToString());
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}