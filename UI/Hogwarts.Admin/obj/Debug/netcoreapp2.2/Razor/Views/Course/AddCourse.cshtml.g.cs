#pragma checksum "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c34d7b8fccfc80fbe6c54273c1e734ea93e5668"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_AddCourse), @"mvc.1.0.view", @"/Views/Course/AddCourse.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Course/AddCourse.cshtml", typeof(AspNetCore.Views_Course_AddCourse))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\_ViewImports.cshtml"
using Hogwarts.Admin;

#line default
#line hidden
#line 3 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
using Hogwarts.DB.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c34d7b8fccfc80fbe6c54273c1e734ea93e5668", @"/Views/Course/AddCourse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"842e3f211b828bb5b3ef6084d2bd8c501adf0b7a", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_AddCourse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/courseAdd.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("childrenBody"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 5 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
  
    Layout = "";

#line default
#line hidden
            BeginContext(121, 23, true);
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            EndContext();
            BeginContext(144, 611, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c34d7b8fccfc80fbe6c54273c1e734ea93e56687687", async() => {
                BeginContext(150, 461, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>Hogwarts后台管理-添加课程</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""format-detection"" content=""telephone=no"">
    ");
                EndContext();
                BeginContext(611, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c34d7b8fccfc80fbe6c54273c1e734ea93e56688554", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(681, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(686, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c34d7b8fccfc80fbe6c54273c1e734ea93e56689971", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(747, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(755, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(756, 3390, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c34d7b8fccfc80fbe6c54273c1e734ea93e566812183", async() => {
                BeginContext(783, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(788, 3209, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c34d7b8fccfc80fbe6c54273c1e734ea93e566812569", async() => {
                    BeginContext(832, 165, true);
                    WriteLiteral("\n        <div class=\"layui-form-item layui-row layui-col-xs12\">\n            <label class=\"layui-form-label\">课程号</label>\n            <div class=\"layui-input-inline\">\n");
                    EndContext();
#line 27 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                 if (Model.Cno == 0)
                {

#line default
#line hidden
                    BeginContext(1052, 137, true);
                    WriteLiteral("                    <input type=\"text\" class=\"layui-input courseId\" value=\"\" name=\"courseId\" lay-verify=\"required\" placeholder=\"请输入课程号\">\n");
                    EndContext();
#line 30 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }
                else
                {

#line default
#line hidden
                    BeginContext(1246, 82, true);
                    WriteLiteral("                    <input type=\"text\" class=\"layui-input courseId layui-disabled\"");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 1328, "\"", 1346, 1);
#line 33 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
WriteAttributeValue("", 1336, Model.Cno, 1336, 10, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(1347, 70, true);
                    WriteLiteral(" name=\"courseId\" disabled lay-verify=\"required\" placeholder=\"请输入课程号\">\n");
                    EndContext();
#line 34 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }

#line default
#line hidden
                    BeginContext(1435, 282, true);
                    WriteLiteral(@"            </div>
            <div class=""layui-form-mid layui-word-aux"" id=""courseIdLabel"">课程号</div>
        </div>
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">课程名</label>
            <div class=""layui-input-inline"">
");
                    EndContext();
#line 41 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                 if (Model.Cno == 0)
                {

#line default
#line hidden
                    BeginContext(1772, 137, true);
                    WriteLiteral("                <input type=\"text\" class=\"layui-input courseName\" value=\"\" name=\"courseName\" lay-verify=\"required\" placeholder=\"请输入课程名\">\n");
                    EndContext();
#line 44 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }
                else
                {

#line default
#line hidden
                    BeginContext(1966, 85, true);
                    WriteLiteral("            <input type=\"text\" class=\"layui-input courseName layui-disabled\" disabled");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 2051, "\"", 2071, 1);
#line 47 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
WriteAttributeValue("", 2059, Model.Cname, 2059, 12, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2072, 63, true);
                    WriteLiteral(" name=\"courseName\" lay-verify=\"required\" placeholder=\"请输入课程名\">\n");
                    EndContext();
#line 48 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }

#line default
#line hidden
                    BeginContext(2153, 284, true);
                    WriteLiteral(@"            </div>
            <div class=""layui-form-mid layui-word-aux"" id=""courseNameLabel"">课程名</div>
        </div>
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">英文名</label>
            <div class=""layui-input-inline"">
");
                    EndContext();
#line 55 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                 if (Model.Cno == 0)
                {

#line default
#line hidden
                    BeginContext(2492, 158, true);
                    WriteLiteral("                <input type=\"text\" class=\"layui-input englishName\" name=\"englishName\" value=\"\" lay-verify=\"required\" placeholder=\"Please Input English Name\">\n");
                    EndContext();
#line 58 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }
                else
                {

#line default
#line hidden
                    BeginContext(2707, 105, true);
                    WriteLiteral("            <input type=\"text\" class=\"layui-input englishName layui-disabled\" disabled name=\"englishName\"");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 2812, "\"", 2838, 1);
#line 61 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
WriteAttributeValue("", 2820, Model.EnglishName, 2820, 18, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2839, 64, true);
                    WriteLiteral(" lay-verify=\"required\" placeholder=\"Please Input English Name\">\n");
                    EndContext();
#line 62 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }

#line default
#line hidden
                    BeginContext(2921, 352, true);
                    WriteLiteral(@"            </div>
            <div class=""layui-form-mid layui-word-aux"" id=""englishNameLabel"">英文名</div>
        </div>
        <div class=""layui-form-item layui-row layui-col-xs12"">
            <label class=""layui-form-label"">课程学分</label>
            <div class=""layui-input-inline"">
                <input type=""text"" class=""layui-input courseScore""");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 3273, "\"", 3294, 1);
#line 69 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
WriteAttributeValue("", 3281, Model.CScore, 3281, 13, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(3295, 206, true);
                    WriteLiteral(" name=\"courseScore\" lay-verify=\"required\" placeholder=\"请输入课程学分\">\n            </div>\n        </div>\n        <div class=\"layui-form-item layui-row layui-col-xs12\">\n            <div class=\"layui-input-block\">\n");
                    EndContext();
#line 74 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                 if (Model.Cno == 0)
                {

#line default
#line hidden
                    BeginContext(3556, 110, true);
                    WriteLiteral("                    <button class=\"layui-btn layui-btn-sm\" lay-submit=\"\" lay-filter=\"addCourse\">立即添加</button>\n");
                    EndContext();
#line 77 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }
                else
                {

#line default
#line hidden
                    BeginContext(3723, 113, true);
                    WriteLiteral("                    <button class=\"layui-btn layui-btn-sm\" lay-submit=\"\" lay-filter=\"updateCourse\">立即修改</button>\n");
                    EndContext();
#line 81 "C:\Users\MichaelShen\Desktop\项目\数据库大作业\Hogwarts\Hogwarts\UI\Hogwarts.Admin\Views\Course\AddCourse.cshtml"
                }

#line default
#line hidden
                    BeginContext(3854, 136, true);
                    WriteLiteral("                <button type=\"reset\" class=\"layui-btn layui-btn-sm layui-btn-primary\">取消</button>\n            </div>\n        </div>\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3997, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(4002, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c34d7b8fccfc80fbe6c54273c1e734ea93e566822643", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4069, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(4074, 64, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c34d7b8fccfc80fbe6c54273c1e734ea93e566823984", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4138, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4146, 8, true);
            WriteLiteral("\n</html>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
