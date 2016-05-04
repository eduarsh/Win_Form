<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Project_314529157.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnlM" runat="server">
        <table class="auto-style1">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="egas" runat="server" Text="Enroll Group Activity System (EGAS)" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" >
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="lbUN" runat="server" Text="User Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUN" runat="server" OnTextChanged="tbUN_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="usValidator" runat="server" ControlToValidate="tbUN" ErrorMessage="Please Enter User Name">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularUN" runat="server" ControlToValidate="tbUN" ErrorMessage="User name exist from 5 to 7 " ValidationExpression="[a-zA-Z]{5,7}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbUC" runat="server" Text="User code:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUC" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter User Code" ControlToValidate="tbUC">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbUC" ErrorMessage="Wrong User Code" ValidationExpression="[a-zA-Z]{2}[0-9]{4}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbpass" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Password" ControlToValidate="tbPass">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbPass" ErrorMessage="Passwor not as needed" ValidationExpression="((?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{7,20})">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3" align="center" colspan="2">
                                <asp:Button ID="btlog" runat="server" Text="Login" OnClick="btlog_Click" />
                            </td>
                        </tr>
                    </table>
                    <table class="auto-style1" >
                        <tr >
                            <td class="auto-style3" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3" colspan="2">
                                <asp:Label ID="lblproducer" runat="server" Font-Bold="True" Text="c 2014 Eduard Shuhman 314529157"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
