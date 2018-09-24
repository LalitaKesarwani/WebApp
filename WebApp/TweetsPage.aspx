<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TweetsPage.aspx.cs" Inherits="WebApp.TweetsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <br />
    <br />
    <h2> The List of the Tweets...</h2>
    <br />
    <form id="form1" runat="server">
        <br />
            <br />
            <br />
            <br />
     
        <div id="dvGrid"  align="center"  style ="height:500px; width:80%; overflow:scroll;" >
           
        
        <asp:GridView ID="GridView1" runat="server" ShowFooter="True" CellPadding="25" CellSpacing ="5" ForeColor="#333333" GridLines="None"
 >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle CssClass ="FixedHeader" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <br />
            <br />
            
            </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Font-Bold="true" Text="Load More" OnClick="Button1_Click"  />
        <br />
            <asp:Button ID="Button2" runat="server" Text="Modify Search" Font-Bold="true" OnClick="Button2_Click" />
        <br />
    </form>
</body>
</html>

