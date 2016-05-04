<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="Project_314529157.AdminMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
        }
        .auto-style6 {
        }
        .auto-style7 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td align="center">
                    <asp:Label ID="lbWorkerConsole" runat="server" Font-Bold="True" Text="Worker Console"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblUserMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="nu" />
                </td>
            </tr>
            <tr>
                <td>
                    <table align ="center">
                        <tr>
                            <td >
                                <asp:Button ID="btnAddU" runat="server" Text="Add new user" OnClick="btnAddU_Click" />
                            </td>
                            <td >
                                <asp:Button ID="btnUdateU" runat="server" Text="Update usrers" OnClick="btnUdateU_Click" />
                            </td>
                            <td >
                                <asp:Button ID="btnCoursesA" runat="server" Text="Courses Activity" OnClick="btnCoursesA_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td >
                     <asp:Panel ID="pnlam1" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lbNewUser" runat="server" Font-Bold="True" Text="New User"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lbNUFirtsName" runat="server" Text="First Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNUFirstName" runat="server" ValidationGroup="nu"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNUFirstName" ErrorMessage="Enter Frist name" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lbNULastName" runat="server" Text="Last Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNULastName" runat="server" ValidationGroup="nu"></asp:TextBox>
                            </td>
                            <td >
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbNULastName" ErrorMessage="Enter Last Name" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lbNUID" runat="server" Text="ID:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNUID" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNUID" ErrorMessage="Enter ID" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbNUID" ErrorMessage="ID contains 9 digits" ValidationExpression="[0-9]{9}" ValidationGroup="nu">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbPCA" runat="server" Text="Prefferd course area:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPCA" runat="server" OnSelectedIndexChanged="ddlPCA_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPCA" ErrorMessage="Choose area" InitialValue="-1" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lbNUEmail" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="tbNUEmail" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbNUUserName" runat="server" Text="User Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNUuserName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbNUuserName" ErrorMessage="Enter User name" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbNUuserName" ErrorMessage="Invalid User name" ValidationExpression="[a-zA-Z]{5,7}" ValidationGroup="nu">*</asp:RegularExpressionValidator>
                                <asp:Label ID="lbNUUsercode" runat="server" Text="User code:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tblNUusercode" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tblNUusercode" ErrorMessage="Enter User code" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tblNUusercode" ErrorMessage="Invalid User code" ValidationExpression="[a-zA-Z]{2}[0-9]{4}" ValidationGroup="nu">*</asp:RegularExpressionValidator>
                                <asp:Label ID="lbNUPassword" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNUPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbNUPassword" ErrorMessage="Enter Password" ValidationGroup="nu">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbNURoll" runat="server" Text="Roll:"></asp:Label>
                            </td>
                            <td colspan="4">
                                 <asp:RadioButtonList ID="rbtWS" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="2">Student</asp:ListItem>
                                    <asp:ListItem Value="1">Worker</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" dir="rtl">
                                <asp:Button ID="btNUAddUser" runat="server" Text="Add user" OnClick="btNUAddUser_Click" ValidationGroup="nu" />
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btNURsetform" runat="server" Text="Rsert form" OnClick="btNURsetform_Click" />
                            </td>
                        </tr>
                    </table>
                         </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Panel ID="pnlam2" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lbUpdateUser" runat="server" Font-Bold="True" Text="Update user:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbUPSelectNane" runat="server" Text="Select name:"></asp:Label>
                            </td>
                            <td class="auto-style5" colspan="5">
                                <asp:DropDownList ID="ddlUPSelectUser" runat="server" OnSelectedIndexChanged="ddlUPSelectUser_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbUPFirstName" runat="server" Text="Firsr name:"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="tbUPFirstName" runat="server"></asp:TextBox>
                            </td>
                            <td >
                                <asp:RequiredFieldValidator ID="rfvupfn" runat="server" ErrorMessage="Enter First name" ValidationGroup="up" ControlToValidate="tbUPFirstName">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lbUPLastName" runat="server" Text="LastName:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUPLastName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvupln" runat="server" ErrorMessage="Enter Last name" ValidationGroup="up" ControlToValidate="tbUPLastName">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lbUPID" runat="server" Text="ID:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUPID" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbUPPCA" runat="server" Text="Prefferd course area:"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:DropDownList ID="ddlUPPCA" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td >
                                <asp:Label ID="lbUPEmail" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="tbUPEmail" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbUPUserName" runat="server" Text="User name:"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="tbUPUserName" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td >
                                <asp:Label ID="lbUPUserCode" runat="server" Text="UserCode:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUPUserCode" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbUPPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="tbUPRoll" runat="server" Text="Roll:"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="5">
                               <asp:RadioButtonList ID="rbtupStuWork" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="2">Student</asp:ListItem>
                                    <asp:ListItem Value="1">Worker</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align ="center">
                                <asp:Button ID="btUPUpdateUser" runat="server" Text="Update user" OnClick="btUPUpdateUser_Click" ValidationGroup="up" />
                                &nbsp;<asp:Button ID="btPURsetform" runat="server" Text="Rset form" OnClick="btPURsetform_Click" />
                            </td>
                        </tr>
                    </table>
                  </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlam3" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table>
                        <tr>
                            <td colspan="11">
                                <asp:Label ID="lbACA" runat="server" Font-Bold="True" Text="Add course Area"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbACAExistingAreas" runat="server" Text="ExistingAreas:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlACAExistingAreas" runat="server" OnSelectedIndexChanged="ddlACAExistingAreas_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lbACANewArea" runat="server" Text="NewArea:" Width="100%"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbACANewArea" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="7">
                                <asp:Button ID="btACAAddCourse" runat="server" Text="Add course" OnClick="btACAAddCourse_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11">
                                <asp:Label ID="lbACAAddCourses" runat="server" Font-Bold="True" Text="Add Courses:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbACASelectArea" runat="server" Text="Select Area:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlACASelectArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlACASelectArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lbACAExistingCourses" runat="server" Text="ExistingCourses:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlExistingCourses" runat="server" OnSelectedIndexChanged="ddlExistingCourses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lbACANewCourse" runat="server" Text="NewCourse:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbNewCourse" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbACACoursePrice" runat="server" Text="CoursePrice"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbACACoursePrice" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbACACourseSellabus" runat="server" Text="CourseSellabus:"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="fupBrowse" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btACAAddCourse2" runat="server" Text="Add Course" OnClick="btACAAddCourse2_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11" class="auto-style7">
                                <asp:Label ID="lbACASCS" runat="server" Font-Bold="True" Text="Student Course Summary:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lbACASS" runat="server" Text="SelectStudent:"></asp:Label>
                            </td>
                            <td colspan="10" class="auto-style7">
                                <asp:DropDownList ID="ddlACASelectStudent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlACASelectStudent_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbACACA" runat="server" Text="Course Area:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCoursesArea" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbACANOCI" runat="server" Text="Number of courses inrolled:" Width="180px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTotalCourses" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbACATP" runat="server" Text="Total Price:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                  </asp:Panel>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
