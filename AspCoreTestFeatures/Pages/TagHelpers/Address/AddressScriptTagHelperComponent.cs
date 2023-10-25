using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspCoreTestFeatures.Pages.TagHelpers.Address
{
    public class AddressScriptTagHelperComponent : TagHelperComponent
    {
        public override int Order => 2;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "body",
                              StringComparison.OrdinalIgnoreCase))
            {
                var script = await File.ReadAllTextAsync(
                    "TagHelpers/Templates/AddressToolTipScript.html");
                output.PostContent.AppendHtml(script);
            }
        }
    }
}
