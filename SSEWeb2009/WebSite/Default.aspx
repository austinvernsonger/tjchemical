<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="同济大学软件学院" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="ucl" %>
<asp:Content ID="ctnt_head" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= ConstValue.PureURL%>CssClass/ActivityLook.css" rel="stylesheet" type="text/css" />
    <link href="CssClass/clearbox.css" rel="stylesheet" type="text/css" />
    
    <!–[if IE]><![if gt IE 6]><![endif]–>
    <script src="JavaScript/clearbox.js" type="text/javascript"></script>
    <!–[if IE]><![endif]><![endif]–> 
    <style type="text/css">
        #myGallery, #myGallerySet, #flickrGallery
        {
            width: 373px;
            height: 238px;
            z-index: 5;
            border: 1px solid #fff;
        }
        #flickrGallery
        {
            width: 500px;
            height: 334px;
        }
        #myGallery img.thumbnail, #myGallerySet img.thumbnail
        {
            display: none;
        }
        .jdGallery
        {
            overflow: hidden;
            position: relative;
        }
        .jdGallery img
        {
            border: 0;
            margin: 0;
        }
        .jdGallery .slideElement
        {
            width: 100%;
            height: 100%;
            background-color: #000;
            background-repeat: no-repeat;
            background-position: center center;
            background-image: url(  'img/loading-bar-black.gif' );
        }
        .jdGallery .loadingElement
        {
            width: 100%;
            height: 100%;
            position: absolute;
            left: 0;
            top: 0;
            background-color: #000;
            background-repeat: no-repeat;
            background-position: center center;
            background-image: url(  'img/loading-bar-black.gif' );
        }
        .jdGallery .slideInfoZone
        {
        	background-color:black;
        	line-height:16px;
            position: absolute;
            z-index: 10;
            width: 100%;
            margin: 0px;
            left: 0;
            bottom: 0;
            height: 22px;
            color: #fff;
            text-indent: 0;
            overflow: hidden;
            font-family: Arial;
        }
        * html .jdGallery .slideInfoZone
        {
            bottom: -1px;
        }
        .jdGallery .slideInfoZone h2
        {
            padding: 3px;
            font-size: 12px;
            margin: 0;
            margin: 2px 5px;
            color: white;
        }
        .jdGallery .slideInfoZone p
        {
            padding: 0;
            font-size: 12px;
            margin: 2px 5px;
            color: white;
        }
        .jdGallery div.carouselContainer
        {
            position: absolute;
            height: 135px;
            width: 100%;
            z-index: 10;
            margin: 0px;
            left: 0;
            top: 0;
        }
        .jdGallery a.carouselBtn
        {
            position: absolute;
            bottom: 0;
            right: 30px;
            height: 20px; /*width: 100px; background: url('img/carousel_btn.gif') no-repeat;*/
            text-align: center;
            padding: 0 10px;
            font-size: 13px;
            background: #333;
            color: #fff;
            cursor: pointer;
        }
        .jdGallery .carousel
        {
            position: absolute;
            width: 100%;
            margin: 0px;
            left: 0;
            top: 0;
            height: 115px;
            background: #333;
            color: #fff;
            text-indent: 0;
            overflow: hidden;
        }
        .jdExtCarousel
        {
            overflow: hidden;
            position: relative;
        }
        .jdGallery .carousel .carouselWrapper, .jdExtCarousel .carouselWrapper
        {
            position: absolute;
            width: 100%;
            height: 78px;
            top: 10px;
            left: 0;
            overflow: hidden;
        }
        .jdGallery .carousel .carouselInner, .jdExtCarousel .carouselInner
        {
            position: relative;
        }
        .jdGallery .carousel .carouselInner .thumbnail, .jdExtCarousel .carouselInner .thumbnail
        {
            cursor: pointer;
            background: #000;
            background-position: center center;
            float: left;
            border: solid 1px #fff;
        }
        .jdGallery .wall .thumbnail, .jdExtCarousel .wall .thumbnail
        {
            margin-bottom: 10px;
        }
        .jdGallery .carousel .label, .jdExtCarousel .label
        {
            font-size: 13px;
            position: absolute;
            bottom: 5px;
            left: 10px;
            padding: 0;
            margin: 0;
        }
        .jdGallery .carousel .wallButton, .jdExtCarousel .wallButton
        {
            font-size: 10px;
            position: absolute;
            bottom: 5px;
            right: 10px;
            padding: 1px 2px;
            margin: 0;
            background: #222;
            border: 1px solid #888;
            cursor: pointer;
        }
        .jdGallery .carousel .label .number, .jdExtCarousel .label .number
        {
            color: #b5b5b5;
        }
        .jdGallery a
        {
            font-size: 100%;
            text-decoration: none;
            color: inherit;
        }
        .jdGallery a.right, .jdGallery a.left
        {
            position: absolute;
            height: 16px;
            width: 16px;
            cursor: pointer;
            z-index: 11;
            filter: alpha(opacity=20);
            -moz-opacity: 0.2;
            -khtml-opacity: 0.2;
            opacity: 0.2;
        }
        * html .jdGallery a.right, * html .jdGallery a.left
        {
            filter: alpha(opacity=50);
        }
        .jdGallery a.right:hover, .jdGallery a.left:hover
        {
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            -khtml-opacity: 0.8;
            opacity: 0.8;
        }
        .jdGallery a.left
        {
            left: 332px;
            top: 218px;
            background: url(  'Resources/Images/news_arrow_pre.gif' ) no-repeat center left;
        }
        * html .jdGallery a.left
        {
            background: url(  'Resources/Images/news_arrow_pre.gif' ) no-repeat center left;
        }
        .jdGallery a.right
        {
            right: 5px;
            top: 218px;
            background: url(  'Resources/Images/news_arrow_next.gif' ) no-repeat center right;
        }
        * html .jdGallery a.right
        {
            background: url(  'Resources/Images/news_arrow_next.gif' ) no-repeat center right;
        }
        .jdGallery a.open
        {
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
        }
        .withArrows a.open
        {
            position: absolute;
            top: 0;
            height: 99%;
            width: 100%;
            cursor: pointer;
            z-index: 10;
            background: none;
            -moz-opacity: 0.8;
            -khtml-opacity: 0.8;
            opacity: 0.8;
        }
        * html .withArrows a.open:hover
        {
            background: url(  'img/open.gif' ) no-repeat center center;
            filter: alpha(opacity=80);
        }
        /* Gallery Sets */.jdGallery a.gallerySelectorBtn
        {
            z-index: 15;
            position: absolute;
            top: 0;
            left: 30px;
            height: 20px; /*width: 100px; background: url('img/carousel_btn.gif') no-repeat;*/
            text-align: center;
            padding: 0 10px;
            font-size: 13px;
            background: #333;
            color: #fff;
            cursor: pointer;
            opacity: .4;
            -moz-opacity: .4;
            -khtml-opacity: 0.4;
            filter: alpha(opacity=40);
        }
        .jdGallery .gallerySelector
        {
            z-index: 20;
            width: 100%;
            height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            background: #000;
        }
        .jdGallery .gallerySelector h2
        {
            margin: 0;
            padding: 10px 20px 10px 20px;
            font-size: 20px;
            line-height: 30px;
            color: #fff;
        }
        .jdGallery .gallerySelector .gallerySelectorWrapper
        {
            overflow: hidden;
        }
        .jdGallery .gallerySelector .gallerySelectorInner div.galleryButton
        {
            margin-left: 10px;
            margin-top: 10px;
            border: 1px solid #888;
            padding: 5px;
            height: 40px;
            color: #fff;
            cursor: pointer;
            float: left;
        }
        .jdGallery .gallerySelector .gallerySelectorInner div.hover
        {
            background: #333;
        }
        .jdGallery .gallerySelector .gallerySelectorInner div.galleryButton div.preview
        {
            background: #000;
            background-position: center center;
            float: left;
            border: none;
            width: 40px;
            height: 40px;
            margin-right: 5px;
        }
        .jdGallery .gallerySelector .gallerySelectorInner div.galleryButton h3
        {
            margin: 0;
            padding: 0;
            font-size: 12px;
            font-weight: normal;
        }
        .jdGallery .gallerySelector .gallerySelectorInner div.galleryButton p.info
        {
            margin: 0;
            padding: 0;
            font-size: 12px;
            font-weight: normal;
            color: #aaa;
        }
    </style>
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" runat="Server">
    <!--News Panel-->
    <div id="middle_middle">
        <!--Flash-->
        <div id="picnews">
            <div id="myGallery">
                <div class="imageElement">
                    <h3>
                        新版学院网站上线</h3>
                    <p>
                    </p>
                    <a href="http://sse.tongji.edu.cn" title="open image" class="open"></a>
                    <img src="Resources/Images/sseshangxian2_sml.jpg" class="full" />
                    <img src="Resources/Images/sseshangxian2_sml.jpg" class="thumbnail" />
                </div>
                <div class="imageElement">
                    <h3>
                        热烈庆祝中华人民共和国成立60周年</h3>
                    <p>
                    </p>
                    <a href="http://sse.tongji.edu.cn" title="open image" class="open"></a>
                    <img src="Resources/Images/guoqing1_sml.jpg" class="full" />
                    <img src="Resources/Images/guoqing1_sml.jpg" class="thumbnail" />
                </div>
            </div>
        </div>
        <!--News-->
        <div id="txtnews">
            <!--
	<div id="news_title"> 
        <asp:Image ID="newsTop_night" runat="server" CssClass="Dark" ImageUrl="~/Resources/Dark/NewsbackTop.jpg" />
        <asp:Image ID="newTop_day" runat="server" CssClass="Bright" ImageUrl="~/Resources/Bright/NewsbackTop.jpg" />
	</div>
-->
            <div id="NewsHead">
                <div id="NewsTitle">
                </div>
                <div style="width: 360px; height: 3px; line-height: 3px">
                    <div style="background-color: #005bac; width: 163px; margin-right: 2px; float: left;
                        height: 3px">
                        &nbsp;</div>
                    <div style="background-color: #1facda; width: 195px; float: left; height: 3px">
                        &nbsp;</div>
                </div>
            </div>
            <div id="news_content">
                <ucl:MMTList ID="mmt_news" runat="server" DepartmentId="0" PageSize="5" TitleMaxLength="15"
                    ShowTime="True" ShowClickCount="False" Mode="News" EmptyString="Empty." AllowPaging="false"
                    ShowURL="~/NewsDetail.aspx" ItemCssClass="notice_content_stl" FirstLineSpecialCssClass="newsTitle"
                    FirstLineContentCssClass="newsContent" FirstLineTimeCssClass="newsTime" SpecifialNews="true"
                    ReturnWords="50" />
            </div>
            <div id="news_bottom_bar" runat="server" class="news_bottom">
                <div class="btn_more">
                    <a href="MoreNews.aspx">
                        <img src="Resources/Bright/BtnMore.png" /><span>更多</span></a>
                </div>
            </div>
        </div>
        <!--QuickAccess-->
        <div id="quickaccess">
            <div class="holder">
                <div id="quick_access_top">
                    <asp:Image ID="qAcTop_day" runat="server" CssClass="Bright" ImageUrl="~/Resources/Bright/QuickAccessTitle.png" />
                </div>
                <!--[if lte IE 6]><div class="QA_StyleIE6"><![endif]-->
                <div class="QuickAccessContent" id="LinkDiv" runat="server">
                </div>
                <!--[if lte IE 6]></div><![endif]-->
                <!--[if lte IE 6]><div class="QA_Btm_StyleIE6"><![endif]-->
                <div class="bottom">
                    <div class="bottom_l">
                    </div>
                    <div class="bottom_mid">
                    </div>
                    <div class="bottom_r">
                    </div>
                </div>
                <!--[if lte IE 6]></div><![endif]-->
            </div>
            <div class="icon">
            </div>
        </div>
    </div>
    <!--Activities, Notices, Quick Access-->
    <div id="middle_bottom">
        <!--Activity-->
        <div id="active">
            <div id="actv_top">
                <!--      <asp:Image ID="actvTop_night" runat="server" CssClass="Dark" ImageUrl="~/Resources/Dark/ActvTop.jpg" />
<asp:Image ID="actvTop_day" runat="server" CssClass="Bright" ImageUrl="~/Resources/Bright/ActivityTitle.png" />   -->
            </div>
            <div style="width: 375px; height: 3px; line-height: 3px; margin-top: 5px">
                <div style="background-color: #005bac; width: 170px; margin-right: 2px; float: left;
                    height: 3px">
                    &nbsp;</div>
                <div style="background-color: #1facda; width: 199px; float: left; height: 3px">
                    &nbsp;</div>
            </div>
            <div id="ActivityContent">
                <div id="loading">
                    <img src="Resources/Images/ajax-loader(1).gif" />loading...</div>
                <div class="applemenu">
                    <div class="silverheader" id="thediv1">
                    </div>
                    <div class="submenu" id="subdiv1">
                        <div class="title">
                            <span class="title">活动名称：</span><span id="Title1">2009年9月14日 上午8：00</span>
                            <br />
                        </div>
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime1">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime1">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location1">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails1" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv2">
                    </div>
                    <div class="submenu" id="subdiv2">
                        <span class="title">活动名称：</span><span id="Title2">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime2">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime2">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location2">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails2" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv3">
                    </div>
                    <div class="submenu" id="subdiv3">
                        <span class="title">活动名称：</span><span id="Title3">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime3">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime3">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location3">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails3" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv4">
                    </div>
                    <div class="submenu" id="subdiv4">
                        <span class="title">活动名称：</span><span id="Title4">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime4">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime4">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location4">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails4" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv5">
                    </div>
                    <div class="submenu" id="subdiv5">
                        <span class="title">活动名称：</span><span id="Title5">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime5">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime5">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location5">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails5" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv6">
                    </div>
                    <div class="submenu" id="subdiv6">
                        <span class="title">活动名称：</span><span id="Title6">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime6">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime6">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location6">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails6" href="#">>>查看详情</a></div>
                    </div>
                    <div class="silverheader" id="thediv7">
                    </div>
                    <div class="submenu" id="subdiv7">
                        <span class="title">活动名称：</span><span id="Title7">2009年9月14日 上午8：00</span>
                        <br />
                        <div class="date">
                            <span class="title">开始时间：</span><span id="StartTime7">2009年9月14日 上午8：00</span>
                            <br />
                            <span class="title">截止时间：</span><span id="EndTime7">2009年9月17日 下午4：00</span>
                            <br />
                        </div>
                        <div class="place">
                            <span class="title">活动地点：</span><span id="Location7">四平路校区XX大礼堂</span>
                        </div>
                        <div class="button">
                            <a id="moredetails7" href="#">>>查看详情</a></div>
                    </div>
                </div>
                <div class="btn_more" id="activity_btn">
                    <a href="MoreActivity.aspx">
                        <img src="Resources/Bright/BtnMore.png" /><span>更多</span></a>
                </div>
            </div>
        </div>
        <!--Notices-->
        <div id="notice">
            <div id="notice_top">
                <!-- <asp:Image ID="noticeTop_night" runat="server" CssClass="Dark" ImageUrl="~/Resources/Dark/notice.jpg" />
                <asp:Image ID="notiveTop_day" runat="server" CssClass="Bright" ImageUrl="~/Resources/Bright/notice.jpg" /> -->
            </div>
            <div style="width: 570px; height: 3px; line-height: 3px; margin-top: 5px">
                <div style="background-color: #005bac; width: 170px; margin-right: 2px; float: left;
                    height: 3px">
                    &nbsp;</div>
                <div style="background-color: #1facda; width: 398px; float: left; height: 3px">
                    &nbsp;</div>
            </div>
            <!---这是通知的iframe--->
            <div class="content">
                <iframe id="ifrm_searchbar" src="<%= ConstValue.PureURL%>Login/renre.htm" scrolling="no"
                    marginheight="0" marginwidth="0" height="100%" width="100%" frameborder="0">
                </iframe>
            </div>
        </div>
    </div>
    <!--Picture Panel-->
    <div id="college_pic_top">
        <div id="pic_top">
        </div>
        <div style="width: 960px; height: 3px; line-height: 3px; margin-top: 5px">
            <div style="background-color: #005bac; width: 170px; margin-right: 2px; float: left;
                height: 3px">
                &nbsp;</div>
            <div style="background-color: #1facda; width: 788px; float: left; height: 3px">
                &nbsp;</div>
        </div>
    </div>
    <div id="college_pic_line">
        <!-- 学院图片滚动栏 -->
        <div id="sclDiv" runat="server" style="position: absolute; width: 960px; left: 0px;"
            class="scrollable_demo">
        </div>
    </div>
    <!--Friends' Links-->
    <div id="friends_links">
    友情链接：
    <a href="http://www.tongji.edu.cn/">同济大学官方网站</a> | 
    <a href="http://bbs.tongji.net/">同济大学BBS</a> | 
    <a href="http://gs.tongji.edu.cn/">同济大学研究生院</a> | 
    <a href="http://sse.tongji.edu.cn/sseold/sse_library/index.aspx">同济大学软件学院图书馆</a> | 
    <a href="http://www.cstqb.cn/">中国软件测试认证委员会</a> | 
    <a href="http://mail.tongji.edu.cn/">同济邮箱</a>
    </div>
</asp:Content>
