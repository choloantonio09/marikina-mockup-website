<%@ Page Title="Home Page" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Marikina._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <section class="mbr-box mbr-section mbr-section--relative mbr-section--fixed-size mbr-section--full-height mbr-section--bg-adapted mbr-parallax-background mbr-after-navbar" id="header1-73" style="background-image: url(<%=BannerImage%>);">
                <div class="mbr-box__magnet mbr-box__magnet--sm-padding mbr-box__magnet--center-left">
                    <div class="mbr-overlay" style="opacity: 0; background-color: rgb(76, 105, 114);"></div>
                    <div class="mbr-box__container mbr-section__container container">
                        <div class="mbr-box mbr-box--stretched"><div class="mbr-box__magnet mbr-box__magnet--center-left ">
                            <div class="row"><div class="col-sm-6 mbr-welcome-box" >
                                <div class="mbr-hero animated fadeInUp " >
                                    <h4 class="mbr-hero__text">WELCOME TO MARIKINA WEBSITE</h4>
                                    <p class="mbr-hero__subtext">Catch up with our exciting events <br></p>
                                </div>
                                <div class="mbr-buttons btn-inverse mbr-buttons--left">
                                    <a class="mbr-buttons__btn btn btn-lg animated fadeInUp delay btn-primary" href="../Events.aspx">UPCOMING EVENTS</a> 
                                    <a class="mbr-buttons__btn btn btn-lg btn-success animated fadeInUp delay" href="../Account/Login.aspx">LOG IN NOW</a>
                                </div>
                            </div></div>
                        </div></div>
                    </div>
                    <div class="mbr-arrow mbr-arrow--floating text-center">
                        <div class="mbr-section__container container">
                            <a class="mbr-arrow__link" href="#features1-75"><i class="glyphicon glyphicon-menu-down"></i></a>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="content-2 col-4" id="features1-75" style="background-color: rgb(255, 255, 255);">
    
    <div class="container">
        <h2><center>Information</center></h2>
        <hr />
        <br />
        <div class="row">
            <div>
                <div class="thumbnail">
                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/visionmission.png"></div>
                    <div class="caption">
                        <div>
                            <h3>VISION AND MISSION</h3>
                           </div>
                        <p class="group"><a href="VisionMission.aspx" class="btn btn-default">LEARN MORE</a></p>
                    </div>
                </div>
            </div>
            <div>
                <div class="thumbnail">
                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/history.png"></div>
                    <div class="caption">
                        <div>
                            <h3>HISTORY</h3>
                           </div>
                        <p class="group"><a href="History.aspx" class="btn btn-default">LEARN MORE</a></p>
                    </div>
                </div>
            </div>
            <div>
                <div class="thumbnail">
                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/officials.png"></div>
                    <div class="caption">
                        <div>
                            <h3>BARANGAY OFFICIALS</h3>
                           </div>
                        <p class="group"><a href="Officials.aspx" class="btn btn-default">LEARN MORE</a></p>
                    </div>
                </div>
            </div>
            <div>
                <div class="thumbnail">
                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/events.png"></div>
                    <div class="caption">
                        <div>
                            <h3>EVENTS</h3>
                           </div>
                        <p class="group"><a href="../Events.aspx" class="btn btn-default">LEARN MORE</a></p>
                    </div>
                </div>
            </div>
            <div>
                <div class="thumbnail">
                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/announce.png"></div>
                    <div class="caption">
                        <div>
                            <h3>ANNOUNCEMENTS</h3>
                         </div>
                        <p class="group"><a href="#" class="btn btn-default">LEARN MORE</a></p>
                    </div>
                </div>
            </div>
        </div>
        <hr />
    </div>
</section>

    <br />
    <br />

    

    <div class="col-md-6 col-sm-6">
                                    <!-- BEGIN PORTLET-->
                                    <div class="portlet light ">
                                        <div class="portlet-title tabbable-line">
                                            <div class="caption">
                                                <i class="icon-globe font-dark hide"></i>
                                                <span class="caption-subject font-dark bold uppercase">Announcements</span>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div>
                                                    <div class="scroller" style="height: 339px;" data-always-visible="1" data-rail-visible="0">
                                                        <ul class="feeds">
                                                            <li>
                                                                <a href="javascript:;">
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                           <div class="label label-sm label-success">
                                                                                <i class="fa fa-bullhorn"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> You have 4 pending tasks.
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                    </a>
                                                                <div class="col2">
                                                                    <div class="date"> Just now </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a href="javascript:;">
                                                                    <div class="col1">
                                                                        <div class="cont">
                                                                            <div class="cont-col1">
                                                                                <div class="label label-sm label-success">
                                                                                <i class="fa fa-bullhorn"></i>
                                                                            </div>
                                                                            </div>
                                                                            <div class="cont-col2">
                                                                                <div class="desc"> New version v1.4 just lunched! </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col2">
                                                                        <div class="date"> 20 mins </div>
                                                                    </div>
                                                                </a>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-success">
                                                                                <i class="fa fa-bullhorn"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> Database server #12 overloaded. Please fix the issue. </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                </a>
                                                                <div class="col2">
                                                                    <div class="date"> 24 mins </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-success">
                                                                                <i class="fa fa-bullhorn"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New order received. Please take care of it. </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                </a>
                                                                <div class="col2">
                                                                    <div class="date"> 30 mins </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-success">
                                                                                <i class="fa fa-bullhorn"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New order received. Please take care of it. </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                    </a>
                                                                <div class="col2">
                                                                    <div class="date"> 22 hours </div>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--END TABS-->
                                        </div>
                                    </div>
                                    <!-- END PORTLET-->
                                </div>


    
    <div class="col-md-6 col-sm-6">
                                    <!-- BEGIN PORTLET-->
                                    <div class="portlet light ">
                                        <div class="portlet-title tabbable-line">
                                            <div class="caption">
                                                <i class="icon-globe font-dark hide"></i>
                                                <span class="caption-subject font-dark bold uppercase">Events</span>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div class="tab-pane active" id="tab_1_1">
                                                    <div class="scroller" style="height: 339px;" data-always-visible="1" data-rail-visible="0">
                                                        <ul class="feeds">
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> You have 4 pending tasks.
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> Just now </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a href="javascript:;">
                                                                    <div class="col1">
                                                                        <div class="cont">
                                                                            <div class="cont-col1">
                                                                                <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                            </div>
                                                                            <div class="cont-col2">
                                                                                <div class="desc"> New version v1.4 just lunched! </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col2">
                                                                        <div class="date"> 20 mins </div>
                                                                    </div>
                                                                </a>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> Database server #12 overloaded. Please fix the issue. </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 24 mins </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New order received. Please take care of it. </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 30 mins </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New order received. Please take care of it. </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 40 mins </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New user registered. </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 1.5 hours </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> Web server hardware needs to be upgraded.
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 2 hours </div>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <a>
                                                                <div class="col1">
                                                                    <div class="cont">
                                                                        <div class="cont-col1">
                                                                            <div class="label label-sm label-danger">
                                                                                <i class="fa fa-bolt"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div class="cont-col2">
                                                                            <div class="desc"> New order received. Please take care of it. </div>
                                                                        </div>
                                                                    </div>
                                                                </div></a>
                                                                <div class="col2">
                                                                    <div class="date"> 22 hours </div>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--END TABS-->
                                        </div>
                                    </div>
                                    <!-- END PORTLET-->
                                </div>
</asp:Content>
