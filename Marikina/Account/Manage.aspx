<%@ Page Title="Manage Account" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Marikina.Account.Manage" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
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
                                                <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                                                    <p class="message-success"><%: SuccessMessage %></p>
                                                </asp:PlaceHolder>

                                                <div class="profile-usertitle-name"> <p><%: User.Identity.Name %></p> </div>
                                                <div class="profile-usertitle-job"> Administrator </div>
                                            </div>
                                            <!-- END SIDEBAR USER TITLE -->
                                            <!-- SIDEBAR BUTTONS -->
                                           
                                            <!-- END SIDEBAR BUTTONS -->
                                            <!-- SIDEBAR MENU -->
                                            <div class="profile-usermenu">
                                                <ul class="nav">
                                                    
                                                    <li class="active">
                                                        <a href="~/Account/Manage.aspx" runat="server">
                                                            <i class="icon-settings"></i> Website Maintenance </a>
                                                    </li>
                                                    <li>
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
                                                                <a href="#tab_1_1" data-toggle="tab">Change Password</a>
                                                            </li>
                                                            <li>
                                                                <a href="#tab_1_2" data-toggle="tab">Change Logo</a>
                                                            </li>
                                                            <li>
                                                                <a href="#tab_1_3" data-toggle="tab">Change Banner</a>
                                                            </li>
                                                            <li>
                                                                <a href="#tab_1_4" data-toggle="tab">Edit History, Vision & Mission</a>
                                                            </li>
															
                                                        </ul>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="tab-content">
                                                            <!-- PERSONAL INFO TAB -->
															<!-- CHANGE PASSWORD TAB -->
                                                            <div class="tab-pane active" id="tab_1_1"> 
                                                            <section id="passwordForm">
                                                                <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                                                                    <fieldset>
                                                                       <form action="#"> 
                                                                        <div class="form-group">
                                                                                <asp:Label runat="server" AssociatedControlID="password" class="control-label">Password</asp:Label>
                                                                                <asp:TextBox runat="server" ID="password" TextMode="Password" class="form-control"/>
                                                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                                                                    CssClass="field-validation-error errorcolor" ErrorMessage="The password field is required."
                                                                                    Display="Dynamic" ValidationGroup="SetPassword" />
                        
                                                                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                                                                    CssClass="field-validation-error" SetFocusOnError="true" />
                        
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <asp:Label runat="server" AssociatedControlID="confirmPassword" class="control-label">Confirm password</asp:Label>
                                                                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" class="form-control"/>
                                                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                                                                    CssClass="field-validation-error errorcolor" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                                                                    ValidationGroup="SetPassword" />
                                                                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                                                                    CssClass="field-validation-error errorcolor" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                                                                    ValidationGroup="SetPassword" />
                                                                            </div>
                                                                         </form>
                                                                         <div class="margin-top-10">
                                                                            <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="setPassword_Click" class="btn green"/>
                                                                         </div>
                                                                    </fieldset>
                                                                </asp:PlaceHolder>

                                                                <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
                                                                    <h3>Change password</h3>
                                                                    <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage.aspx?m=ChangePwdSuccess">
                                                                        <ChangePasswordTemplate>
                                                                            <p class="validation-summary-errors">
                                                                                <asp:Literal runat="server" ID="FailureText" />
                                                                            </p>
                                                                            <fieldset class="changePassword">
                                                                               <form action="#"> 
                                                                                 <div class="form-group">
                                                                                        <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" class="control-label">Current password</asp:Label>
                                                                                        <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry form-control" TextMode="Password" />
                                                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                                                            CssClass="field-validation-error errorcolor" ErrorMessage="The current password field is required."
                                                                                            ValidationGroup="ChangePassword" />
                                                                                    </div>
                                                                                     <div class="form-group">
                                                                                        <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" class="control-label">New password</asp:Label>
                                                                                        <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry form-control" TextMode="Password" />
                                                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                                                                            CssClass="field-validation-error" ErrorMessage="The new password is required."
                                                                                            ValidationGroup="ChangePassword errorcolor" />
                                                                                    </div>
                                                                                     <div class="form-group">
                                                                                        <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" class="control-label">Confirm new password</asp:Label>
                                                                                        <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry form-control" TextMode="Password" />
                                                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                                                                            CssClass="field-validation-error errorcolor" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                                                                            ValidationGroup="ChangePassword" />
                                                                                        <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                                                            CssClass="field-validation-error errorcolor" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                                                                            ValidationGroup="ChangePassword" />
                                                                                    </div>
                                                                                </form>
                                                                                <div class="margin-top-10">
                                                                                <asp:Button runat="server" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" class="btn green"/>
                                                                                </div>
                                                                            </fieldset>
                                                                        </ChangePasswordTemplate>
                                                                    </asp:ChangePassword>
                                                                </asp:PlaceHolder>
                                                            </section>
                                                            


                                                            </div>
                                                            <!-- END CHANGE PASSWORD TAB -->
                                                          
                                                            <!-- CHANGE AVATAR TAB -->
                                                            <div class="tab-pane" id="tab_1_2">
                                                               
                                                                 <div id ="changeLogo">
                                                                    <h3><asp:Label ID="Label1" runat="server" Text="CHANGE THE LOGO HERE: "></asp:Label></h3>
                                                                    <asp:Label ID="LabelLogo" runat="server"></asp:Label>
                                                                    <br />
                                                                      <p> Current Logo: </p>
                                                                    <div class="fileinput fileinput-new" data-provides="fileinput">
                                                                         
                                                                                <asp:FileUpload ID="FileUploadLogo" runat="server" accept=".png,.jpg,.jpeg,.gif" /> 
                                                                         <br />
                                                                        <div class="fileinput-new thumbnail" style="width: 200px; height: 150px; text-align:center;">
                                                                               <asp:Image ID="ImageLogo" height="300px" Width ="300px" runat="server" />
                                                                        </div>
                                                                        <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>
                                                                        <div>
                                                                            
                                                                            <span>
                                                                                <a href="javascript:;" class="btn default fileinput-exists" data-dismiss="fileinput"> Remove </a>
                                                                            </span>
                                                                            <span>
                                                                                <asp:Button ID="btnLogoUpload" runat="server" Text="Upload" OnClick="UploadLogo" class="btn green"/>
                                                                            </span>
                                                                        </div>    
                                                                   </div>
                                                                </div>
                                                               
                                                            </div>
                                                            <!-- END CHANGE AVATAR TAB -->
															<!-- CHANGE AVATAR TAB -->
                                                            <div class="tab-pane" id="tab_1_3">
                                                                
                                                                   <div id ="changeBanner">
                                                                        <h3><asp:Label ID="Label2" runat="server" Text="CHANGE THE BANNER HERE: "></asp:Label></h3>
                                                                        <asp:Label ID="LabelBanner" runat="server"></asp:Label>
                                                                        <br /><p> Current Banner: </p>
                                                                        <div class="fileinput fileinput-new" data-provides="fileinput">
                                                                            <asp:FileUpload ID="FileUploadBanner" runat="server" accept=".png,.jpg,.jpeg,.gif" />
                                                                             <br />
                                                                            <div class="fileinput-new thumbnail" style="width: 770px; height: 400px; text-align:center;">
                                                                                <asp:Image ID="ImageBanner" height="600px" Width ="100%" runat="server" /> alt="" /> </div>
                                                                            <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 770px; max-height: 400px;"> </div>
                                                                            
                                                                            <div>
                                                                                <span>
                                                                                    <a href="javascript:;" class="btn default fileinput-exists" data-dismiss="fileinput"> Remove </a>
                                                                                </span>
                                                                                <span>
                                                                                    <asp:Button ID="ButtonBanner" runat="server" Text="Upload" OnClick="UploadBanner" class="btn green"/>
                                                                                </span>
                                                                            </div>  
                                                                            

                                                                           
                                                                            
                                                                        </div>
                                                                    </div>


                                                                    

                                                            </div>
                                                            <!-- END CHANGE AVATAR TAB -->
                                                              <div class="tab-pane" id="tab_1_4">
															  

                                                              
                                                            <div id ="historyVisionMission">


                                                                <asp:FormView ID="FormView1" runat="server" DataSourceID="HistoryVisionMissionEntityDataSource" DataKeyNames="header_id">
                                                                    <EditItemTemplate>
                
                                                                        <h2>History:</h2>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                        <asp:TextBox Text='<%# Bind("history") %>' runat="server" ID="historyTextBox" TextMode="MultiLine" style="border: 1px solid #38C5D2; width:760px; height:200px"/><br />
                                                                        </div>
                                                                        <br />
                                                                        <br />

                                                                        <h2>Vision:</h2>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                        <asp:TextBox Text='<%# Bind("vision") %>' runat="server" ID="visionTextBox" TextMode="MultiLine" style="border: 1px solid #38C5D2; width:760px; height:100px"  /><br />
                                                                        </div>
                                                                        <br />
                                                                        <br />

                                                                        <h2>Mission:</h2>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                        <asp:TextBox Text='<%# Bind("mission") %>' runat="server" ID="missionTextBox" TextMode="MultiLine" style="border: 1px solid #38C5D2; width:760px; height:100px" /><br />
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                        <asp:Button runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" class="btn green"/>&nbsp;
                                                                        <asp:Button runat="server" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" class="btn default"/>
                                                                    </EditItemTemplate>
            
                                                                    <ItemTemplate>
                                                                        <h2>History, Vision & Mission</h2>
                                                                          <asp:Button runat="server" Text="Edit" CommandName="Edit" ID="EditButton" CausesValidation="False" class="btn green"/>
                                                                     <br />
                                                                        <hr />
                                                                        </br>
                                                                        <h3>History:</h3>
                                                                        <br />
                                                                        <asp:Label Text='<%# Eval("history").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ID="Label4"  rows="12" cols="100" style="text-align: justify"/><br />
          
                                                                        <br />
                                                                        <br /><br />

                                                                        <h3>Vision:</h3>
                                                                        <br />
                                                                        <asp:Label Text='<%# Eval("vision").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ID="visionLabel"  rows="12" cols="100" style="text-align: justify"/><br />
                                                                        <br />
                                                                        <br /><br />

                                                                        <h3>Mission:</h3>
                                                                        <br />
                                                                        <asp:Label Text='<%# Eval("mission").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ID="missionLabel"  rows="12" cols="100" style="text-align: justify"/><br />
                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                       </ItemTemplate>
                                                                </asp:FormView>

                                                                <asp:EntityDataSource ID="HistoryVisionMissionEntityDataSource" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="headers">
                                                                </asp:EntityDataSource>

                                                            </div>




															</div>
                                                            <!-- END PERSONAL INFO TAB -->
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
