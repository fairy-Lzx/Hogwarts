#pragma checksum "C:\Users\MichaelShen\Desktop\项目\Hogwarts-master\UI\Hogwarts.Admin\Views\Home\main.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3c82d0eda72db7244c52b202969bc92aed157e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_main), @"mvc.1.0.view", @"/Views/Home/main.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/main.cshtml", typeof(AspNetCore.Views_Home_main))]
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
#line 1 "C:\Users\MichaelShen\Desktop\项目\Hogwarts-master\UI\Hogwarts.Admin\Views\_ViewImports.cshtml"
using Hogwarts.Admin;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3c82d0eda72db7244c52b202969bc92aed157e3", @"/Views/Home/main.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"842e3f211b828bb5b3ef6084d2bd8c501adf0b7a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_main : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 23, true);
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            EndContext();
            BeginContext(23, 608, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3c82d0eda72db7244c52b202969bc92aed157e36179", async() => {
                BeginContext(29, 458, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>Hogwarts教务管理系统</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""format-detection"" content=""telephone=no"">
    ");
                EndContext();
                BeginContext(487, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a3c82d0eda72db7244c52b202969bc92aed157e37042", async() => {
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
                BeginContext(557, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(562, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a3c82d0eda72db7244c52b202969bc92aed157e38459", async() => {
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
                BeginContext(623, 1, true);
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
            BeginContext(631, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(632, 14470, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3c82d0eda72db7244c52b202969bc92aed157e310672", async() => {
                BeginContext(647, 5961, true);
                WriteLiteral(@"
    <blockquote class=""layui-elem-quote layui-bg-green"">
        <div id=""nowTime""></div>
    </blockquote>
    <div class=""layui-row layui-col-space10 panel_box"">
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"" data-url=""#"" target=""_blank"">
                <div class=""panel_icon layui-bg-green"">
                    <i class=""layui-anim seraph icon-good""></i>
                </div>
                <div class=""panel_word"">
                    <span>Hogwarts</span>
                    <cite>前台首页地址</cite>
                </div>
            </a>
        </div>
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"" data-url=""https://github.com/ShenPingYuan/Hogwarts"" target=""_blank"">
                <div class=""panel_icon layui-bg-black"">
                    <i class=""layui-anim seraph icon-github""></i>
                </div>
                <div class=""panel_word"">
             ");
                WriteLiteral(@"       <span>Github</span>
                    <cite>项目源码</cite>
                </div>
            </a>
        </div>
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"" data-url=""https://gitee.com/ShenPingYuan/Hogwarts"" target=""_blank"">
                <div class=""panel_icon layui-bg-red"">
                    <i class=""layui-anim seraph icon-oschina""></i>
                </div>
                <div class=""panel_word"">
                    <span>码云</span>
                    <cite>项目源码</cite>
                </div>
            </a>
        </div>
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"" data-url=""page/user/userList.html"">
                <div class=""panel_icon layui-bg-orange"">
                    <i class=""layui-anim seraph icon-icon10"" data-icon=""icon-icon10""></i>
                </div>
                <div class=""panel_word userAll"">
                    <span><");
                WriteLiteral(@"/span>
                    <em>用户总数</em>
                    <cite class=""layui-hide"">用户中心</cite>
                </div>
            </a>
        </div>
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"" data-url=""page/systemSetting/icons.html"">
                <div class=""panel_icon layui-bg-cyan"">
                    <i class=""layui-anim layui-icon"" data-icon=""&#xe857;"">&#xe857;</i>
                </div>
                <div class=""panel_word outIcons"">
                    <span></span>
                    <em>外部图标</em>
                    <cite class=""layui-hide"">图标管理</cite>
                </div>
            </a>
        </div>
        <div class=""panel layui-col-xs12 layui-col-sm6 layui-col-md4 layui-col-lg2"">
            <a href=""javascript:;"">
                <div class=""panel_icon layui-bg-blue"">
                    <i class=""layui-anim seraph icon-clock""></i>
                </div>
                <div class=""panel_word"">
         ");
                WriteLiteral(@"           <span class=""loginTime""></span>
                    <cite>上次登录时间</cite>
                </div>
            </a>
        </div>
    </div>
    <blockquote class=""layui-elem-quote main_btn"">
        <p>霍格沃兹魔法学校（Hogwarts School of Witchcraft and Wizardry）是一所全日制寄宿学校，由四位伟大的巫师于公元990年前后创办，坐落于英国苏格兰某个黑湖旁，其校训为“眠龙勿扰（Draco dormiens nunquam titillandus）”，致力于培养具有勇敢、博学、正直、理智等优良品质的巫师。</p>
    </blockquote>
    <div class=""layui-row layui-col-space10"">
        <div class=""layui-col-lg6 layui-col-md12"">
            <blockquote class=""layui-elem-quote title"">系统基本参数</blockquote>
            <table class=""layui-table magt0"">
                <colgroup>
                    <col width=""150"">
                    <col>
                </colgroup>
                <tbody>
                    <tr>
                        <td>当前版本</td>
                        <td class=""version""></td>
                    </tr>
                    <tr>
                        <td>开发作者</td>
                        <td class=""author""></td>
       ");
                WriteLiteral(@"             </tr>
                    <tr>
                        <td>网站首页</td>
                        <td class=""homePage""></td>
                    </tr>
                    <tr>
                        <td>服务器环境</td>
                        <td class=""server""></td>
                    </tr>
                    <tr>
                        <td>数据库版本</td>
                        <td class=""dataBase""></td>
                    </tr>
                    <tr>
                        <td>最大上传限制</td>
                        <td class=""maxUpload""></td>
                    </tr>
                    <tr>
                        <td>当前用户权限</td>
                        <td class=""userRights""></td>
                    </tr>
                </tbody>
            </table>
            <blockquote class=""layui-elem-quote title"">最新消息 <i class=""layui-icon layui-red"">&#xe756;</i></blockquote>
            <table class=""layui-table mag0"" lay-skin=""line"">
                <colgroup>
                    <col>
                    ");
                WriteLiteral(@"<col width=""110"">
                </colgroup>
                <tbody class=""hot_news""></tbody>
            </table>
        </div>
        <div class=""layui-col-lg6 layui-col-md12"">
            <blockquote class=""layui-elem-quote title"">项目背景&更新日志</blockquote>
            <div class=""layui-elem-quote layui-quote-nm history_box magb0"">
                <ul class=""layui-timeline"">
                    <li class=""layui-timeline-item"">
                        <i class=""layui-icon layui-timeline-axis"">&#xe756;</i>
                        <div class=""layui-timeline-content layui-text"">
                            <div class=""layui-timeline-title"">
                                <h3 class=""layui-inline"">Hogwarts 里程碑<span class=""layui-red"">Hogwarts教务系统Version 1.0</span>发布　</h3>
                                <span class=""layui-badge-rim"">");
                EndContext();
                BeginContext(6622, 7550, true);
                WriteLiteral(@"</span>
                            </div>
                            <div>
                                <p style=""font-size:15pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0"">
                                    <span style=""font-family:宋体; font-size:15pt; font-weight:bold"">1、</span>
                                    <span style=""font-family:宋体; font-size:15pt; font-weight:bold"">绪言</span>
                                </p>
                                <p style=""font-size:14pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0"">
                                    <span style=""font-family:宋体; font-size:14pt; font-weight:bold"">1.1</span>
                                    <span style=""font:7.0pt 'Times New Roman'"">&#xa0;&#xa0;&#xa0;&#xa0; </span>
                                    <span style=""font-family:宋体; font-size:14pt; font-weight:bold"">学校背景介绍</span>
                                </p>
                        ");
                WriteLiteral(@"        <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0"">
                                    <span style=""font-family:宋体; font-size:12pt"">霍格沃兹魔法学校</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">（Hogwarts School of Witchcraft and Wizardry）</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">是一所全日制寄宿学校</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">，由四位伟大的巫师于公元990年前后创办，</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">坐落于英国苏格兰某个黑湖旁，其校训为“眠龙勿扰</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">（</span><span style=""background-color:#ffffff; c");
                WriteLiteral(@"olor:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">Draco dormiens nunquam titillandus</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">）”，</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">致力于培养具有勇敢、博学、正直、理智等优良品质的巫师。</span>
                                </p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">一方面，霍格沃兹周围充满强烈的魔法磁场，会对电子设备产生强烈的干扰，现代科技产物如计算机、携带电子仪器等设备都无法在霍格沃兹使用；另一方面，巫师如《桃花源记》中村民般</span><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">对于外界的印象还停留在一个相对较早的时期，对于现代社会的发展普遍没有明确认知，且对外界具有一定程度的排斥及蔑视心理。以上两方面原因造成了霍格沃兹魔法");
                WriteLiteral(@"学校的教务管理还停留在一个纸质事务处理的阶段，显然在全球环境方面造成了持续时间长、影响范围大的危害。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">于教师教育方面，霍格沃兹教师纸质化处理教务效率较低，使得部分教师在工作过程中仅停留于“关注情景”阶段，甚至更甚者停留于“关注生存”阶段，显然对于挖掘学生潜力方面不够到位，对于学生受教育程度的关注有所缺失。于教师自我提升方面，教师把注意力大幅度投注在教务管理上，则没有多余精力投放于相关领域方面的研究，对于世界相关领域研究造成了一定程度上的损失，减缓了相关领域研究的进度。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""background-color:#ffffff; color:#333333; font-family:宋体; font-size:12pt; font-style:normal; text-transform:none"">于学生方面，霍格沃兹学生不能及时通过教务管理系统得知自己的学习进度，对自身当前情况没有一个明确的定位，在未来发展方向上得不到一个清晰的引导，即有可能导致自身发展状况停滞不前，综合素质发展减缓，人力资源市场缺失，世界人均GDP下降等不良后果。</span></p>
                                <p style=""font-size:14pt; line-height:150%; margin:0pt;");
                WriteLiteral(@" orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:14pt; font-weight:bold"">1.2 项目开发背景</span></p><p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">随着21世纪现代化、信息化建设步伐的加速以及人们环保意识的增强，各行业人员对于办公模式以及环境也提出了进一步的要求，无纸化办公的理念也逐渐渗透到各个行业领域中。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">此前，由于学校教务及档案管理水平还停留在纸质记录阶段，需消耗大量的人力、物力以及财力资源，一方面纸张成本的支出抑制了全球人均绿地面积的增长以及大气温室效应的改善；另一方面人们日益增长的对于办公高效性的需求同落后、繁琐、不安全的纸质办公之间的矛盾促使了人们对于一个创新、高效、安全的教务管理方式有了更深层次的需求与憧憬。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">在此基础上，教务管理系统作");
                WriteLiteral(@"为帮助学校管理教务情况的网络平台应运而生，并以极快的速度应用到世界范围内大部分学校，这些系统大多是针对本科院校的教务管理设计开发，在应用上不具备普适性，对于中小学、职业院校以及其他相关教育机构的教务管理情况还存在一定的滞后性，阻碍了部分教育行业人员对于教务管理高效性的追求，在学校招生、教育方面也造成了一定的影响。。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">目前，教务管理系统的应用已形成趋势，并在行业内有较为固定的功能版式，但在人体工学方面以及功能扩展上还具有一定范围的上升空间，这也为系统开发人员今后的程序开发提供了新的方向。</span></p>
                                <p style=""font-size:14pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:14pt; font-weight:bold"">1.3 项目开发意义</span></p><p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">霍格沃兹魔法学校至今已招收上百届学生，随着学校影响力的日益壮大，其教务处理的工作量与重复程度也与日俱增，影响了教师的教育教学工作，而且若出现遗漏和差错则会造成教学及决策错误，可能会造成学校发展方向偏离正确路线，学校评估等级与期待值偏差过大等不良后果。</span><");
                WriteLiteral(@"/p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">于学校层面，一个合理高效的教务管理系统不仅能提高教务管理效率，提升学生综合素质，节约办公开支，而且在信息的安全性上比纸质档案更具有完备性，不能随意被修改、删除、毁坏，用动态签名认证来代替传统密码口令，保证了签名内容的不可更改性和来源的真实性，极大增加了系统中信息的安全性。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">于教师层面，教务管理系统可以避免教师重复劳动，且减少了线下活动的次数，使各环节的处理工作串联起来，具有高度的灵活性，极大程度地减少了教师的教务管理时间，满足了教师对于教务管理高效性的追求，缓解了人们日益增长的对于办公高效性的需求同落后、繁琐、不安全的纸质办公之间的矛盾，改善了办公环境，减少了资源的浪费。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">于学生层面，教务管理系统可以帮助学生有建立准确的自我定位，对未来的发展有大致的方向，同时也能促进学生在实践中培养环保意识，加强其对于外界的了解，");
                WriteLiteral(@"在新时代的浪潮中砥砺前行，做时代的弄潮儿。</span></p>
                                <p style=""font-size:12pt; line-height:150%; margin:0pt; orphans:0; text-align:justify; text-indent:21pt; widows:0""><span style=""font-family:宋体; font-size:12pt; font-weight:normal"">综上所述，为霍格沃兹魔法学校建立教务管理系统是大势所趋、势在必行。</span></p>
                            </div>
                        </div>
                    </li>
");
                EndContext();
                BeginContext(14334, 629, true);
                WriteLiteral(@"                    <li class=""layui-timeline-item"">
                            <i class=""layui-icon layui-timeline-axis"">&#xe63f;</i>
                            <div class=""layui-timeline-content layui-text"">
                                <div class=""layui-timeline-title"">
                                    <h3 class=""layui-inline"">Hogwarts教务管理1.0 正式发布上线　</h3>
                                    <span class=""layui-badge-rim"">2019-12-15</span>
                                </div>
                            </div>
                        </li>
                </ul>
            </div>
        </div>
    </div>

    ");
                EndContext();
                BeginContext(14963, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3c82d0eda72db7244c52b202969bc92aed157e326116", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
                BeginContext(15030, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(15035, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3c82d0eda72db7244c52b202969bc92aed157e327459", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(15094, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(15102, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
