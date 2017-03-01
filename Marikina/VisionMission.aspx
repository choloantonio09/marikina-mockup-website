<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisionMission.aspx.cs" Inherits="Marikina.VisionMission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


     <div class="image"><img class="undefined" runat="server" src="~/assets/img/visionmissionbanner.png" style="width:1349px; height:450px; padding-bottom:10px;"></div>
                                                    
    <!-- BEGIN PAGE CONTENT INNER -->
                        <div class="page-content-inner">
                                
                            <div class="col-md-12 col-sm-12">
                                    <!-- BEGIN PORTLET-->
                                    <div class="portlet light ">
                                        <div class="portlet-title tabbable-line">
                                            <div class="caption">
                                                <i class="icon-globe font-dark hide"></i>
                                                <h2 class="caption-subject font-green bold uppercase">Public Information Office (PIO)</h2> 
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div>
                                                    <div class="mt-comments ">
                                                        <div class="mt-comment">
                                                            <div class="mt-comment-img">
                                                                <img src="../assets/img/default_logo.png"/ style="width:120px;"> </div>
                                                                <div class="mt-comment-body" style="padding-left:100px;">
                                                                <div class="mt-comment-info">
                                                                     <span class="mt-comment-author">MARIA LOURDES T. NAVARRO - OIC</span>
                                                                </div>
                                                                <div class="mt-comment-text"> Second Floor, Marikina City Hall </div>
                                                                <div class="mt-comment-text"> Shoe Avenue, Bgy. Sta. Elena, Marikina City </div>
                                                                <div class="mt-comment-text"> Telephone: 646-2360 to 70 loc. 210 </div>
                                                                <div class="mt-comment-text"> Telefax: 646-6451 </div>
                                                                <div class="mt-comment-text"> E-mail: piodzbf@mozcom.com </div>
                                                           </div>
                                                         </div>
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
                                                 <h2 class="caption-subject font-green bold uppercase">Vision</h2> 
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div class="price-table-pricing">
                                                        <div class="image"><img class="undefined" runat="server" src="~/assets/img/vision.jpg" style="width:600px; height:350px; padding-top:10px;"></div>
                                                </div>
                                                <div>
                                                    <div class="scroller parajustify" style="height: 339px;" data-always-visible="1" data-rail-visible="0">
                                                         <br /><br />
                                                       <asp:FormView ID="FormView1" runat="server" DataSourceID="EntityDataSourceVision">
                                                           <ItemTemplate>
                                                               <asp:Label Text='<%# Eval("vision").ToString().Replace(Environment.NewLine,"<br />") %>' ID="Label1" runat="server" ></asp:Label>
                                                           </ItemTemplate>
                                                       </asp:FormView>

                                                       <asp:EntityDataSource ID="EntityDataSourceVision" runat="server" 
                                                           ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" 
                                                           EntitySetName="headers" Select="it.[vision]"></asp:EntityDataSource>
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
                                                 <h1 class="caption-subject font-green bold uppercase">Mission</h1> 
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div class="price-table-pricing">
                                                    <div class="image"><img class="undefined" runat="server" src="~/assets/img/Mission.jpg" style="width:600px; height:350px; padding-top:10px;"></div>
                                                </div>
                                                <div class="tab-pane active" id="tab_1_1">
                                                    <div class="scroller parajustify" style="height: 339px;" data-always-visible="1" data-rail-visible="0">
                                                        <br /><br />
                                                        <asp:FormView ID="FormView2" runat="server" DataSourceID="EntityDataSourceMission">
                                                           <ItemTemplate>
                                                               <asp:Label Text='<%# Eval("mission").ToString().Replace(Environment.NewLine,"<br />") %>' ID="Label2" runat="server" ></asp:Label>
                                                           </ItemTemplate>
                                                       </asp:FormView>

                                                       <asp:EntityDataSource ID="EntityDataSourceMission" runat="server" 
                                                           ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" 
                                                           EntitySetName="headers" Select="it.[mission]"></asp:EntityDataSource>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--END TABS-->
                                        </div>
                                    </div>
                                    <!-- END PORTLET-->
                                </div>
    


                               
                            </div>
                       
                       

                        <!-- END PAGE CONTENT INNER -->
</asp:Content>
