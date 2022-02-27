<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeFile="product.aspx.cs" Inherits="product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" style="width: 29%;">
            <tr>
                <td align="center" colspan="2">
                    Product
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Product Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Category</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Price</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" BackColor="Aqua" Font-Bold="True" 
                        Font-Italic="True" Text="Submit" onclick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("p_id") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <AlternatingItemTemplate>
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("p_c_id") %>'></asp:Literal>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("p_name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("c_name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("p_price") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("p_id") %>' 
                                        Text="Delete" onclick="Button2_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("p_id") %>' 
                                        Text="Edit" onclick="Button3_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="Gray" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
