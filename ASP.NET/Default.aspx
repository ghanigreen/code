<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlUser" runat="server" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <br />
             <br />
            <asp:GridView ID="grdUser" runat="server" AutoGenerateColumns="false">
                <Columns>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            UserID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem,"UserID")%>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            UserName
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem,"UserName")%>
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField>
                        <HeaderTemplate>
                            UserEmail
                        </HeaderTemplate>
                        <ItemTemplate>

                            <%#DataBinder.Eval(Container.DataItem,"UserEmail")%>
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>


            </asp:GridView>
        </div>
    </form>
</body>
</html>
