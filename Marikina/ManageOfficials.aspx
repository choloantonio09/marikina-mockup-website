<%@ Page Title="Manage Officials" Language="C#" MaintainScrollPositionOnPostback="false"  EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ManageOfficials.aspx.cs" Inherits="Marikina.ManageOfficials" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="image"><img class="undefined" runat="server" src="~/assets/img/maintenancebanner.png" style="width:1349px; height:450px; padding-bottom:10px;"></div>
        
    <br /><br />
    <div class="page-container-bg-solid">
        
        <!-- BEGIN CONTAINER -->
        <div class="page-container">
            <!-- BEGIN CONTENT -->
            <div class="page-content-wrapper">
                
                <!-- BEGIN PAGE CONTENT BODY -->
                <div class="page-content">
                    <div class="container">
                        <!-- BEGIN PAGE BREADCRUMBS -->
                        
                        <!-- END PAGE BREADCRUMBS -->
                        <!-- BEGIN PAGE CONTENT INNER -->
                        <div class="page-content-inner">
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- BEGIN PROFILE SIDEBAR -->
                                    <div class="profile-sidebar">
                                        <!-- PORTLET MAIN -->
                                        <div class="portlet light profile-sidebar-portlet ">
                                            
                                            <!-- SIDEBAR USER TITLE -->
                                            <div class="profile-usertitle">
                                                

                                                <div class="profile-usertitle-name"> <p><%: User.Identity.Name %></p> </div>
                                                <div class="profile-usertitle-job"> Administrator </div>
                                            </div>
                                            <!-- END SIDEBAR USER TITLE -->
                                            <!-- SIDEBAR BUTTONS -->
                                           
                                            <!-- END SIDEBAR BUTTONS -->
                                            <!-- SIDEBAR MENU -->
                                            <div class="profile-usermenu">
                                                <ul class="nav">
                                                    
                                                    <li >
                                                        <a href="~/Account/Manage.aspx" runat="server">
                                                            <i class="icon-settings"></i> Website Maintenance </a>
                                                    </li>
                                                    <li class="active">
                                                        <a href="../ManageOfficials.aspx">
                                                            <i class="icon-settings"></i> Manage Official </a>
                                                      
                                                    </li>
                                                    <li>
                                                        <a href="../ManageEvents.aspx">
                                                            <i class="icon-settings"></i> Manage Events </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="icon-settings"></i> Manage Annoucements </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- END MENU -->
                                        </div>
                                        <!-- END PORTLET MAIN -->
                                    </div>
                                    <!-- END BEGIN PROFILE SIDEBAR -->
                                    <!-- BEGIN PROFILE CONTENT -->
                                    <div class="profile-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="portlet light ">
                                                    <div class="portlet-title tabbable-line">
                                                        <div class="caption caption-md">
                                                            <i class="icon-globe theme-font hide"></i>
                                                            <span class="caption-subject font-blue-madison bold uppercase">Profile Account</span>
                                                        </div>
                                                        <ul class="nav nav-tabs">
                                                            <li class="active">
                                                                <a href="#tab_1_1" data-toggle="tab">Manage Officials</a>
                                                            </li>
                                                            
                                                        </ul>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="tab-content">
                                                            <!-- PERSONAL INFO TAB -->
															<!-- CHANGE PASSWORD TAB -->
                                                            <div class="tab-pane active" id="tab_1_1"> 
                                                           
                                                            

                                                                
    <div id="roles"> <!-- DROP DOWN LIST FOR ROLES -->
        <span>Select a role : </span>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="listItemClick" class="btn btn-default">
            <asp:ListItem>Mayor</asp:ListItem>
            <asp:ListItem>Vice Mayor</asp:ListItem>
            <asp:ListItem>Councilors</asp:ListItem>
            <asp:ListItem>Barangay Captains</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="selectedItem" runat="server" ></asp:Label>

    </div>
    <br /><br />
    <div ID="mayorDiv" runat="server" style="text-align:justify"> <!-- MAYOR DIV -->
        <h3>City Mayor</h3>


                                                               
                                                                <br />
                                                                
                                                                
                                                              
                                                                <br />




                                                                <div class="fileinput fileinput-new" data-provides="fileinput" style="text-align:center;">
                                                                         <asp:FileUpload ID="FileUploadMayor" runat="server" accept=".png,.jpg,.jpeg,.gif,.bmp" /> 
                                                                         <br />
                                                                        <div class="fileinput-new thumbnail" style="width: 370px; height: 400px; text-align:center;">
                                                                                <asp:Image ID="MayorImage" Width="370px" Height="400px" runat="server" />
                                                                        </div>
                                                                        <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 370px; max-height: 400px;"> </div>
                                                                        <div>
                                                                            
                                                                            <span>
                                                                                <a href="javascript:;" class="btn default fileinput-exists" data-dismiss="fileinput"> Remove </a>
                                                                            </span>
                                                                            <span>
                                                                                <asp:Button ID="btnMayorUpload" runat="server" Text="Upload" OnClick="UploadMayor" class="btn green"/>
                                                                            </span>
                                                                        </div>    
                                                                   </div>



        <asp:FormView ID="MayorFormView" runat="server" DataSourceID="MayorEDS" DataKeyNames="official_id">
            <ItemTemplate>
                <h3>Name: </h3>
                <asp:Label ID="MayorName" Text='<%# Eval("official_name").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                <br /><br />
                <h3>Description: </h3>
                <asp:Label ID="MayorDescription" Text='<%# Eval("official_desc").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                <br /><br />
                <asp:Button runat="server" Text="Edit" CommandName="Edit" ID="MayorEditButton" CausesValidation="False" class="btn green"/>
            </ItemTemplate>
            <EditItemTemplate>
                <h3>Name: </h3>
                <asp:TextBox Text='<%# Bind("official_name") %>' runat="server" ID="mayorNameTextBox" Rows="1" Columns="100" width="100%" style="border: 1px solid #38C5D2;"/><br />
                <br /><br />
                <h3>Description: </h3>
                <asp:TextBox Text='<%# Bind("official_desc") %>' runat="server" ID="mayorDescTextBox" TextMode="MultiLine" Rows="20" Columns="300" width="100%" style="border: 1px solid #38C5D2;"/><br />
                <br /><br />
                <asp:Button runat="server" Text="Update" CommandName="Update" ID="UpdateMayorButton" CausesValidation="True" class="btn green"/>&nbsp;
                <asp:Button runat="server" Text="Cancel" CommandName="Cancel" ID="MayorUpdateCancelButton" CausesValidation="False" class="btn default"/>
            </EditItemTemplate>
        </asp:FormView>
    </div>

    <div id="viceMayorDiv" runat="server" style="text-align:justify"> <!-- VICE MAYOR DIV -->

        <h3>City Vice Mayor</h3>

                                                                    <div class="fileinput fileinput-new" data-provides="fileinput" style="text-align:center;">
                                                                          <asp:FileUpload ID="FileUploadViceMayor" runat="server" accept=".png,.jpg,.jpeg,.gif,.bmp" /> 
                                                                         <br />
                                                                        <div class="fileinput-new thumbnail" style="width: 370px; height: 400px; text-align:center;">
                                                                                <asp:Image ID="ViceMayorImage" Width="370px" Height="400px" runat="server" />
                                                                        </div>
                                                                        <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 370px; max-height: 400px;"> </div>
                                                                        <div>
                                                                            
                                                                            <span>
                                                                                <a href="javascript:;" class="btn default fileinput-exists" data-dismiss="fileinput"> Remove </a>
                                                                            </span>
                                                                            <span>
                                                                                <asp:Button ID="viceMayorUpload" runat="server" Text="Upload" OnClick="UploadViceMayor" class="btn green"/>
                                                                              
                                                                            </span>
                                                                        </div>    
                                                                   </div>


        
        <br />
       
        
        <br />
        <br />
        <asp:FormView ID="FormView1" runat="server" DataSourceID="ViceMayorEDS" DataKeyNames="official_id" >
            <ItemTemplate>
                <h3>Name: </h3>
                <asp:Label ID="ViceMayorName" Text='<%# Eval("official_name").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                <br /><br />
                <h3>Description: </h3>
                <asp:Label ID="ViceMayorDescription" Text='<%# Eval("official_desc").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                <br /><br />
                <asp:Button runat="server" Text="Edit" CommandName="Edit" ID="ViceMayorEditButton" CausesValidation="False"  class="btn green"/>
            </ItemTemplate>
            <EditItemTemplate>
                <h3>Name: </h3>
                <asp:TextBox Text='<%# Bind("official_name") %>' runat="server" ID="viceMayorNameTextBox" Rows="1" Columns="100" width="100%" style="border: 1px solid #38C5D2;"/><br />
                <br /><br />
                <h3>Description: </h3>
                <asp:TextBox Text='<%# Bind("official_desc") %>' runat="server" ID="viceMayorDescTextBox" TextMode="MultiLine" Rows="20" Columns="300" width="100%" style="border: 1px solid #38C5D2;"/><br />
                <br /><br />
                <asp:Button runat="server" Text="Update" CommandName="Update" ID="UpdateViceMayorButton" CausesValidation="True"  class="btn green"/>&nbsp;
                <asp:Button runat="server" Text="Cancel" CommandName="Cancel" ID="ViceMayorUpdateCancelButton" CausesValidation="False" class="btn default"/>
            </EditItemTemplate>
        </asp:FormView>

    </div>
    
    <div id="councilorDiv" runat="server" >
        <h3 style="text-align:center">District 1: Councilors</h3>
        <br />
        <br />
        <asp:Table ID="District1Table" Width="100%" HorizontalAlign="Center" runat="server">
            <asp:TableHeaderRow ID="District1HeaderRow1" runat="server" Text="" >
                <asp:TableHeaderCell>Officials' Images and Names</asp:TableHeaderCell>
                <asp:TableHeaderCell>EDIT HERE</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>



        <br />
        <br />
        <br />


        <h3 style="font-size:25px;text-align:center">District 2: Councilors</h3>
        <asp:Table ID="District2Table" Width="100%" HorizontalAlign="Center" runat="server">
            <asp:TableHeaderRow ID="District1HeaderRow2" runat="server" Text="" >
                <asp:TableHeaderCell>Officials' Images and Names</asp:TableHeaderCell>
                <asp:TableHeaderCell>EDIT HERE</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <asp:Button ID="CouncilorSave" runat="server" Text="SAVE CHANGES" OnClick="CouncilorSetData" Width="" Height="30px" CssClass="btn green" />
    </div>


    <div id ="barangayDiv" runat="server" >

        <h3>District 1: Barangay Captains</h3>
        <br /><br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="BarangayD1EDS" DataKeyNames="official_id"  AutoGenerateColumns="False" Width="780px" style="border: 1px solid #38C5D2;">
            <Columns>
                <asp:CommandField ShowEditButton="True"/>
                <asp:BoundField HeaderText="NAME" DataField="official_name" SortExpression="official_id"/>
                <asp:BoundField HeaderText="BARANGAY" DataField="official_barangay" SortExpression="official_id" />
                <asp:BoundField HeaderText="CONTACT" DataField="official_contact" SortExpression="official_id" />
            </Columns>
        </asp:GridView>

        <br /><br /><br />

        <h3>District 2: Barangay Captains</h3>
        <br /><br />

        <asp:GridView ID="GridView2" runat="server" DataSourceID="BarangayD2EDS" DataKeyNames="official_id" AutoGenerateColumns="False" Width="780px" style="border: 1px solid #38C5D2;">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField HeaderText="NAME" DataField="official_name" SortExpression="official_id" />
                <asp:BoundField HeaderText="BARANGAY" DataField="official_barangay" SortExpression="official_id" />
                <asp:BoundField HeaderText="CONTACT" DataField="official_contact"  SortExpression="official_id" />
            </Columns>
        </asp:GridView>

    </div> 

    <asp:EntityDataSource ID="MayorEDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" EntityTypeFilter="official" Where="It.official_role = 'Mayor'"></asp:EntityDataSource>
    <asp:EntityDataSource ID="BarangayD1EDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" Where='It.official_role = "District 1: Barangay Captain"'></asp:EntityDataSource>
    <asp:EntityDataSource ID="BarangayD2EDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials"  Where='It.official_role = "District 2: Barangay Captain"'></asp:EntityDataSource>
    <asp:EntityDataSource ID="ViceMayorEDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" EntityTypeFilter="official" Where="It.official_role = 'Vice Mayor'"></asp:EntityDataSource>




















                                                            </div>
                                                            <!-- END CHANGE PASSWORD TAB -->
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END PROFILE CONTENT -->
                                </div>
                            </div>
                        </div>
                        <!-- END PAGE CONTENT INNER -->
                    </div>
                </div>
                <!-- END PAGE CONTENT BODY -->
                <!-- END CONTENT BODY -->
            </div>
            <!-- END CONTENT -->
            
        </div>
    </div>












    

</asp:Content>
