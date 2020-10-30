<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ChristmasClub._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Brookshire Brothers, Inc. </h1>
        <p class="lead">Use this page to sign up for the Brookshire Brothers Christmas Club for the year 2021.&nbsp; </p>
        <p><a href="About.aspx" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
          <asp:Panel ID="Panel1" runat="server">
                 <div class="col-md-4">
            <h2>To Sign Up...</h2>
                      <p>
                          This deduction is for the payroll periods from December 2020 to October 2021.&nbsp;
            </p>
            <p>
                Enter your Employee ID # <asp:TextBox ID="TextBox1" runat="server" Width="125px"></asp:TextBox> &nbsp;<asp:Button ID="cmdSignUp1" runat="server" Text="Find My Information" />
            </p>
            </asp:Panel>
        </div>
        <div class="col-md-4">      
            <asp:Panel ID="Panel2" runat="server" Enabled="False">
            <p>
                &nbsp;<asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            </p>
            <h2>Enter the $ to withhold</h2>
            <p> I authorize the payroll department to withhold the following weekly amount.&nbsp; </p>
            <p>
                Enter the weekly amount you want to withhold.&nbsp; It has to be in&nbsp; increments of $5 for example, you can save $5 or $10 or $50.</p>
                <p>
                    Monthly salaried employees weekly amount will be multiplied by 4.333 to calculate the monthly amount withheld.&nbsp;
                </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Enter the Amount" style="font-size: large"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtAmount" runat="server" Width="103px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdEnterAmount" runat="server" Text="submit" />
                &nbsp;<asp:Label ID="lblFTime" runat="server" Text="FullTime" Visible="False"></asp:Label>
                <asp:Label ID="lblMonthly" runat="server" Text="Monthly" Visible="False"></asp:Label>
                <asp:Label ID="lblJobCode" runat="server" Text="JobCode" Visible="False"></asp:Label>
                <asp:Label ID="lblSalary" runat="server" Text="Salary" Visible="False"></asp:Label>
                </p>
          
            </asp:Panel>
        
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel3" runat="server" Enabled="False">
             <h2>Click to authorize withholding...</h2>
            <p style="font-size: small">
                <em>I understand that this savings plan will be paid when the plan year is complete or upon my termination.&nbsp; If I terminate at any time during the plan year, I understand that I will receive my full contribution amount refunded to me at the earliest possible date.&nbsp; </em> </p>
            
            </p><p>
                    <span style="font-size: large"><strong>All enrollments must be received by November 20th, 2020</strong></span>.</p>
            <p>
                <asp:Label ID="lblInfo" runat="server" Text= "Employee Info "></asp:Label>
                 </p>
                <asp:Label ID="lblAmount" runat="server" Text="You will be putting back: $ "></asp:Label>
            <p>
                &nbsp;</p>
                <asp:Button ID="cmdSignUp0" runat="server" Text="Sign Me Up" />
                &nbsp;<br />
                <asp:Button ID="cmdChangeAmount" runat="server" Text="Edit Withholding" Width="316px" />
                &nbsp;&nbsp;
            </asp:Panel>
          
        </div>
   
<%--    <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                 ControlToValidate="txtAmount"
                 ValidationExpression="^\d+$"
                 Display="Static"
                 ErrorMessage="Only Numbers"
                 EnableClientScript="False" 
                 runat="server" EnableTheming="False" EnableViewState="False" ></asp:RegularExpressionValidator>--%>
</asp:Content>
