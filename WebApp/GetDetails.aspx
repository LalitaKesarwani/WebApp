<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetDetails.aspx.cs" Inherits="WebApp.GetDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1" style="background-color:cornsilk;width:70%;height:300px">
        <tr>
            <td colspan="2" style="text-align:center;font-family:Arial;font:bold 12px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;font-family:Arial;font:bold 12px"><strong>Get Details</strong></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;font-family:Arial;font:bold 12px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align:center"><strong>Start Date</strong></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               
                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"  />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px"  Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar1_SelectionChanged">
                    <DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align:center">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"style="text-align:center"><strong>End Date</strong></td>
            <td>
                <asp:TextBox ID="TextBox2"  runat="server"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server"  style="width: 14px;" OnClick="ImageButton2_Click"  />
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px"  Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar2_SelectionChanged">
                    <DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
                
            </td>
        </tr>
        
        <tr>
            <td class="auto-style2"style="text-align:center">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="auto-style4"style="text-align:center" colspan="2">
                <asp:Button ID="Button1" runat="server" Font-Bold="true" Text="Get Details of Tweets" OnClick="Button1_Click"  />
            </td>
        </tr>
        
        <tr>
            <td class="auto-style4"style="text-align:center" colspan="2">
                &nbsp;</td>
        </tr>
        
    </table>
        <div>
        </div>
        
    </form>
</body>
</html>
