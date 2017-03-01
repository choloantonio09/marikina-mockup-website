<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Marikina.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    





      <div class="login">
        <br /> <br /><br /><br /><br /> <br /><br /><br />
    <div class="content">
    <section id="loginForm">
         <h3 class="form-title font-green">Sign In</h3>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span> Enter your username and password. </span>
                </div>
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="UserName" class="control-label visible-ie8 visible-ie9">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" class="form-control form-control-solid placeholder-no-fix" placeholder="Username"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error errorcolor" ErrorMessage="The user name field is required." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" class="control-label visible-ie8 visible-ie9">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control form-control-solid placeholder-no-fix" placeholder="Password"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error errorcolor" ErrorMessage="The password field is required." />
                        </div>
                        <asp:Button runat="server" CommandName="Login" Text="Log in" class="btn green uppercase"/>
                    <br /><br />
                    
                    
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <div class="create-account">
            <p>
                <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" class="uppercase">Create an account</asp:HyperLink>
            </p>
        </div>
        
        
    </section>
        

    </div>
          <div class="copyright"> 2016 © Marikina Login Page </div>
          <br />
    </div>
        <section id="socialLoginForm" class="control-label visible-ie8 visible-ie9">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>
</asp:Content>
