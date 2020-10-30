<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="ChristmasClub.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Contact page.</p>

    <address>
        Billie Warnasch<br />
        Payroll Dept. <br />
        <abbr title="Phone">P:</abbr>
        Ext: 4206
    </address>
    <address>
        Ann Conrad<br />
        Payroll Dept. <br />
        <abbr title="Phone">P:</abbr>
        Ext: 4354 
    </address>
    <address>
        <strong>Support:</strong><a href="mailto:cricks@brookshirebros.com">Having a Problem with the program?</a><br />
        <strong>Payroll:</strong><a href="aconrad@brookshirebros.com">Need to Email the Payroll Department?</a>
    </address>
</asp:Content>
