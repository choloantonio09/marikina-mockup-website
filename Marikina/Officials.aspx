<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Officials.aspx.cs" Inherits="Marikina.Officials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="image"><img class="undefined" runat="server" src="~/assets/img/cityofficialbanner.png" style="width:1349px; height:450px; padding-bottom:10px;"></div>
        
    <br /><br />
        <hgroup class="title" style="text-align:center;">
            <h3>Marikina City Officials</h3>
        </hgroup>
    <br /><br />
    <div class="page-content">
        <div class="container">
             <div class="page-content-inner">
                  <div class="row">
                                <div class="col-md-6 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-star"></i>
                                                <span class="caption-subject bold font-grey-gallery uppercase"> Mayor </span>
                                            </div>
                                            
                                        </div>
                                        <div class="portlet-body">
                                            <div ID="mayorDiv" runat="server" style="text-align:center"> <!-- MAYOR DIV -->
                                                <h3>City Mayor</h3>
                                                <asp:Image ID="MayorImage"  Width="200px" Height="230px" runat="server" />
                                                <br />
                                                <div style="text-align:justify">
                                                <asp:FormView ID="MayorFormView" runat="server" DataSourceID="MayorEDS">
                                                    <ItemTemplate>
                                                        <h3>Name: </h3>
                                                        <asp:Label ID="MayorName" Text='<%# Eval("official_name").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                                                        <br /><br />
                                                        <h3>Description: </h3>
                                                        <asp:Label ID="MayorDescription" Text='<%# Eval("official_desc").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                                                        <br /><br />
                                                    </ItemTemplate>
                                                </asp:FormView>
                                                </div >
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END GRID PORTLET-->
                                </div>
                              
                                <div class="col-md-6 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-star"></i>
                                                <span class="caption-subject bold font-grey-gallery uppercase"> Vice Mayor </span>
                                            </div>
                                            <div class="tools">
                                                <a href="" class="collapse"> </a>
                                                <a href="" class="fullscreen"> </a>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <div id="viceMayorDiv" runat="server" style="text-align:center"> <!-- VICE MAYOR DIV -->

                                            <h3>City Vice Mayor</h3>
                                            <asp:Image ID="ViceMayorImage" Width="200px" Height="230px" runat="server" />
                                            <br />
                                            <div style="text-align:justify">
                                                <asp:FormView ID="FormView1" runat="server" DataSourceID="ViceMayorEDS">
                                                    <ItemTemplate>
                                                        <h3>Name: </h3>
                                                        <asp:Label ID="ViceMayorName" Text='<%# Eval("official_name").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                                                        <br /><br />
                                                        <h3>Description: </h3>
                                                        <asp:Label ID="ViceMayorDescription" Text='<%# Eval("official_desc").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server" ></asp:Label>
                                                        <br /><br />
                                                    </ItemTemplate>
                                                </asp:FormView>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END GRID PORTLET-->
                                </div>
                   </div>
                 
                  <div class="row">
                                <div class="col-md-12 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-star"></i>
                                                <span class="caption-subject bold font-grey-gallery uppercase"> Mayor </span>
                                            </div>
                                           
                                        </div>
                                        <div class="portlet-body">
                                            <div id="councilorDiv" runat="server" >
                                                <h3 style="text-align:center">District 1: Councilors</h3>
                                                <br />
                                                <br />
                                                <asp:Table ID="District1Table" Width="100%" HorizontalAlign="Center" runat="server">
            
                                                </asp:Table>



                                                <br />
                                                <br />
                                                <br />


                                                <h3 style="font-size:25px;text-align:center">District 2: Councilors</h3>
                                                <asp:Table ID="District2Table" Width="100%" HorizontalAlign="Center" runat="server">
           
                                                </asp:Table>
                                                <br />
        
                                            </div>
                                        </div>
                                    </div>
                                    <!-- END GRID PORTLET-->
                                </div>
                              
                   </div>

                 <div class="row">
                                <div class="col-md-12 ">
                                    <!-- BEGIN Portlet PORTLET-->
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-star"></i>
                                                <span class="caption-subject bold font-grey-gallery uppercase"> Mayor </span>
                                            </div>
                                           
                                        </div>
                                        <div class="portlet-body">
                                            <div id ="barangayDiv" runat="server" >

                                                <h3>District 1: Barangay Captains</h3>
                                                <br /><br />
                                                <asp:GridView ID="GridView1" runat="server" DataSourceID="BarangayD1EDS" DataKeyNames="official_id"  AutoGenerateColumns="False" Width="621px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="NAME" DataField="official_name" SortExpression="official_id" />
                                                        <asp:BoundField HeaderText="BARANGAY" DataField="official_barangay" SortExpression="official_id" />
                                                        <asp:BoundField HeaderText="CONTACT" DataField="official_contact" SortExpression="official_id" />
                                                    </Columns>
                                                    <EditRowStyle BackColor="#7C6F57" />
                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#E3EAEB" />
                                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                </asp:GridView>

                                                <br /><br /><br />

                                                <h3>District 2: Barangay Captains</h3>
                                                <br /><br />

                                                <asp:GridView ID="GridView2" runat="server" DataSourceID="BarangayD2EDS" DataKeyNames="official_id" AutoGenerateColumns="False" Width="620px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="NAME" DataField="official_name" SortExpression="official_id" />
                                                        <asp:BoundField HeaderText="BARANGAY" DataField="official_barangay" SortExpression="official_id" />
                                                        <asp:BoundField HeaderText="CONTACT" DataField="official_contact"  SortExpression="official_id" />
                                                    </Columns>
                                                    <EditRowStyle BackColor="#7C6F57" />
                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#E3EAEB" />
                                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                </asp:GridView>

                                            </div>    
                                        </div>
                                    </div>
                                    <!-- END GRID PORTLET-->
                                </div>
                              
                   </div>
             </div>
         </div>
     </div>






    <br />
    <br />
    <br />

    <div id="roles"> <!-- DROP DOWN LIST FOR ROLES -->
        <h2>Select from the dropdown-list: </h2>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="listItemClick" >
            <asp:ListItem>Mayor</asp:ListItem>
            <asp:ListItem>Vice Mayor</asp:ListItem>
            <asp:ListItem>Councilors</asp:ListItem>
            <asp:ListItem>Barangay Captains</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="selectedItem" runat="server" ></asp:Label>

    </div>
    <br /><br />
    

    

    



 

    <asp:EntityDataSource ID="MayorEDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" EntityTypeFilter="" Select="" Where="It.official_role = 'Mayor'"></asp:EntityDataSource>
    <asp:EntityDataSource ID="BarangayD1EDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" Where='It.official_role = "District 1: Barangay Captain"'></asp:EntityDataSource>
    <asp:EntityDataSource ID="BarangayD2EDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials"  Where='It.official_role = "District 2: Barangay Captain"'></asp:EntityDataSource>
    <asp:EntityDataSource ID="ViceMayorEDS" runat="server" ConnectionString="name=marikinaDBEntities" DefaultContainerName="marikinaDBEntities" EnableFlattening="False" EnableUpdate="True" EntitySetName="officials" EntityTypeFilter="" Select="" Where="It.official_role = 'Vice Mayor'"></asp:EntityDataSource>

</asp:Content>
