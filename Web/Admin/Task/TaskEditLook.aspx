<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskEditLook.aspx.cs" Inherits="Maticsoft.Web.Admin.Task.TaskEditLook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" AjaxAspnetControls="my_content" />
        <f:Panel ID="Panel1" CssClass="blockpanel" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Toolbars>
                <f:Toolbar ID="toolbar" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                       
                        <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </f:Button>

                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>

                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="false" EnableCollapse="true" ShowBorder="false"
                    RegionPercent="50%" ShowHeader="false" IconFont="_PullLeft" AutoScroll="true">
                    <Items>
                        <f:Tree ID="TreeDpt" IsFluid="true" CssClass="blockpanel" ShowHeader="false" Title="接收部门" ShowBorder="false"
                            EnableCollapse="false" runat="server" OnNodeCommand="TreeDpt_NodeCommand">
                        </f:Tree>
                    </Items>
                </f:Panel>

                <f:ContentPanel runat="server" ID="panelRightRegion" RegionPosition="Right" RegionSplit="false" EnableCollapse="true" AutoScroll="true" Height="540"
                    RegionPercent="50%" ShowHeader="false" IconFont="_PullRight" BodyPadding="20">
                    <div id="my_content">
                        <%-- <%=RsMsg %>--%>
                        <asp:Literal ID="lit_rs" runat="server"></asp:Literal>
                    </div>
                </f:ContentPanel>

            </Items>
        </f:Panel>
    </form>
</body>

</html>
