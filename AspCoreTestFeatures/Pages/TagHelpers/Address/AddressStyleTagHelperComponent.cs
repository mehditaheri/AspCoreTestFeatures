using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspCoreTestFeatures.Pages.TagHelpers.Address
{
    public class AddressStyleTagHelperComponent : TagHelperComponent
    {
        private readonly string _style =
            @"<link rel=""stylesheet"" href=""/css/address.css"" />";

        public override int Order => 1;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head",
                              StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(_style);
            }

            return Task.CompletedTask;
        }
    }
}
