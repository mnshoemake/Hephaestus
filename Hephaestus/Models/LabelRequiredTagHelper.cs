using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Hephaestus.Models
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        private const string ForAttributeName = "asp-for";

        public LabelRequiredTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            if (For.Metadata.IsRequired)
            {
                var sup = new TagBuilder("sup");
                sup.InnerHtml.Append("*");
                output.Content.AppendHtml(sup);
            }
        }
    }
}