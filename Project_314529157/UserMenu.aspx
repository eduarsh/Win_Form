<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMenu.aspx.cs" Inherits="Project_314529157.UserMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Panel ID="pnlUM" runat="server">
        <table align ="center">
            <tr>
                <td colspan="7" align ="center">
                    <asp:Label ID="lbPersonalDetails" runat="server" Text="Personal Details" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="7">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="val1" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="val2" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="val3" />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lbPSFirstName" runat="server" Text="First Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDFNL" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDLastName" runat="server" Text="Last Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDLNL" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDIDl" runat="server" Text="ID:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbPDEmail" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDEMAILL" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDCourseArea" runat="server" Text="Course area:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lbPDCAL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbPDUserName" runat="server" Text="User name:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDUNL" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDUserCode" runat="server" Text="User code:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lbPDUCL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbPDTotalCorses" runat="server" Text="Total courses:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDTCL" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbPDTotalPrice" runat="server" Text="Total Price:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lbPDTPL" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:Label ID="lbPDChangeUserName" runat="server" Text="Change Username" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbPDNewUserName" runat="server" Text="New Username"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPDNewUserName" runat="server" ValidationGroup="val1"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbPDNewUserName" ErrorMessage="Please Enter User Name" ValidationGroup="val1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbPDNewUserName" ErrorMessage="User name exist from 5 to 7 " ValidationExpression="[a-zA-Z]{5,7}" ValidationGroup="val1">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btPDNUNChange" runat="server" Text="Change" OnClick="btPDNUNChange_Click" ValidationGroup="val1" />
                </td>
            </tr>
            <tr>
                <td colspan="7" >
                    <asp:Label ID="lbPDCUC" runat="server" Text="Change user code" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbPDNewUserCode" runat="server" Text="New user code:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPDNewUserCode" runat="server" ValidationGroup="val2"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPDNewUserCode" ErrorMessage="Please Enter User Code" ValidationGroup="val2">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbPDNewUserCode" ErrorMessage="Wrong User Code" ValidationGroup="val2">*</asp:RegularExpressionValidator>
                    <asp:Button ID="tbPDNUCChange" runat="server" Text="Change" ValidationGroup="val2" OnClick="tbPDNUCChange_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:Label ID="lbPDCUP" runat="server" Text="Change User password" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbPDOP" runat="server" Text="Old password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPDOldPasswors" runat="server" ValidationGroup="val3" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbPDOldPasswors" ErrorMessage="Enter Password" ValidationGroup="val3">*</asp:RequiredFieldValidator>
                    <asp:Label ID="lbPDNewPassword" runat="server" Text="New password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPDNewPassword" runat="server" ValidationGroup="val3" TextMode="Password"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPDNewPassword" ErrorMessage="Enter Password" ValidationGroup="val3">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbPDNewPassword" ErrorMessage="Incorect Password" ValidationExpression="((?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{7,20})" ValidationGroup="val3">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btPDPasswordChange" runat="server" Text="Change" ValidationGroup="val3" OnClick="btPDPasswordChange_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:Label ID="lbUPCR" runat="server" Text="Course Registration"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPDcn" runat="server" Text="Course name:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlcn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcn_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblPDcs" runat="server" Text="Course syllabus:"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="hlnPD" runat="server" Font-Underline="True" ForeColor="Blue">HyperLink</asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblPDp" runat="server" Text="Price:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="lblPDreg" runat="server" Text="Register" OnClick="lblPDreg_Click" />
                </td>
            </tr>
        </table>
         </asp:Panel>
    
    </div>
    </form>
</body>
</html>
