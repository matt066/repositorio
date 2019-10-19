<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaComGrid.aspx.cs" Inherits="ChkBoxNoGrdView.PaginaComGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="Check_Change"/>
                            <%--<asp:HiddenField ID="hiddenField1" Value='<%# Eval("Selected").ToString() %>' runat="server" />    --%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" />
    </form>
</body>
</html>
