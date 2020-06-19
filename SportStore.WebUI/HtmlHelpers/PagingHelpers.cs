using SportStore.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace SportStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int,string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                result.Append("<li class=\"page-item");
                if (i == pagingInfo.CurrentPage)
                {
                    result.Append(" active");
                }
                result.Append("\">");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tag.AddCssClass("page-link");
                result.Append(tag.ToString() + "</li>");
            }
            string final_result = "<ul class=\"pagination\">" + result.ToString() + "</ul>";
            
            return MvcHtmlString.Create(final_result);
        }
    }
}