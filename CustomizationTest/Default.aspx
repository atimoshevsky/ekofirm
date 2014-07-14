<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomizationTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h1>Test customization interface
            </h1>

            <asp:PlaceHolder ID="phCurrency" runat="server"></asp:PlaceHolder>

            <asp:Button ID="btnSubmitForm" runat="server" OnClick="btnSubmitForm_Click" Text="Submit" />

            <asp:Label ID="lblCurrentCurrency" runat="server"></asp:Label>
        </div>
    </div>

    <input value="Modal Lunch" type="button" id="myElement" />
    <div id="Embed" style="display:none; position:absolute; left:30%; top:20%;">
        <iframe src="Contact.aspx" style="width: 600px; height: 400px;"></iframe>
    </div>

    <script type="text/javascript">
        $("#myElement").on("click", function (e) {
            $("#Embed").show();
        });
    

    </script>
</asp:Content>
