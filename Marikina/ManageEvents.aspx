<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ManageEvents.aspx.cs" Inherits="Marikina.ManageEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">






    <hgroup class="title">
        <h1>Manage Events</h1>
    </hgroup>

    <br /><br />

    <div id="AddNewDiv">

        <h2>Create an Event:</h2><br /><br />
        <asp:Label ID="Label5" runat="server" Text="POSTER: " /><br />
        <asp:Image ID="NewImage" Width="250px" Height="300px" runat="server" /><asp:FileUpload ID="NewUpload" runat="server" ClientIDMode="Static" /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="EVENT NAME: " /><asp:TextBox ID="NewName" runat="server" Columns="100"/><br /><br />
        <asp:Label ID="Label2" runat="server" Text="DESCRIPTION: " /><br />
        <asp:TextBox ID="NewDesc" runat="server" Rows="7" Columns="100" TextMode="MultiLine" /><br /><br />
        <asp:Label ID="Label3" runat="server" Text="DATE AND TIME OF EVENT:" />&nbsp;<input type="datetime-local" id="NewDateTime" runat="server" /><br /><br />
        <asp:Label ID="Label4" runat="server" Text="LOCATION: " /><asp:TextBox ID="NewLocation" runat="server" Columns="100"/>
        <br />
        <br />
        <asp:Button ID="NewCreate" runat="server" Text="Create" OnClick="CreateNew" />

    </div>

    <br /><br /><br />

    <div id="UpcomingDiv">




        <asp:EntityDataSource ID="UpcomingEventsEDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableInsert="True" EntitySetName="events" EntityTypeFilter="event" Where="It.event_status = &quot;Upcoming&quot;"></asp:EntityDataSource>

    </div>

    <div id="FinishedDiv">

    </div>

</asp:Content>
