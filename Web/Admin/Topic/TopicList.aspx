<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="Maticsoft.Web.Admin.Topic.TopicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" CssClass="blockpanel" Margin="10px" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>

                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="false" EnableCollapse="true" ShowBorder="false"
                    RegionPercent="20%" ShowHeader="false" IconFont="_PullLeft" AutoScroll="true">
                    <Items>
                        <f:Tree ID="TreeDpt" IsFluid="true" CssClass="blockpanel" ShowHeader="false" Title="上报部门"
                            EnableCollapse="false" runat="server" OnNodeCommand="TreeDpt_NodeCommand">
                        </f:Tree>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelRightRegion" RegionPosition="Right" RegionSplit="false" EnableCollapse="true" AutoScroll="true"
                    RegionPercent="80%" ShowHeader="false" IconFont="_PullRight">
                    <Items>
                        <f:Grid ID="GridDpt" runat="server" ShowBorder="false" ShowHeader="false" OnPageIndexChange="GridDpt_PageIndexChange" OnPreRowDataBound="GridDpt_PreRowDataBound"
                            DataKeyNames="Id" EnableMultiSelect="true" ShowPagingMessage="true" AllowPaging="true" IsDatabasePaging="true"
                            OnRowCommand="GridDpt_RowCommand" AllowSorting="true" SortField="Id" SortDirection="asc" OnSort="GridDpt_Sort">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" Position="Top" runat="server">
                                    <Items>
                                        <f:DropDownList runat="server" ID="drpSearch" AutoPostBack="true" OnSelectedIndexChanged="drpSearch_SelectedIndexChanged" Label="议题状态">
                                            <f:ListItem Text="全部" Value="" />
                                            <f:ListItem Text="已审核" Value="已审核" />
                                            <f:ListItem Text="待审核" Value="待审核" />
                                        </f:DropDownList>
                                    </Items>
                                    <Items>
                                        <f:TextBox runat="server" ID="txtValue" Label="议题名称"></f:TextBox>
                                    </Items>
                                    <Items>
                                        <f:Button runat="server" ID="btnSelect" Text="查询" Icon="Zoom" OnClick="btnSelect_Click"></f:Button>
                                    <f:Button runat="server" ID="btnReg" Text="刷新" Icon="Reload" OnClick="btnReg_Click"></f:Button>
                                    </Items>
                                    <Items>
                                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                        </f:ToolbarFill>

                                        <f:Button ID="btnNew" runat="server" Icon="Add" Text="添加议题" OnClick="btnNew_Click">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>


                                <f:RowNumberField EnablePagingNumber="true" />
                                <f:BoundField DataField="topicTitle" HeaderText="议题名称" ExpandUnusedSpace="true" />
                                <f:BoundField DataField="topicTime" HeaderText="提出时间" />
                                <f:BoundField DataField="policyTime" HeaderText="决策时间" />

                                <f:BoundField DataField="isCheck" HeaderText="状态" />
                                <%-- <f:BoundField DataField="isCheckPeo" HeaderText="审核人" />--%>
                                <%-- <f:BoundField DataField="isCheckTime" HeaderText="审核时间" />--%>
                                <f:LinkButtonField ColumnID="checkField" TextAlign="Center" ConfirmTarget="Top" CommandName="Check" Width="80px" HeaderText="审核操作" ConfirmText="确定进行审核操作？" />

                                <f:LinkButtonField ColumnID="editField" TextAlign="Center" ConfirmTarget="Top" CommandName="Edit" Width="80px" HeaderText="详细内容" />
                                <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ConfirmText="确定删除该条信息？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>

            </Items>
        </f:Panel>

        <f:Window ID="Window1" Hidden="true" EnableIFrame="true" runat="server" OnClose="Window1_Close"
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="850px" Title="议题内容"
            Height="600px">
        </f:Window>
    </form>
</body>
</html>
