<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Marikina.History" %>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">

      <div class="image"><img class="undefined" runat="server" src="~/assets/img/historybanner.png" style="width:1349px; height:450px; padding-bottom:10px;"></div>
          
                                <div class="col-md-12 col-sm-12">
                                    <!-- BEGIN PORTLET-->
                                    <div class="portlet light ">
                                        <div class="portlet-title tabbable-line">
                                            <div class="caption">
                                                <i class="icon-globe font-dark hide"></i>
                                                <h2 class="caption-subject font-green bold uppercase">Marikina’s Historical Development</h2> 
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <!--BEGIN TABS-->
                                            <div class="tab-content">
                                                <div>
                                                    <br />
                                                    <asp:FormView ID="FormView1" runat="server" DataSourceID="EntityDataSourceHistory">
             <ItemTemplate>
                <p class="parajustify">
                    <asp:Label Text='<%# Eval("history").ToString().Replace(Environment.NewLine,"<br />") %>' ID="Label1" runat="server" ></asp:Label>
                </p> 
             </ItemTemplate>
           </asp:FormView>
           <asp:EntityDataSource ID="EntityDataSourceHistory" runat="server" 
               ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" 
               EnableFlattening="False" EntitySetName="headers" Select="it.[history]"></asp:EntityDataSource>
                                                    <br /><br />
                                                </div>
                                            </div>
                                            <!--END TABS-->
                                        </div>
                                    </div>
                                    <!-- END PORTLET-->
                                </div>
         
                              
</asp:Content>
