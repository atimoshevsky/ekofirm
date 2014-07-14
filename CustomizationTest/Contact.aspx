<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CustomizationTest.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Contact
    <asp:LinkButton ID="btnAbout" Text="Contact" PostBackUrl="~/About.aspx" runat="server"></asp:LinkButton>    
</asp:Content>
