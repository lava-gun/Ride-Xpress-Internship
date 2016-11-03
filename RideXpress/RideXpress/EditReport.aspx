<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RideXpress.Master" AutoEventWireup="true" CodeBehind="EditReport.aspx.cs" Inherits="RideXpress_StarterKit.EditReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="first">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 text-center">
                    <h1>Edit Incident Report</h1>
                </div>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <!--ASP.NET Label Control goes here-->
                    <asp:Label ID="Ridelbl" runat="server" Text="Ride" AssociatedControlID="DD1" CssClass="col-xs-4 control-label"></asp:Label>
                    <div class="col-xs-4">
                        <!--ASP.NET Server Control goes here (TextBox, DropDownList, etc.)-->
                        <asp:DropDownList ID="DD1" runat="server" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList>
                        <div class="has-error">
                            <span class="help-block">
                                <!--Validation Controls go here-->
                                <asp:RequiredFieldValidator ID="RideRequired" runat="server" ErrorMessage="Ride is Required" InitialValue="-- Select a Ride --"
                                     ControlToValidate="DD1" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <!--ASP.NET Label Control goes here-->
                    <asp:Label ID="Datelbl" runat="server" Text="Date of Incident" AssociatedControlID="Date" CssClass="col-xs-4 control-label"></asp:Label>
                    <div class="col-xs-4">
                        <!--ASP.NET Server Control goes here (TextBox, DropDownList, etc.)-->
                        <asp:TextBox ID="Date" runat="server" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                        <div class="has-error">
                            <span class="help-block">
                                <!--Validation Controls go here-->
                                <asp:RequiredFieldValidator ID="DateRequired" runat="server" ErrorMessage="Incident Date is Required"
                                    ControlToValidate="Date" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="DateRange" runat="server" ControlToValidate="Date" ErrorMessage="Date must be before today's date" Type="Date" Display="Dynamic"></asp:RangeValidator>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                <!--ASP.NET Label Control goes here-->
                    <asp:Label ID="Namelbl" runat="server" Text="Name of Report" AssociatedControlID="Name" CssClass="col-xs-4 control-label"></asp:Label>
                    <div class="col-xs-4">
                        <!--ASP.NET Server Control goes here (TextBox, DropDownList, etc.)-->
                        <asp:TextBox ID="Name" runat="server" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                        <div class="has-error">
                            <span class="help-block">
                            <!--Validation Controls go here-->
                                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ErrorMessage="Name is Required"
                                    ControlToValidate="Name" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <!--ASP.NET Label Control goes here-->
                    <asp:Label ID="Descriptionlbl" runat="server" Text="Description" AssociatedControlID="Description" CssClass="col-xs-4 control-label"></asp:Label>
                    <div class="col-xs-4">
                        <!--ASP.NET Server Control goes here (TextBox, DropDownList, etc.)-->
                        <asp:TextBox ID="Description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" MaxLength="200"></asp:TextBox>
                        <div class="has-error">
                            <span class="help-block">
                                <!--Validation Controls go here-->
                                <asp:RequiredFieldValidator ID="DescriptionRequired" runat="server" ErrorMessage="Descritption is Required"
                                    ControlToValidate="Description" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-4 col-xs-offset-4">
                        <!--This is where your Submit button will go, you will use the OnClick Event to grab data from the form-->
                        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="ReportAddButton_Click" ValidationGroup="AllValidators"/>
                        <asp:HyperLink CssClass="btn btn-default" NavigateUrl="~/Reports.aspx" runat="server" Text="Back" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
