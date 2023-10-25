using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using AspCoreTestFeatures.Services;

namespace AspCoreTestFeatures.Pages.TagHelpers.Employee
{
    public class EmployeeDetailsTagHelper : TagHelper
    {
        private IUserService _userService;

        public EmployeeDetailsTagHelper(IUserService userService)
        {
            _userService = userService;
        }
 
        // PascalCase gets translated into Camel-case.
        // Can be passed via <my-custom employee-id="..." />. 
        public int EmployeeId { get; set; }
        // Can be passed via <my-custom employee-name="..." />. 
        public string? EmployeeName { get; set; }
        // Can be passed via <my-custom designation="..." />. 
        public string? Designation { get; set; }
 
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var users = await _userService.GetUsersAsync();

            //TagName: The HTML element's tag name.
            //A whitespace or null value results in no start or end tag being rendered.
            output.TagName = "EmployeeSectionTagHelper"; // Set the HTML element name
            //TagMode: Syntax of the element in the generated HTML.
            //StartTagAndEndTag: Include both start and end tags.
            output.TagMode = TagMode.StartTagAndEndTag;
            //Create a String Builder Object to Hold the Employee Informations
            var sb = new StringBuilder();
            sb.AppendFormat($"<span>Employee Id:</span> <strong>{EmployeeId}</strong><br/>");
            sb.AppendFormat($"<span>Employee Name:</span> <strong>{EmployeeName}</strong><br/>");
            sb.AppendFormat($"<span>Employee Designation:</span> <strong>{Designation}</strong><br/>");
            //Convert the StringBuilder Object to String Type and
            //then set that string as the content either using SetContent and SetHtmlContent method
            //Content: Get or set the HTML element's main content.
            //SetHtmlContent: Sets the content.
            //output.Content.SetHtmlContent(sb.ToString());
            //output.Content.SetContent(sb.ToString());
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}