<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MVCWithWEBAPI.Scripts.fonts.fonts.modernizser.res.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="dvGrid" style="padding: 10px; width: 450px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                    DataKeyNames="Id" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
                    PageSize="3" AllowPaging="true" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
                    OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." Width="450">
                    <Columns>
                        <asp:TemplateField HeaderText="ProductId" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductId" runat="server" Text='<%# Eval("ProductId") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MenuId" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("MenuId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMenuId" runat="server" Text='<%# Eval("MenuId") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="LeadId" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("LeadId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLeadId" runat="server" Text='<%# Eval("LeadId") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="UserId" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserId" runat="server" Text='<%# Eval("UserId") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SubscriptionType" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("SubscriptionType") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSubscriptionType" runat="server" Text='<%# Eval("SubscriptionType") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStatus" runat="server" Text='<%# Eval("Status") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Description" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FromDate" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFromDate" runat="server" Text='<%# Eval("FromDate") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ToDate" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtToDate" runat="server" Text='<%# Eval("ToDate") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                            ItemStyle-Width="150" />
                    </Columns>
                </asp:GridView>
                <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td style="width: 150px">
                            txtProductId:<br />
                            <asp:TextBox ID="txtProductId" runat="server" Width="140" />
                        </td>
                        <td style="width: 150px">
                            txtMenuId:<br />
                            <asp:TextBox ID="txtMenuId" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtUserId:<br />
                            <asp:TextBox ID="txtUserId" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtLeadId:<br />
                            <asp:TextBox ID="txtLeadId" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtSubscriptionType:<br />
                            <asp:TextBox ID="txtSubscriptionType" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtDescription:<br />
                            <asp:TextBox ID="txtDescription" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtStatus:<br />
                            <asp:TextBox ID="txtStatus" runat="server" Width="140" />
                        </td>
                         <td style="width: 150px">
                            txtFromDate:<br />
                            <asp:TextBox ID="txtFromDate" runat="server" Width="140" />
                        </td>
                        <td style="width: 150px">
                            txtToDate:<br />
                            <asp:TextBox ID="txtToDate" runat="server" Width="140" />
                        </td>

                        <td style="width: 150px">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>





<div id="dvGrid1" style="padding: 10px; width: 450px">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false" 
                    DataKeyNames="id" 
                  
                     Width="450">
                    <Columns>
                        <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("UserPassword") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserPassword" runat="server" Text='<%# Eval("UserPassword") %>' Width="140"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    </div>
    </form>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(function () {
            BlockUI("dvGrid");
            $.blockUI.defaults.css = {};
        });
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<div align = "center">' + '<img src="images/loadingAnim.gif"/></div>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        };
    </script>
</body>
</html>
