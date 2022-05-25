using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.TagHelpers
{
    [HtmlTargetElement("e-mail", TagStructure = TagStructure.WithoutEndTag)]
    // <e-mail to-user="miaemail@gmail.com"></e-mail>
    // <e-mail to-user="miaemail@gmail.com"/>
    public class EMailTagHelper : TagHelper
    {
        // specifico le proprieta' che voglio poter utilizzare nel mio taghelper
        public string ToUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("Send me an email");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");

        }
    }
}
