<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CustomizationTest.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    About
    <asp:LinkButton ID="btnAbout" Text="About" PostBackUrl="~/Contact.aspx" runat="server"></asp:LinkButton>    
</asp:Content>
